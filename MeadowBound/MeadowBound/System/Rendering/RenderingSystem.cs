using Meadowbound.Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Meadowbound.Systems.Rendering;

public class RenderingSystem
{
    public void Draw(SpriteBatch spriteBatch, Player player)
    {
        Rectangle? sourceRectangle = player.Animation.CurrentSourceRectangle;

        if (!sourceRectangle.HasValue)
            return;

        Rectangle destinationRectangle = new Rectangle((int)MathF.Round(player.Transform.Position.X), (int)MathF.Round(player.Transform.Position.Y), 64, 64);

        DrawLayer(spriteBatch, player.Equipment.Body, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.Pants, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.Boots, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.ChestArmor, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.Gloves, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.Helmet, sourceRectangle.Value, destinationRectangle);

        if (player.IsToolEquipped)
            DrawLayer(spriteBatch, player.Equipment.Tool, sourceRectangle.Value, destinationRectangle);

        DrawLayer(spriteBatch, player.Equipment.Weapon, sourceRectangle.Value, destinationRectangle);
    }

    private void DrawLayer(SpriteBatch spriteBatch, Texture2D? texture, Rectangle sourceRectangle, Rectangle destinationRectangle)
    {
        if (texture == null)
            return;

        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}