using UnityEngine;
using Zenject;

public class BallController : IBallController
{
    private Rigidbody2D _ball;
    private IBallPositioner _ballPositioner;
    private float _speed;

    [Inject]
    public BallController(IBallRigidbodyGetter ballGetter, IBallPositioner ballPositioner, [InjectOptional] float speed=1f)
    {
        _ball = ballGetter.Ball;
        _ballPositioner = ballPositioner;
        _speed = speed;
    }
    
    public void Kick()
    {
        _ball.velocity = Random.insideUnitCircle * _speed;
    }

    public void Move()
    {
        _ball.velocity = _ball.velocity.normalized * _speed;
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