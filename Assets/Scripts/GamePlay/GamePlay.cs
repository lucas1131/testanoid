﻿using System.Collections;
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
    
    public IBallController Ball;
    public PlayerController Player;

    public Text ScoreLabel;
    public Text LivesLabel;
    public Text GetReadyLabel;

    public uint Score = 0;
    public uint Lives = 3; // TODO: add config obj

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
        Zenject.SceneContext context = FindObjectOfType<Zenject.SceneContext>()
        Ball = context.Container.Resolve<IBallController>(); // NOTE: this is a workaround only while GamePlay is not injected.
        Reset();
    }

    public void Goal()
    {
        GetReadyLabel.enabled = true;
        var pos1 = Player.transform.position;
        pos1.x = 0f;
        Player.transform.position = pos1;

        Ball.SetPosition(Vector3.zero);
        Ball.SetVelocity(Vector2.zero);

        ScoreLabel.text = GamePlay.Instance.Score.ToString();
        LivesLabel.text = GamePlay.Instance.Lives.ToString();

        StartCoroutine(StartGame());
    }

    private void Reset()
    {
        Score = 0;
        Lives = 3;
        Briks = 4;

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);

        GetReadyLabel.enabled = false;
        _gameOver = false;
        Ball.Kick();
    }

    private void Update()
    {
#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Lives = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Score = Briks;
        }
#endif

        if (_gameOver) return;

        ScoreLabel.text = GamePlay.Instance.Score.ToString();
        LivesLabel.text = GamePlay.Instance.Lives.ToString();

        if (Score == Briks)
        {
            SceneManager.LoadScene("Win");
            _gameOver = true;
        }
        else if (Lives == 0)
        {
            SceneManager.LoadScene("Lose");
            _gameOver = true;
        }
    }
}