using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    private static GamePlay _instance;
    public static GamePlay Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("GamePlay");
                _instance = go.AddComponent<GamePlay>();
            }

            return _instance;
        }
    }
    
    private IBallController _ball;
    private IPlayerController _player;

    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GetReadyLabel;

    public uint Score = 0;
    private uint _lives;
    public uint Lives {
        get => _lives;
        set => _lives = value;
    }

    uint Briks = 4;
    private bool _gameOver = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // NOTE: this is a workaround only while GamePlay is not injected.
        Zenject.SceneContext context = FindObjectOfType<Zenject.SceneContext>();
        _ball = context.Container.Resolve<IBallController>(); 
        IGameConfig config = context.Container.Resolve<IGameConfig>();
        _player = context.Container.Resolve<IPlayerController>();

        SetupGame(config);
    }

    public void Goal()
    {
        GetReadyLabel.enabled = true;
        
        var pos1 = _player.GetPlayerPosition();
        pos1.x = 0f;
        _player.SetPlayerPosition(pos1);

        _ball.SetPosition(Vector3.zero);
        _ball.SetVelocity(Vector2.zero);

        ScoreLabel.text = GamePlay.Instance.Score.ToString();
        LivesLabel.text = GamePlay.Instance._lives.ToString();

        StartCoroutine(StartGame());
    }

    private void SetupGame(IGameConfig config)
    {
        Score = 0;
        _lives = config.Lives;
        Briks = 4;

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);

        GetReadyLabel.enabled = false;
        _gameOver = false;
        _ball.Kick();
    }

    private void Update()
    {
#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _lives = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Score = Briks;
        }
#endif

        if (_gameOver) return;

        ScoreLabel.text = GamePlay.Instance.Score.ToString();
        LivesLabel.text = GamePlay.Instance._lives.ToString();

        if (Score == Briks)
        {
            SceneManager.LoadScene("Win");
            _gameOver = true;
        }
        else if (_lives == 0)
        {
            SceneManager.LoadScene("Lose");
            _gameOver = true;
        }
    }
}