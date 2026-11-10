using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Xna.Framework;

namespace MeadowBound.World.Tiles;

public class Tile
{
    public Point Position { get; }
    public TileType Type { get; }
    public string TextureKey { get; }
    public IReadOnlyDictionary<string, JsonElement> Data { get; }

    public Tile(
        Point position,
        TileType type,
        string textureKey,
        IReadOnlyDictionary<string, JsonElement> data)
    {
        Position = position;
        Type = type;
        TextureKey = textureKey;
        Data = data;
    }
}