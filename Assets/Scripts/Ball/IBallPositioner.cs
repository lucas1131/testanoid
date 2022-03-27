using UnityEngine;

public interface IBallPositioner
{
    Vector3 Position { get; set; }
    Vector3 TransformDirection(Vector3 direction);
}