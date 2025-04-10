using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int winScore = 10;
    int currentScore;

    public bool isGameStarted = true;

    public HUDManager hudManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hudManager.UpdateScore(winScore, currentScore);
    }

    public void GameStart()
    {
        isGameStarted = true;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnEnemyDie()
    {
        currentScore++;
        hudManager.UpdateScore(winScore, currentScore);

        if (currentScore >= winScore)
        {
            OnWin();
        }
    }

    public void OnWin()
    {
        hudManager.ShowOnGameEnd(true);
        isGameStarted = false;
    }

    public void OnLose()
    {
        hudManager.ShowOnGameEnd(false);
        isGameStarted = false;
    }
}
