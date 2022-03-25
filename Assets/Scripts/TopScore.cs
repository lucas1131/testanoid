using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text Label;
    
    private void Awake()
    {
        Label.text += GamePlay.Instance.Score.ToString();
    }
}