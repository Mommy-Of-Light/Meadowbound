using MeadowBound.Entities;
using MeadowBound.Core;
using WorldModel = MeadowBound.World.World;
using Microsoft.Xna.Framework;

namespace MeadowBound.Systems.Movement;

public class MovementSystem
{
	private const int EntitySize = Constants.TileSize;

	public void Update(Entity entity, float deltaTime, WorldModel world)
	{
		entity.Transform.Position +=
			entity.Movement.Direction *
			entity.Movement.Speed *
			deltaTime;

		// Calculate world boundaries in pixels
		float worldWidth = world.Width * Constants.TileSize;
		float worldHeight = world.Height * Constants.TileSize;

		// Clamp the entity inside the world
		entity.Transform.Position = Vector2.Clamp(
			entity.Transform.Position,
			Vector2.Zero,
			new Vector2(
				worldWidth - EntitySize,
				worldHeight - EntitySize
			)
		);
	}
}