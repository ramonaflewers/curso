using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int scoreLeft = 0;
    public int scoreRight = 0;
    public int winPoints = 3;

    public TMP_Text winnerText;
    public TMP_Text scoreLeftText;
    public TMP_Text scoreRightText;
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public Transform paddleLeft;
    public Transform paddleRight;
    public ballController ball;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        if (screenEndGame != null)
            screenEndGame.SetActive(false);
    }


    public void AddPointToLeft()
    {
        scoreLeft++;
        UpdateScoreUI();
        CheckWin();
    }

    public void AddPointToRight()
    {
        scoreRight++;
        UpdateScoreUI();
        CheckWin();
    }

    void UpdateScoreUI()
    {
        if (scoreLeftText != null)
            scoreLeftText.text = scoreLeft.ToString();
        if (scoreRightText != null)
            scoreRightText.text = scoreRight.ToString();
    }

    void CheckWin()
    {
        if (scoreLeft >= winPoints || scoreRight >= winPoints)
        {
            EndGame();
        }
        else
        {
            ball.ResetBall();
        }
    }

    void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = saveController.instance.GetName(scoreLeft < scoreRight);
        textEndGame.text = "Parabéns " + winner+"!";
        saveController.instance.SavedWinner(winner);

        Invoke("LoadMenu", 3f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void ResetGame()
    {
        scoreLeft = 0;
        scoreRight = 0;
        UpdateScoreUI();

        screenEndGame.SetActive(false);
        ball.enabled = true;

        if (paddleLeft != null)
            paddleLeft.position = new Vector2(-8, 0);
        if (paddleRight != null)
            paddleRight.position = new Vector2(8, 0);

        ball.ResetBall();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
