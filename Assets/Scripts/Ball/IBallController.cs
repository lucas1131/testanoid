using UnityEngine;

public interface IBallController
{
    void Kick();
    void Move();
    void SetVelocity(Vector2 velocity);
    void SetPosition(Vector2 position);
}
