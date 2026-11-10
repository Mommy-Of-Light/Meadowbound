using Meadowbound.Components;
using Meadowbound.Entities.Player;
using Meadowbound.Systems.Animation;
using Meadowbound.Systems.Camera;
using Meadowbound.Systems.Input;
using Meadowbound.Systems.Movement;
using Meadowbound.Systems.Rendering;
using Meadowbound.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace MeadowBound.Core;

public enum TextureType
{
    Body,
    Pants,
    Boots,
    ChestArmor,
    Gloves,
    Helmet,
    Hoe,
    WateringCan
}

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;

    private InputSystem _inputSystem;
    private MovementSystem _movementSystem;
    private RenderingSystem _renderingSystem;

    private AnimationSystem _animationSystem;

    private Dictionary<TextureType, Texture2D> _textureDictionary;

    private SpriteFont _defaultFont;

    private CameraSystem _cameraSystem;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        this.Window.Title = Constants.AppName;

        _graphics.PreferredBackBufferWidth = Constants.ScreenWidth;
        _graphics.PreferredBackBufferHeight = Constants.ScreenHeight;
    }

    protected override void Initialize()
    {
        _player = new Player(new Vector2(0, 0));

        _inputSystem = new InputSystem();
        _movementSystem = new MovementSystem();
        _renderingSystem = new RenderingSystem();
        _animationSystem = new AnimationSystem();
        _cameraSystem = new CameraSystem();

        _textureDictionary = new Dictionary<TextureType, Texture2D>();

        RegisterAnimations();

        _player.Animation.SetAnimation(AnimationState.Idle, FacingDirection.Down);

        base.Initialize();
    }

    private void RegisterAnimations()
    {
        RegisterPlayerAnimations();
    }

    private void RegisterPlayerAnimations()
    {
        // Idle animations
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Up, new AnimationClip(22, 2, 64, 64, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Left, new AnimationClip(23, 2, 64, 64, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Down, new AnimationClip(24, 2, 64, 64, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Right, new AnimationClip(25, 2, 64, 64, 5f));

        // Walk animations
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Up, new AnimationClip(08, 8, 64, 64, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Left, new AnimationClip(09, 8, 64, 64, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Down, new AnimationClip(10, 8, 64, 64, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Right, new AnimationClip(11, 8, 64, 64, 8f, 1));

        // Use hoe animations
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Up, new AnimationClip(4, 7, 64, 64, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Left, new AnimationClip(5, 7, 64, 64, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Down, new AnimationClip(6, 7, 64, 64, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Right, new AnimationClip(7, 7, 64, 64, 8f, 1, false));

        // watering can animations
        int[] wateringFrames = { 0, 1, 4, 4, 4, 5 };
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Up, new AnimationClip(4, wateringFrames, 64, 64, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Left, new AnimationClip(5, wateringFrames, 64, 64, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Down, new AnimationClip(6, wateringFrames, 64, 64, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Right, new AnimationClip(7, wateringFrames, 64, 64, 8f, false));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _textureDictionary[TextureType.Body] = Content.Load<Texture2D>("Textures/Player/player1");
        _textureDictionary[TextureType.Pants] = Content.Load<Texture2D>("Textures/Clothing/Pant/Pant1");
        _textureDictionary[TextureType.Boots] = Content.Load<Texture2D>("Textures/Clothing/Shoe/Shoe1");
        _textureDictionary[TextureType.ChestArmor] = Content.Load<Texture2D>("Textures/Clothing/Torso/ShortSleeve1");
        _textureDictionary[TextureType.Gloves] = Content.Load<Texture2D>("Textures/Clothing/Glove/Glove1");
        _textureDictionary[TextureType.Hoe] = Content.Load<Texture2D>("Textures/Tools/hoe");
        _textureDictionary[TextureType.WateringCan] = Content.Load<Texture2D>("Textures/Tools/watering-can");

        _defaultFont = Content.Load<SpriteFont>("Font/DefaultFont");

        _player.Equipment.Body = _textureDictionary[TextureType.Body];
        _player.Equipment.Pants = _textureDictionary[TextureType.Pants];
        _player.Equipment.Boots = _textureDictionary[TextureType.Boots];
        _player.Equipment.ChestArmor = _textureDictionary[TextureType.ChestArmor];
        _player.Equipment.Gloves = _textureDictionary[TextureType.Gloves];
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _inputSystem.Update();

        UpdatePlayer(deltaTime);

        _cameraSystem.Follow(_player, GraphicsDevice.Viewport);

        _inputSystem.FinishUpdate();

        base.Update(gameTime);
    }

    private void UpdatePlayer(float deltaTime)
    {
        _player.Movement.Direction = _inputSystem.GetMovementDirection();
        _player.IsToolEquipped = _inputSystem.IsToolEquipped(_player);
        _player.IsToolUsed = _inputSystem.IsToolUsed();

        _player.Equipment.Tool = GetPlayerCurrentToolTexture();

        _movementSystem.Update(_player, deltaTime);

        _animationSystem.Update(_player, deltaTime);
    }

    private Texture2D? GetPlayerCurrentToolTexture()
    {
        if (!_player.IsToolEquipped)
            return null;

        return _player.EquippedTool switch
        {
            ToolType.Hoe => _textureDictionary[TextureType.Hoe],
            ToolType.WateringCan => _textureDictionary[TextureType.WateringCan],
            _ => null
        };
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        //_spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _cameraSystem.Transform);

        _renderingSystem.Draw(_spriteBatch, _player);

        //_spriteBatch.End();

        //_spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spriteBatch.DrawString(_defaultFont, $"X: {_player.Transform.Position.X:0.00}, Y: {_player.Transform.Position.Y:0.00}", new Vector2(10, 10), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
