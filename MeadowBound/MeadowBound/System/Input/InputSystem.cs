using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Meadowbound.Systems.Input;

public class InputSystem
{
    private KeyboardState _previousKeyboardState;

    private readonly List<Keys> _pressedKeys = new();

    private readonly Keys[] _movementKeys =
    {
        Keys.W, Keys.Up,
        Keys.S, Keys.Down,
        Keys.A, Keys.Left,
        Keys.D, Keys.Right
    };

    public Vector2 GetMovementDirection()
    {
        KeyboardState keyboard = Keyboard.GetState();

        foreach (Keys key in _movementKeys)
        {
            if (keyboard.IsKeyDown(key) &&
                _previousKeyboardState.IsKeyUp(key))
            {
                _pressedKeys.Remove(key);
                _pressedKeys.Add(key);
            }
        }

        _pressedKeys.RemoveAll(key => keyboard.IsKeyUp(key));

        _previousKeyboardState = keyboard;

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
}