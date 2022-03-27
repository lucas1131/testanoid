using System;
using UnityEngine;

public class BallPresenter : MonoBehaviour, IBallRigidbodyGetter, IBallPositioner
{
    [SerializeField] private Rigidbody2D _ball;
    public Rigidbody2D Ball => _ball;

    public Vector3 Position 
    {
        get => gameObject.transform.position;
        set => gameObject.transform.position = value;
    }
    
    public Vector3 TransformDirection(Vector3 direction)
    {
        return gameObject.transform.TransformDirection(direction.normalized);
    }
}