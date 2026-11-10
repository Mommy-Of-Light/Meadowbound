using System.Collections.Generic;
using System.Text.Json;

namespace MeadowBound.Data.Models;

public class TileManifest
{
    public TilePosition Position { get; init; } = new();

    public string Type { get; init; } = string.Empty;

    public string Texture { get; init; } = string.Empty;

    public Dictionary<string, JsonElement> Data { get; init; } = new();
}