using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * _velocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * _velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}