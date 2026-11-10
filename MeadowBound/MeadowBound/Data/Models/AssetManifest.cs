using System.Collections.Generic;

namespace MeadowBound.Data.Models;

public class AssetManifest
{
    public IReadOnlyDictionary<string, string> Tiles { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Players { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Tools { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Resources { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Fonts { get; init; }
        = new Dictionary<string, string>();

    public ClothingManifest Clothing { get; init; } = new();
}