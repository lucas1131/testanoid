using UnityEngine;

public class BrikController : MonoBehaviour
{    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var game = GamePlay.Instance;
        game.Score++;
        Destroy(gameObject);
    }
}