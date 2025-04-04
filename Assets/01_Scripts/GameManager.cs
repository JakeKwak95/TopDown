using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int winScore = 10;
    int currentScore;

    public bool isGameStarted = true;

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

    public void OnEnemyDie()
    {
        currentScore++;
        if (currentScore >= winScore)
        {
            OnWin();
        }
    }

    public void OnWin()
    {
        Debug.Log("You win!");
        isGameStarted = false;
    }

    public void OnLose()
    {
        Debug.Log("You lose!");
        isGameStarted = false;
    }
}
