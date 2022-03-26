using UnityEngine;

public interface IPlayerController
{
    void Move(Vector2 direction);
    Vector3 GetPlayerPosition();
    void SetPlayerPosition(Vector3 position);
}
