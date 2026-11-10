using MeadowBound.Data.Models;
using MeadowBound.World;

namespace MeadowBound.World.Map;

public class Map
{
    public World CurrentWorld { get; private set; }

    public void Initialize(
        WorldManifest manifest,
        WorldGenerator worldGenerator)
    {
        CurrentWorld = worldGenerator.Generate(manifest);
    }
}