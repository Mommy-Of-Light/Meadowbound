using MeadowBound.Data.Models;
using MeadowBound.World.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MeadowBound.World;

public class WorldGenerator
{
    private const int PlotSize = 8;

    private enum LandPlotPreset
    {
        Meadow,
        DirtClearing,
        RockyGround
    }

    public WorldManifest GenerateRandomManifest(
        WorldManifest template,
        AssetManifest assets)
    {
        if (template.Size.Width <= 0 || template.Size.Height <= 0)
            throw new ArgumentException("World dimensions must be greater than zero.");

        if (!assets.Tiles.ContainsKey("grass") ||
            !assets.Tiles.ContainsKey("dirt") ||
            !assets.Tiles.ContainsKey("stone"))
        {
            throw new InvalidOperationException(
                "The world generator requires grass, dirt and stone textures.");
        }

        SeededRandom random = new(template.Seed);

        List<TileManifest> generatedTiles = new();

        int plotsX = (template.Size.Width + PlotSize - 1) / PlotSize;
        int plotsY = (template.Size.Height + PlotSize - 1) / PlotSize;

        for (int plotY = 0; plotY < plotsY; plotY++)
        {
            for (int plotX = 0; plotX < plotsX; plotX++)
            {
                LandPlotPreset preset = (LandPlotPreset)random.Next(3);

                GeneratePlot(
                    generatedTiles,
                    preset,
                    plotX,
                    plotY,
                    template.Size.Width,
                    template.Size.Height,
                    random
                );
            }
        }

        return new WorldManifest
        {
            Name = template.Name,
            Seed = template.Seed,
            Size = template.Size,
            Tiles = generatedTiles
        };
    }

    private void GeneratePlot(
        List<TileManifest> tiles,
        LandPlotPreset preset,
        int plotX,
        int plotY,
        int worldWidth,
        int worldHeight,
        SeededRandom random)
    {
        int startX = plotX * PlotSize;
        int startY = plotY * PlotSize;

        // Randomized preset parameters
        int centerX = random.Next(2, 6);
        int centerY = random.Next(2, 6);

        int radius = random.Next(2, 4);

        int dirtMargin = random.Next(1, 3);

        for (int y = 0; y < PlotSize; y++)
        {
            for (int x = 0; x < PlotSize; x++)
            {
                int worldX = startX + x;
                int worldY = startY + y;

                // Ignore tiles outside the world
                if (worldX >= worldWidth || worldY >= worldHeight)
                    continue;

                string tileType = preset switch
                {
                    LandPlotPreset.Meadow =>
                        GenerateMeadowTile(x, y, random),

                    LandPlotPreset.DirtClearing =>
                        GenerateDirtClearingTile(
                            x, y, centerX, centerY, dirtMargin, random),

                    LandPlotPreset.RockyGround =>
                        GenerateRockyGroundTile(
                            x, y, centerX, centerY, radius, random),

                    _ => "grass"
                };

                tiles.Add(new TileManifest
                {
                    Position = new TilePosition
                    {
                        X = worldX,
                        Y = worldY
                    },
                    Type = tileType,
                    Texture = $"texture.tiles.{tileType}",
                    Data = new Dictionary<string, JsonElement>()
                });
            }
        }
    }

    private string GenerateMeadowTile(
        int x,
        int y,
        SeededRandom random)
    {
        // Create a winding dirt path
        int pathY = 4 + (int)Math.Round(
            Math.Sin(x * 0.7) * 1.5
        );

        if (y == pathY || y == pathY + 1)
            return "dirt";

        // Occasional stones
        if (random.Next(100) < 3)
            return "stone";

        return "grass";
    }

    private string GenerateDirtClearingTile(
        int x,
        int y,
        int centerX,
        int centerY,
        int margin,
        SeededRandom random)
    {
        bool insideDirtArea =
            x >= margin &&
            x < PlotSize - margin &&
            y >= margin &&
            y < PlotSize - margin;

        if (insideDirtArea)
        {
            if (random.Next(100) < 3)
                return "stone";

            return "dirt";
        }

        return "grass";
    }

    private string GenerateRockyGroundTile(
        int x,
        int y,
        int centerX,
        int centerY,
        int radius,
        SeededRandom random)
    {
        float dx = x - centerX;
        float dy = y - centerY;

        float distance = (float)Math.Sqrt(dx * dx + dy * dy);

        if (distance <= radius && random.Next(100) < 85)
            return "stone";

        if (distance <= radius + 1 && random.Next(100) < 25)
            return "dirt";

        return "grass";
    }

    public World Generate(WorldManifest manifest)
    {
        if (manifest.Size.Width <= 0 || manifest.Size.Height <= 0)
            throw new ArgumentException("World dimensions must be greater than zero.");

        List<Tile> tiles = new();
        HashSet<Point> occupiedPositions = new();

        foreach (TileManifest tileData in manifest.Tiles)
        {
            Point position = new(
                tileData.Position.X,
                tileData.Position.Y
            );

            if (position.X < 0 || position.X >= manifest.Size.Width ||
                position.Y < 0 || position.Y >= manifest.Size.Height)
                throw new ArgumentException(
                    $"Tile position {position} is outside the world boundaries.");

            if (!occupiedPositions.Add(position))
                throw new ArgumentException(
                    $"Multiple tiles occupy position {position}.");

            if (!Enum.TryParse(tileData.Type, true, out TileType tileType) ||
                !Enum.IsDefined(typeof(TileType), tileType))
                throw new ArgumentException(
                    $"Unknown tile type '{tileData.Type}'.");

            if (string.IsNullOrWhiteSpace(tileData.Texture))
                throw new ArgumentException(
                    $"Tile at {position} has no texture reference.");

            tiles.Add(new Tile(
                position,
                tileType,
                tileData.Texture,
                tileData.Data
            ));
        }

        return new World(
            manifest.Name,
            manifest.Size.Width,
            manifest.Size.Height,
            tiles.AsReadOnly()
        );
    }

    // Deterministic pseudo-random number generator
    private class SeededRandom
    {
        private uint _state;

        public SeededRandom(int seed)
        {
            _state = unchecked((uint)seed);

            if (_state == 0)
                _state = 0x6D2B79F5;
        }

        private uint NextUInt()
        {
            uint x = _state;

            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;

            _state = x;

            return x;
        }

        public int Next(int max)
        {
            return (int)(NextUInt() % (uint)max);
        }

        public int Next(int min, int max)
        {
            return min + Next(max - min);
        }
    }
}