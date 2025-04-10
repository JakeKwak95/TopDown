using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameEndText;

    public Image healthBar;

    public void UpdateScore(int winScore, int current)
    {
        current = Mathf.Min(winScore, current);
        scoreText.text = current + "/" + winScore;
    }

    public void ShowOnGameEnd(bool isWin)
    {
        if (isWin)
        {
            gameEndText.color = Color.green;
            gameEndText.text = "You Win!";
        }
        else
        {
            gameEndText.color = Color.red;
            gameEndText.text = "You Lose!";
        }

        gameEndText.gameObject.SetActive(true);
    }

    public void UpdateHealthBar(int max, int current)
    {
        healthBar.fillAmount = (float)current / max;
    }
}
