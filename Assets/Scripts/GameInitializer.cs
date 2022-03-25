using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
	[SerializeField] private GameConfig _gameConfig;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        	StartGame();
            
        }
    }

    private void StartGame()
    {
    	SceneManager.LoadScene("Gameplay");
    }
}
