using System;
using UnityEngine;

public class PlayerPresenter : MonoBehaviour, IPlayerRigidbodyGetter, IPlayerPositioner, IPlayerCollisionListener
{
    [SerializeField] private Rigidbody2D _player;
    public Rigidbody2D Player => _player;
    private Transform playerSpawnPoint;

    public Vector3 Position {
        get => gameObject.transform.position;
        set => gameObject.transform.position = value;
    }

    private Action<Collision2D> onPlayerCollisionEnter;
    public Action<Collision2D> OnPlayerCollisionEnter {
        get => onPlayerCollisionEnter;
        set => onPlayerCollisionEnter = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if(collision.gameObject.CompareTag("WALL")) 
        {
            _player.velocity = Vector2.zero;
        }
    }
}