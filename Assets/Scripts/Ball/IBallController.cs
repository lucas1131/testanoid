using UnityEngine;

public interface IBallController
{
    void Kick();
    void SetVelocity(Vector2 velocity);
    void SetPosition(Vector2 position);
}
