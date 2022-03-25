using UnityEngine;
using Zenject;

public class PlayerController : IPlayerController
{
    private Rigidbody2D player;
    private IGameConfig _gameConfig;
    private IPlayerPositioner _playerPositioner;

    [Inject]
    public PlayerController(IPlayerRigidbodyGetter playerRigidbodyGetter, 
        IPlayerPositioner playerPositioner,
        IPlayerInputListener inputListener, 
        IGameConfig gameConfig)
    {
        player = playerRigidbodyGetter.Player;
        _playerPositioner = playerPositioner;
        inputListener.OnMovementDirectionChanged += Move;
        _gameConfig = gameConfig;
    }

    public void Move(Vector2 direction)
    {
        player.velocity = direction * _gameConfig.PlayerSpeed;
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerPositioner.Position;
    }

    public void SetPlayerPosition(Vector3 position)
    {
        _playerPositioner.Position = position;
    }
}