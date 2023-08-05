using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI highScoreText;
    public static int lastScore = 0;
    public static int highScore = 0; // En yüksek skor
    private const string HIGH_SCORE_KEY = "HighScore"; // PlayerPrefs için anahtar

    private void Start()
    {
        // Yüksek skoru PlayerPref'ten al
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    public void ScoreUp()
    {
        scoreText.text = Fly.score.ToString();
        lastScore = Fly.score;
        lastScoreText.text = Score.lastScore.ToString();

        // Eğer son skor, mevcut high score'dan büyükse güncelle ve kaydet
        if (lastScore > highScore)
        {
            highScore = lastScore;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    
        
}