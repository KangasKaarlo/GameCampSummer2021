using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenScript : MonoBehaviour
{
    public Boss Boss;
    public Text pointsText;
    public ScoreScript scoreScript;
    public GameObject winScreen;
    /*void start() {
        //winScreen.SetActive(false);
    }
    void Update() 
    {
       Setup();
    }*/
    public void Setup() {
        //if(Boss.doneExploding == !true){
            winScreen.SetActive(true);
            Debug.Log("E");

        pointsText.text=ScoreScript.scoreValue.ToString() + " POINTS!";
        
        //}

        
    }
    
    
}
