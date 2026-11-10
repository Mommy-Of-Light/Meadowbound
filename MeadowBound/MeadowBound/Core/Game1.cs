using MeadowBound.Components;
using MeadowBound.Core;
using MeadowBound.Data.Models;
using MeadowBound.Entities.Player;
using MeadowBound.Systems.Animation;
using MeadowBound.Systems.Assets;
using MeadowBound.Systems.Camera;
using MeadowBound.Systems.Input;
using MeadowBound.Systems.Movement;
using MeadowBound.Systems.Rendering;
using MeadowBound.Systems.Save;
using MeadowBound.World;
using MeadowBound.World.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;

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

    private SpriteFont _defaultFont;

    private CameraSystem _cameraSystem;

    private AssetManifestLoader _assetManifestLoader;
    private AssetManager _assetManager;

    private WorldLoader _worldLoader;
    private WorldGenerator _worldGenerator;

    private SaveSystem _saveSystem;
    private Map _map;

    private WorldRenderingSystem _worldRenderingSystem;

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

        _assetManifestLoader = new AssetManifestLoader();
        _assetManager = new AssetManager();

        _worldLoader = new WorldLoader();
        _worldGenerator = new WorldGenerator();
        _worldRenderingSystem = new WorldRenderingSystem();

        _saveSystem = new SaveSystem();
        _map = new Map();

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
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Up, new AnimationClip(22, 2, Constants.TileSize, Constants.TileSize, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Left, new AnimationClip(23, 2, Constants.TileSize, Constants.TileSize, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Down, new AnimationClip(24, 2, Constants.TileSize, Constants.TileSize, 5f));
        _player.Animation.AddAnimation(AnimationState.Idle, FacingDirection.Right, new AnimationClip(25, 2, Constants.TileSize, Constants.TileSize, 5f));

        // Walk animations
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Up, new AnimationClip(08, 8, Constants.TileSize, Constants.TileSize, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Left, new AnimationClip(09, 8, Constants.TileSize, Constants.TileSize, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Down, new AnimationClip(10, 8, Constants.TileSize, Constants.TileSize, 8f, 1));
        _player.Animation.AddAnimation(AnimationState.Walk, FacingDirection.Right, new AnimationClip(11, 8, Constants.TileSize, Constants.TileSize, 8f, 1));

        // Use hoe animations
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Up, new AnimationClip(4, 7, Constants.TileSize, Constants.TileSize, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Left, new AnimationClip(5, 7, Constants.TileSize, Constants.TileSize, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Down, new AnimationClip(6, 7, Constants.TileSize, Constants.TileSize, 8f, 1, false));
        _player.Animation.AddAnimation(AnimationState.Hoe, FacingDirection.Right, new AnimationClip(7, 7, Constants.TileSize, Constants.TileSize, 8f, 1, false));

        // watering can animations
        int[] wateringFrames = { 0, 1, 4, 4, 4, 5 };
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Up, new AnimationClip(4, wateringFrames, Constants.TileSize, Constants.TileSize, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Left, new AnimationClip(5, wateringFrames, Constants.TileSize, Constants.TileSize, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Down, new AnimationClip(6, wateringFrames, Constants.TileSize, Constants.TileSize, 8f, false));
        _player.Animation.AddAnimation(AnimationState.WateringCan, FacingDirection.Right, new AnimationClip(7, wateringFrames, Constants.TileSize, Constants.TileSize, 8f, false));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        AssetManifest manifest = _assetManifestLoader.Load(Path.Combine(Content.RootDirectory, "assets.json"));

        _assetManager.Load(Content, manifest);

        _defaultFont = _assetManager.GetSpriteFont("fonts.default");

        _player.Equipment.Body = _assetManager.GetTexture("players.player1");
        _player.Equipment.Pants = _assetManager.GetTexture("clothing.leg.pant1");
        _player.Equipment.Boots = _assetManager.GetTexture("clothing.foot.shoe1");
        _player.Equipment.ChestArmor = _assetManager.GetTexture("clothing.torso.torso1");
        _player.Equipment.Gloves = _assetManager.GetTexture("clothing.hand.glove1");

        LoadWorld(manifest);
    }

    private void LoadWorld(AssetManifest manifest) 
    {
        string savePath = Path.Combine(
            AppContext.BaseDirectory,
            "Saves",
            "world.json"
        );

        string worldPath = Path.Combine(
            Content.RootDirectory,
            "Worlds",
            "world.json"
        );

        // Calculate a hash using both world configuration and available tiles
        string currentHash = _saveSystem.CalculateWorldHash(
            worldPath,
            Path.Combine(Content.RootDirectory, "assets.json")
        );

        //bool saveExists = File.Exists(savePath);
        bool saveExists = false; // For testing purposes, always regenerate the world

        string? savedHash = saveExists
            ? _saveSystem.LoadWorldHash(savePath)
            : null;

        WorldManifest worldManifest;

        if (saveExists && savedHash == currentHash)
        {
            // Configuration hasn't changed: load the existing world
            worldManifest = _saveSystem.LoadWorld(savePath);
        }
        else
        {
            // Configuration changed or no save exists: regenerate
            WorldManifest template = _worldLoader.Load(worldPath);

            worldManifest = _worldGenerator.GenerateRandomManifest(
                template,
                manifest
            );

            // Save the newly generated world and its source hash
            _saveSystem.SaveWorld(
                worldManifest,
                currentHash,
                savePath
            );
        }

        // Initialize the runtime map
        _map.Initialize(worldManifest, _worldGenerator);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _inputSystem.Update();

        UpdatePlayer(deltaTime);

        _cameraSystem.Follow(
            _player,
            _map.CurrentWorld!,
            GraphicsDevice.Viewport
        );

        _inputSystem.FinishUpdate();

        base.Update(gameTime);
    }

    private void UpdatePlayer(float deltaTime)
    {
        _player.Movement.Direction = _inputSystem.GetMovementDirection();
        _player.IsToolEquipped = _inputSystem.IsToolEquipped(_player);
        _player.IsToolUsed = _inputSystem.IsToolUsed();

        _player.Equipment.Tool = GetPlayerCurrentToolTexture();

        _movementSystem.Update(_player, deltaTime, _map.CurrentWorld!);

        _animationSystem.Update(_player, deltaTime);
    }

    private Texture2D? GetPlayerCurrentToolTexture()
    {
        if (!_player.IsToolEquipped)
            return null;

        return _player.EquippedTool switch
        {
            ToolType.Hoe => _assetManager.GetTexture("tools.hoe"),
            ToolType.WateringCan => _assetManager.GetTexture("tools.wateringCan"),
            _ => null
        };
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp,
            transformMatrix: _cameraSystem.Transform
        );

        // Draw the world first
        _worldRenderingSystem.Draw(
            _spriteBatch,
            _map.CurrentWorld!,
            _assetManager
        );

        // Draw the player on top of the world
        _renderingSystem.Draw(_spriteBatch, _player);

        _spriteBatch.End();

        // Draw UI without camera transformation
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spriteBatch.DrawString(
            _defaultFont,
            $"X: {_player.Transform.Position.X:0.00}, Y: {_player.Transform.Position.Y:0.00}",
            new Vector2(10, 10),
            Color.White
        );

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
