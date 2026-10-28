# Approfondissement sur les points manquants du jour 2 - Jour 3

## Choix techniques - Meadowbound

### Stockage des données - Format JSON

Exemple de format possible

**world.json**

```json
{
    "name": "My World",
    "size": {
        "width": 10,
        "height": 10
    },
    "tiles": [
        {
            "position": {
                "x": 0,
                "y": 0
            },
            "type": "grass",
            "texture": "texture.tiles.grass",
            "data": {}
        }
    ]
}
```

**players.json**

```json
[
    {
        "id": 1,
        "name": "Player1",
        "position": {
            "x": 0,
            "y": 0
        },
        "inventory": [],
        "health": 100,
        "achievements": [],
        "texture": "texture.players.player1"
    }
]
```

**settings.json**

```json
{
    "difficulty": "normal",
    "sound": true,
    "music": true,
    "multiplayer": {
        "enabled": false,
        "maxPlayers": 1
    },
    "graphics": {
        "resolution": "1920x1080",
        "fullscreen": true
    },
    "controls": {
        "moveUp": "W",
        "moveDown": "S",
        "moveLeft": "A",
        "moveRight": "D",
        "action": "E"
    },
    "language": "en",
    "autosave": {
        "enabled": true,
        "interval": 10
    },
    "notifications": {
        "enabled": true,
        "types": ["achievement", "friend_request"]
    },
    "cheatMode": {
        "enabled": false,
        "allowedCommands": []
    }
}
```

**achievements.json**

```json
[
    {
        "id": 1,
        "name": "First Steps",
        "description": "Complete the tutorial.",
        "unlocked": false
    }
]
```

**resources-types.json**

```json
[
    {
        "id": 1,
        "name": "Wood",
        "description": "Basic building material.",
        "texture": "texture.resources.wood"
    }
]
```

**textures.json**

```json
{
    "tiles": {
        "grass": "<path_to_texture>",
        "water": "<path_to_texture>",
        "sand": "<path_to_texture>"
    },
    "players": {
        "player1": "<path_to_texture>",
        "player2": "<path_to_texture>"
    },
    "resources": {
        "wood": "<path_to_texture>",
        "stone": "<path_to_texture>"
    }
}
```

### Planning des fonctionnalité

A compléter

[Planning](../Planning.ods)