using MeadowBound.Components;
using MeadowBound.Entities;
using Microsoft.Xna.Framework;

namespace MeadowBound.Entities.Player;

public enum ToolType
{
    None,
    Hoe,
    WateringCan
}

public class Player : Entity
{
    public EquipmentComponent Equipment { get; }
    public AnimationComponent Animation { get; }
    public bool IsToolEquipped { get; set; } = false;
    public bool IsToolUsed { get; set; } = false;
    public ToolType EquippedTool { get; set; } = ToolType.None;

    public Player(Vector2 startPosition) : base(new TransformComponent(startPosition), new MovementComponent(200f))
    {
        Equipment = new EquipmentComponent();
        Animation = new AnimationComponent();
    }
}