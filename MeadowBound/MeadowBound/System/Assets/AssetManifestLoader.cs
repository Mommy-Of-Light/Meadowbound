using MeadowBound.Data.Models;
using System.IO;
using System.Text.Json;

namespace MeadowBound.Systems.Assets;

public class AssetManifestLoader
{
    public AssetManifest Load(string filePath)
    {
        string json = File.ReadAllText(filePath);

        AssetManifest? manifest =
            JsonSerializer.Deserialize<AssetManifest>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

        return manifest ?? throw new InvalidDataException(
            "Unable to load the asset manifest."
        );
    }
}