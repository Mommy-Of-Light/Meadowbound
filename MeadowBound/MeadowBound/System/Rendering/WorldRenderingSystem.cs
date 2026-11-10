using MeadowBound.Systems.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MeadowBound.Systems.Rendering;

public class WorldRenderingSystem
{
    private const int TileSize = 64;

    public void Draw(
        SpriteBatch spriteBatch,
        World.World world,
        AssetManager assetManager)
    {
        foreach (var tile in world.Tiles)
        {
            Texture2D texture = assetManager.GetTexture(tile.TextureKey);

            Rectangle destination = new Rectangle(
                tile.Position.X * TileSize,
                tile.Position.Y * TileSize,
                TileSize,
                TileSize
            );

            spriteBatch.Draw(texture, destination, Color.White);
        }
    }
}