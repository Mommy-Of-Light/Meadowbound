using System.Collections.Generic;

namespace MeadowBound.Data.Models;

public class WorldManifest
{
    public string Name { get; init; } = string.Empty;
    public int Seed { get; init; } = 12345;
    public WorldSize Size { get; init; } = new();
    public List<TileManifest> Tiles { get; init; } = new();
}