using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text ScoreText;
    public Text LivesText;

    private int score = 0;
    private int lives = 3;

    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
        LivesText.text = $"LIVES: {lives}";
    }

    public void IncreaseScore() {
        score++;
    }

    public void DecreaseLifes() {
        lives--;
        if (lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
