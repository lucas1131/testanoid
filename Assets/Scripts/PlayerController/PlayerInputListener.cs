using System;
using UnityEngine;
using Zenject;

public class PlayerInputListener : MonoBehaviour, IPlayerInputListener
{
	private Action<Vector2> _onMovementDirectionChanged;
	public Action<Vector2> OnMovementDirectionChanged {
		get => _onMovementDirectionChanged;
		set => _onMovementDirectionChanged = value;
	}

	private Vector2 moveDirection;
	private Vector2 MoveDirection
	{
		get => moveDirection;
		set {
			if(moveDirection != value && _onMovementDirectionChanged != null)
			{
				_onMovementDirectionChanged(value);
			}
			moveDirection = value;
		}
	}

#if true // For Debug commands to work

	private IGamePlay _gamePlay;

	[Inject]
	private void Construct(IGamePlay gamePlay)
	{
		_gamePlay = gamePlay;
	}

#endif
   
	private void Start()
	{
		moveDirection = Vector2.zero;
	}

	private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveDirection = Vector2.right;
        }
        else
        {
            MoveDirection = Vector2.zero;
        }

#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gamePlay.Lose();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _gamePlay.Win();
        }
#endif
    }
}