using System;
using UnityEngine;

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
   
	private void Start()
	{
		moveDirection = Vector2.zero;
	}

	private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
        	Debug.LogWarning("[Update] Input left");
            MoveDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
        	Debug.LogWarning("[Update] Input right");
            MoveDirection = Vector2.right;
        }
        else
        {
        	Debug.LogWarning("[Update] Input zero");
            MoveDirection = Vector2.zero;
        }
    }
}