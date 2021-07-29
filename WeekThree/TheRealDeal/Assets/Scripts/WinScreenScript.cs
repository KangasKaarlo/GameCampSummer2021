using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenScript : MonoBehaviour
{
    public Boss Boss;
    public Text pointsText;
    public Text grade;
    public GameObject scoreScript;
    public GameObject winScreen;
    void start() {

    }
    void Update()
    {
        pointsText.text = ScoreScript.scoreValue + " POINTS! ";
        if (ScoreScript.scoreValue > 300000)
        {
            grade.text = "A+";
        }
        else if (ScoreScript.scoreValue > 250000)
        {
            grade.text = "A";
        }
        else if (ScoreScript.scoreValue > 200000)
        {
            grade.text = "B";
        }
        else if (ScoreScript.scoreValue > 150000)
        {
            grade.text = "C";
        }
        else
        {
            grade.text = "D";
        }
    }
}
