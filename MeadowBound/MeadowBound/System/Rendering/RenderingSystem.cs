using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Meadowbound.Entities.Player;

namespace Meadowbound.Systems.Rendering;

public class RenderingSystem
{
    public void Draw(
        SpriteBatch spriteBatch,
        Texture2D texture,
        Player player)
    {
        int frameX = player.Animation.CurrentFrame;
        int frameY = (int)player.Animation.Direction;

        Rectangle sourceRectangle = new Rectangle(
            frameX * player.Animation.FrameWidth,
            frameY * player.Animation.FrameHeight,
            player.Animation.FrameWidth,
            player.Animation.FrameHeight
        );

        Rectangle destinationRectangle = new Rectangle(
            (int)player.Transform.Position.X,
            (int)player.Transform.Position.Y,
            64,
            64
        );

        spriteBatch.Draw(
            texture,
            destinationRectangle,
            sourceRectangle,
            Color.White
        );
    }
}