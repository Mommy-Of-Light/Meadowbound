using MeadowBound.Core;
using MeadowBound.Entities.Player;
using MeadowBound.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MeadowBound.Systems.Camera;

public class CameraSystem
{
    public Matrix Transform { get; private set; }

    private Vector2 _position;

    public void Follow(Player player, World.World world, Viewport viewport)
    {
        // Get the center of the player
        _position = new Vector2(
            player.Transform.Position.X + 32f,
            player.Transform.Position.Y + 32f
        );

        // Calculate world dimensions in pixels
        float worldWidth = world.Width * Constants.TileSize;
        float worldHeight = world.Height * Constants.TileSize;

        // Calculate the center of the viewport
        Vector2 screenCenter = new Vector2(
            viewport.Width / 2f,
            viewport.Height / 2f
        );

        // Calculate the minimum and maximum camera positions
        float minX = screenCenter.X;
        float minY = screenCenter.Y;

        float maxX = worldWidth - screenCenter.X;
        float maxY = worldHeight - screenCenter.Y;

        // Clamp camera position to world boundaries
        float cameraX = worldWidth <= viewport.Width
            ? worldWidth / 2f
            : MathHelper.Clamp(_position.X, minX, maxX);

        float cameraY = worldHeight <= viewport.Height
            ? worldHeight / 2f
            : MathHelper.Clamp(_position.Y, minY, maxY);

        // Build camera transformation
        Transform = Matrix.CreateTranslation(
            -cameraX,
            -cameraY,
            0
        ) * Matrix.CreateTranslation(
            screenCenter.X,
            screenCenter.Y,
            0
        );
    }
}