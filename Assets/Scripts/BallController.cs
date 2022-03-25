using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f; // TODO: add config obj
    private Rigidbody2D rb;
    
    public void Kick()
    {
        rb.velocity = Random.insideUnitCircle * Speed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * Speed;
    }
}