using Meadowbound.Entities.Player;
using Meadowbound.Systems.Animation;
using Meadowbound.Systems.Input;
using Meadowbound.Systems.Movement;
using Meadowbound.Systems.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MeadowBound.Core;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;

    private InputSystem _inputSystem;
    private MovementSystem _movementSystem;
    private RenderingSystem _renderingSystem;

    private AnimationSystem _animationSystem;

    private Texture2D _playerTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
    }

    protected override void Initialize()
    {
        _player = new Player(new Vector2(100, 100));

        _inputSystem = new InputSystem();
        _movementSystem = new MovementSystem();
        _renderingSystem = new RenderingSystem();
        _animationSystem = new AnimationSystem();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _playerTexture =
            Content.Load<Texture2D>("Textures/Player/player1");
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime =
            (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Read input
        _player.Movement.Direction =
            _inputSystem.GetMovementDirection();

        // Update position
        _movementSystem.Update(_player, deltaTime);

        // Update animation
        _animationSystem.Update(_player, deltaTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp
        );

        _renderingSystem.Draw(
            _spriteBatch,
            _playerTexture,
            _player
        );

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
