using UnityEngine;
using Zenject;

public class DebugCommands : MonoBehaviour
{
#if true //debug commands
    private IGamePlay _gamePlay;
    private IBallPositioner _ballPositioner;
    private IGameConfig _gameConfig;
    private Vector3 _ballInitialPosition;

    private static bool _drawLines = false;

    [Inject]
    private void Construct(IGamePlay gamePlay, IBallPositioner ballPositioner, IGameConfig gameConfig)
    {
        _gamePlay = gamePlay;
        _ballPositioner = ballPositioner;
        _gameConfig = gameConfig;
        
        _ballInitialPosition = ballPositioner.Position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _drawLines = !_drawLines;
        }

        if(_gamePlay.GameIsRunning)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _gamePlay.Lose();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _gamePlay.Win();
            }
        }

        if(_drawLines)
        {
            DrawBallCone();
        }
    }

    private void DrawBallCone()
    {
        // same code from ballcontroller but without random
        // Min angle
        var angle = _gameConfig.BallAngleMin;
        var direction = GetDirectionInCone(10f, angle);
        direction = _ballPositioner.TransformDirection(direction);
        Debug.DrawLine(_ballInitialPosition, direction, Color.red);
        
        // draw a few lines between so we know which side of the cone we are using
        var step = (_gameConfig.BallAngleMax - _gameConfig.BallAngleMin)/5f;

        for(int i = 1; i < 5; i++)
        {
            angle = _gameConfig.BallAngleMin + step*i;
            direction = GetDirectionInCone(5f, angle);
            direction = _ballPositioner.TransformDirection(direction);
            Debug.DrawLine(_ballInitialPosition, direction);
        }

        // Max angle
        angle = _gameConfig.BallAngleMax;
        direction = GetDirectionInCone(10f, angle);
        direction = _ballPositioner.TransformDirection(direction);
        Debug.DrawLine(_ballInitialPosition, direction, Color.red);
    }

    private Vector2 GetDirectionInCone(float radius, float angle)
    {
        return new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
    }
#endif
}