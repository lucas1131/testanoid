using UnityEngine;
using Zenject;

public class PlayerController : IPlayerController
{
    private Rigidbody2D _player;
    private IGameConfig _gameConfig;
    private IPlayerPositioner _playerPositioner;

    [Inject]
    public PlayerController(IPlayerRigidbodyGetter playerRigidbodyGetter, 
        IPlayerPositioner playerPositioner,
        IPlayerInputListener inputListener,
        IPlayerCollisionListener collisionListener,
        IGameConfig gameConfig)
    {
        _player = playerRigidbodyGetter.Player;
        _playerPositioner = playerPositioner;
        inputListener.OnMovementDirectionChanged += Move;
        collisionListener.OnPlayerCollisionEnter += WallCollisionHandler;
        _gameConfig = gameConfig;
    }

    public void Move(Vector2 direction)
    {
        _player.velocity = direction * _gameConfig.PlayerSpeed;
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerPositioner.Position;
    }

    public void SetPlayerPosition(Vector3 position)
    {
        _playerPositioner.Position = position;
    }

    private void WallCollisionHandler(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WALL")) 
        {
            _player.velocity = Vector2.zero;
        }
    }
}