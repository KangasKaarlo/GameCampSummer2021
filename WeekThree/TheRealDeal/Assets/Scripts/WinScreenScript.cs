using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenScript : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text=score.ToString() + " POINTS!";
    }
    
}
