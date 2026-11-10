using System.Collections.Generic;
using MeadowBound.World.Tiles;

namespace MeadowBound.World;

public class World
{
    public string Name { get; }
    public int Width { get; }
    public int Height { get; }

    public IReadOnlyList<Tile> Tiles { get; }

    public World(
        string name,
        int width,
        int height,
        IReadOnlyList<Tile> tiles)
    {
        Name = name;
        Width = width;
        Height = height;
        Tiles = tiles;
    }
}