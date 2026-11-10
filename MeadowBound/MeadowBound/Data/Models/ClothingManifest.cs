using System.Collections.Generic;

namespace MeadowBound.Data.Models;

public class ClothingManifest
{
    public IReadOnlyDictionary<string, string> Head { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Torso { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Hand { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Leg { get; init; }
        = new Dictionary<string, string>();

    public IReadOnlyDictionary<string, string> Foot { get; init; }
        = new Dictionary<string, string>();
}