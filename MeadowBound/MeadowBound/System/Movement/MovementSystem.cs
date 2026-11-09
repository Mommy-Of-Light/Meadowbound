using Meadowbound.Entities;

namespace Meadowbound.Systems.Movement;

public class MovementSystem
{
    public void Update(Entity entity, float deltaTime)
    {
        entity.Transform.Position += entity.Movement.Direction * entity.Movement.Speed * deltaTime;
    }
}