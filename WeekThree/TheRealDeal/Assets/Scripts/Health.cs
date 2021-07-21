using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public int health;
    public GamePlay main;
    public int health;
    public int numOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    //public GamePlay playerhealth;
    public GameObject mainCamera;
    void Start()
    {
        main = mainCamera.GetComponent<GamePlay>();
        
    }
    void Update()
    {
        health = main.playerHealth;
        for (int i =0; i<hearts.Length; i++ ){
            if (i<health){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }
            if(i<numOfHearts) {
                hearts[i].enabled = true;
            }else {
                hearts[i].enabled = false;
            }
        } 
    }
}

