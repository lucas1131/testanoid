using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Range(0.1f, 5f)] public float ballSpeed = 1f;
    public uint lives = 3;
    // [range(0f, 5f)] public float minStartingAngle = 0f;
    // public float maxStartingAngle = 0f;
}
