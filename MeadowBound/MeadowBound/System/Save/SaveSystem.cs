using MeadowBound.Data.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MeadowBound.Systems.Save;

public class SaveSystem
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public void SaveWorld(WorldManifest manifest, string filePath)
    {
        string? directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        string json = JsonSerializer.Serialize(manifest, _options);

        File.WriteAllText(filePath, json);
    }

    public WorldManifest LoadWorld(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException(
                "Save file was not found.", filePath);

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<WorldManifest>(
            json, _options
        ) ?? throw new InvalidDataException(
            "Unable to load the saved world.");
    }
    public string CalculateWorldHash(params string[] filePaths)
    {
        using IncrementalHash hash =
            IncrementalHash.CreateHash(HashAlgorithmName.SHA256);

        foreach (string filePath in filePaths)
        {
            byte[] fileName = Encoding.UTF8.GetBytes(
                Path.GetFileName(filePath));

            byte[] fileContent = File.ReadAllBytes(filePath);

            hash.AppendData(fileName);
            hash.AppendData(new byte[] { 0 });
            hash.AppendData(fileContent);
            hash.AppendData(new byte[] { 0 });
        }

        return Convert.ToHexString(hash.GetHashAndReset());
    }

    public void SaveWorld(
        WorldManifest manifest,
        string sourceHash,
        string filePath)
    {
        string? directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        string json = JsonSerializer.Serialize(manifest, _options);

        File.WriteAllText(filePath, json);
        File.WriteAllText(filePath + ".sha256", sourceHash);
    }

    public string? LoadWorldHash(string filePath)
    {
        string hashPath = filePath + ".sha256";

        if (!File.Exists(hashPath))
            return null;

        return File.ReadAllText(hashPath);
    }
}