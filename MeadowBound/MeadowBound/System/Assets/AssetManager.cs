using MeadowBound.Data.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MeadowBound.Systems.Assets;

public class AssetManager
{
    private readonly Dictionary<string, Texture2D> _textures = new();
    private readonly Dictionary<string, SpriteFont> _fonts = new();

    public void Load(ContentManager content, AssetManifest manifest)
    {
        // Textures
        LoadTextureGroup(content, "tiles", manifest.Tiles);
        LoadTextureGroup(content, "players", manifest.Players);
        LoadTextureGroup(content, "tools", manifest.Tools);
        LoadTextureGroup(content, "resources", manifest.Resources);

        LoadTextureGroup(content, "clothing.head", manifest.Clothing.Head);
        LoadTextureGroup(content, "clothing.torso", manifest.Clothing.Torso);
        LoadTextureGroup(content, "clothing.hand", manifest.Clothing.Hand);
        LoadTextureGroup(content, "clothing.leg", manifest.Clothing.Leg);
        LoadTextureGroup(content, "clothing.foot", manifest.Clothing.Foot);

        // Fonts
        LoadFontGroup(content, "fonts", manifest.Fonts);
    }

    private void LoadTextureGroup(
        ContentManager content,
        string category,
        IReadOnlyDictionary<string, string> assets)
    {
        foreach (var asset in assets)
        {
            string key = $"{category}.{asset.Key}";

            _textures[key] = content.Load<Texture2D>(asset.Value);
        }
    }

    private void LoadFontGroup(
        ContentManager content,
        string category,
        IReadOnlyDictionary<string, string> assets)
    {
        foreach (var asset in assets)
        {
            string key = $"{category}.{asset.Key}";

            _fonts[key] = content.Load<SpriteFont>(asset.Value);
        }
    }

    public Texture2D GetTexture(string key)
    {
        if (key.StartsWith("texture."))
            key = key["texture.".Length..];

        if (!_textures.TryGetValue(key, out Texture2D? texture))
        {
            throw new KeyNotFoundException(
                $"Texture '{key}' was not found."
            );
        }

        return texture;
    }

    public SpriteFont GetSpriteFont(string key)
    {
        if (!_fonts.TryGetValue(key, out SpriteFont? font))
        {
            throw new KeyNotFoundException(
                $"Font '{key}' was not found."
            );
        }

        return font;
    }
}