using Meadowbound.Components;
using Meadowbound.Entities;
using Microsoft.Xna.Framework;

namespace Meadowbound.Entities.Player;

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

    public Player(Vector2 startPosition) : base(new TransformComponent(startPosition), new MovementComponent(100f))
    {
        Equipment = new EquipmentComponent();
        Animation = new AnimationComponent();
    }
}