using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public int score;
    public Text hiScore;
    bool loadFound;
    private void Start()
    {
        LoadGame();  
    }
    public void Play()
    {   
        SceneManager.LoadScene("DoodleGameplay");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Reset()
    {
        ResetData();
        LoadGame();
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            score = PlayerPrefs.GetInt("SavedInteger");
            Debug.Log("Game data loaded!");
            hiScore.text = "YOUR HI-SCORE: " + score;
        }
        else
        {
            Debug.LogError("There is no save data!");
            hiScore.text = "YOUR HI-SCORE: 0";
        }

    }
    void ResetData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Data reset complete");
    }
}
