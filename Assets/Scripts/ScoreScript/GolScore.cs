using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolScore : MonoBehaviour
{
    public Text myscoreText;
    public Text highscoretext;
    public int scoreNum;

    public int highscore = 0;
    string highScoreKey = "HighScore";

    private void Start()
    {
        scoreNum = 0;
        myscoreText.text = "" + scoreNum;
        highscore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void Update()
    {
        highscoretext.text = "Highscore: " + highscore;
        if (highscore < scoreNum)
        {
            PlayerPrefs.SetInt(highScoreKey, (int)scoreNum);
            PlayerPrefs.Save();
        }
    }
}
