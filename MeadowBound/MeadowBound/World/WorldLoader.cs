using MeadowBound.Data.Models;
using System.IO;
using System.Text.Json;

namespace MeadowBound.World;

public class WorldLoader
{
    public WorldManifest Load(string filePath)
    {
        string json = File.ReadAllText(filePath);

        WorldManifest? manifest =
            JsonSerializer.Deserialize<WorldManifest>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return manifest ?? throw new InvalidDataException(
            "Unable to load the world manifest.");
    }
}