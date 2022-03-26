using System;
using UnityEngine;

public class BallPresenter : MonoBehaviour, IBallRigidbodyGetter, IBallPositioner, IBallCollisionListener
{
    [SerializeField] private Rigidbody2D _ball;
    public Rigidbody2D Ball => _ball;

    public Vector3 Position {
        get => gameObject.transform.position;
        set => gameObject.transform.position = value;
    }

    private Action<Collision2D> _onCollisionWithBrick;
    public Action<Collision2D> OnCollisionWithBrick {
        get => _onCollisionWithBrick;
        set => _onCollisionWithBrick = value;
    }

    private Action<Collision2D> _onCollisionWithDeathplane;
    public Action<Collision2D> OnCollisionWithDeathplane {
        get => _onCollisionWithDeathplane;
        set => _onCollisionWithDeathplane = value;
    }
}