using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public TileBoard board;
    public CanvasGroup gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;

    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        SetScore(0);
        HighScoreText.text = LoadHighScore().ToString();
        gameOver.alpha = 0;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;
        StartCoroutine(Fade(gameOver,1,1));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from,to,elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(Score + points);
    }

    private void SetScore(int score)
    {
        this.Score = score;
        scoreText.text = score.ToString();

        SaveHighScore();
    }

    private void SaveHighScore()
    {
        int hiscore = LoadHighScore();
        if(Score > hiscore)
        {
            PlayerPrefs.SetInt("highscore",Score);
        }
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("highscore",0);
    }
}
