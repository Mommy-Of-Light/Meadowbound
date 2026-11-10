using MeadowBound.Entities.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MeadowBound.Systems.Input;

public class InputSystem
{
    private KeyboardState _previousKeyboardState;
    private KeyboardState _currentKeyboardState;

    private readonly List<Keys> _pressedKeys = new();

    private readonly Keys[] _movementKeys =
    {
        Keys.W, Keys.Up,
        Keys.S, Keys.Down,
        Keys.A, Keys.Left,
        Keys.D, Keys.Right
    };

    public void Update()
    {
        _currentKeyboardState = Keyboard.GetState();

        foreach (Keys key in _movementKeys)
        {
            if (_currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key))
            {
                _pressedKeys.Remove(key);
                _pressedKeys.Add(key);
            }
        }

        _pressedKeys.RemoveAll(key => _currentKeyboardState.IsKeyUp(key));
    }

    public Vector2 GetMovementDirection()
    {
        if (_pressedKeys.Count == 0)
            return Vector2.Zero;

        Keys newestKey = _pressedKeys[^1];

        return newestKey switch
        {
            Keys.W or Keys.Up => new Vector2(0, -1),
            Keys.S or Keys.Down => new Vector2(0, 1),
            Keys.A or Keys.Left => new Vector2(-1, 0),
            Keys.D or Keys.Right => new Vector2(1, 0),
            _ => Vector2.Zero
        };
    }

    public bool IsToolEquipped(Player player)
    {
        if (_currentKeyboardState.IsKeyDown(Keys.D1) && _previousKeyboardState.IsKeyUp(Keys.D1))
        {
            player.EquippedTool = ToolType.Hoe;
            player.IsToolEquipped = true;
        }
        if (_currentKeyboardState.IsKeyDown(Keys.D2) && _previousKeyboardState.IsKeyUp(Keys.D2))
        {
            player.EquippedTool = ToolType.WateringCan;
            player.IsToolEquipped = true;
        }

        if (_currentKeyboardState.IsKeyDown(Keys.D0) && _previousKeyboardState.IsKeyUp(Keys.D0))
        {
            player.EquippedTool = ToolType.None;
            player.IsToolEquipped = false;
        }

        return player.IsToolEquipped;
    }

    public bool IsToolUsed()
    {
        return _currentKeyboardState.IsKeyDown(Keys.E);
    }

    public void FinishUpdate()
    {
        _previousKeyboardState = _currentKeyboardState;
    }
}