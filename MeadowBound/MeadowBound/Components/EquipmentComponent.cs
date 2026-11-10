using Microsoft.Xna.Framework.Graphics;

namespace Meadowbound.Components;

public class EquipmentComponent
{
    public Texture2D? Body { get; set; }

    public Texture2D? Helmet { get; set; }
    public Texture2D? ChestArmor { get; set; }
    public Texture2D? Gloves { get; set; }
    public Texture2D? Pants { get; set; }
    public Texture2D? Boots { get; set; }

    public Texture2D? Tool { get; set; }
    public Texture2D? Weapon { get; set; }
}