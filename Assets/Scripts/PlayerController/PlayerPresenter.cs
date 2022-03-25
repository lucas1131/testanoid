using UnityEngine;

public class PlayerPresenter : MonoBehaviour, IPlayerRigidbodyGetter, IPlayerPositioner
{
    [SerializeField] private Rigidbody2D _player;
    public Rigidbody2D Player => _player;
    private Transform playerSpawnPoint;

    public Vector3 Position {
        get => gameObject.transform.position;
        set => gameObject.transform.position = value;
    }
}