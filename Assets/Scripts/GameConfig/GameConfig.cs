using UnityEngine;

[CreateAssetMenu(fileName="GameConfig")]
[ExecuteInEditMode]
public class GameConfig : ScriptableObject, IGameConfig
{
    [SerializeField] [Range(3f, 8f)] private float _ballMaxSpeed = 5f;
    [SerializeField] [Range(3f, 8f)] private float _ballMinSpeed = 5f;
    [SerializeField] [Range(3f, 8f)] private float _playerSpeed = 5f;
    [SerializeField] private uint _lives = 3;

    public float BallMaxSpeed => _ballMaxSpeed;
    public float BallMinSpeed => _ballMinSpeed;
    public float PlayerSpeed => _playerSpeed;
    public uint Lives => _lives;

    private void OnValidate()
    {
    	if(_ballMinSpeed > _ballMaxSpeed)
    	{
    		_ballMinSpeed = _ballMaxSpeed;
    	}
    }
}
