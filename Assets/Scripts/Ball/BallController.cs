using UnityEngine;
using Zenject;

public class BallController : IBallController
{
    private Rigidbody2D _ball;
    private IBallPositioner _ballPositioner;
    private IGameConfig _gameConfig;

    [Inject]
    public BallController(IBallRigidbodyGetter ballGetter, 
        IBallPositioner ballPositioner, 
        IGameConfig gameConfig)
    {
        _ball = ballGetter.Ball;
        _ballPositioner = ballPositioner;
        _gameConfig = gameConfig;
    }
    
    public void Kick()
    {
        var direction = Random.insideUnitCircle.normalized;
        var speed = Random.Range(_gameConfig.BallMinSpeed, _gameConfig.BallMaxSpeed);
        _ball.velocity = direction * speed;
    }

    public void SetVelocity(Vector2 velocity)
    {
        _ball.velocity = velocity;
    }

    public void SetPosition(Vector2 position)
    {
        _ballPositioner.Position = position;
    }

}