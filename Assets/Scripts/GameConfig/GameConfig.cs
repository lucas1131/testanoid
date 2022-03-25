using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig")]
[ExecuteInEditMode]
public class GameConfig : ScriptableObject, IGameConfig
{
    [SerializeField] [Range(1f, 10f)] private float _ballSpeed = 5f;
    [SerializeField] [Range(1f, 10f)] private float _playerSpeed = 5f;
    [SerializeField] private uint _lives = 3;

    public float BallSpeed => _ballSpeed;
    public float PlayerSpeed => _playerSpeed;
    public uint Lives => _lives;

}
