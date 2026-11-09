using Meadowbound.Components;
using Meadowbound.Entities;
using Microsoft.Xna.Framework;

namespace Meadowbound.Entities.Player;

public class Player : Entity
{
    public AnimationComponent Animation { get; }

    public Player(Vector2 startPosition)
        : base(
            new TransformComponent(startPosition),
            new MovementComponent(150f))
    {
        Animation = new AnimationComponent();
    }
}