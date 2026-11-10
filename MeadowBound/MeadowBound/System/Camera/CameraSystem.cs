using Meadowbound.Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Meadowbound.Systems.Camera;

public class CameraSystem
{
    public Matrix Transform { get; private set; }

    private Vector2 _position;

    public void Follow(Player player, Viewport viewport)
    {
        // Get the center of the player
        _position = new Vector2(
            player.Transform.Position.X + 32f,
            player.Transform.Position.Y + 32f
        );

        Vector2 screenCenter = new Vector2(
            viewport.Width / 2f,
            viewport.Height / 2f
        );

        Transform = Matrix.CreateTranslation(
            -_position.X,
            -_position.Y,
            0
        ) * Matrix.CreateTranslation(
            screenCenter.X,
            screenCenter.Y,
            0
        );
    }
}