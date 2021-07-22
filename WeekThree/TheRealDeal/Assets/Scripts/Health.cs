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
    public Image[] bombs;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int numOfBombs = 1;
    public Sprite bombSprite;
    public Sprite noBombSprite;
    
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
        
        /*for (int i =0; i<bombs.Length; i++ ){
            if (i<main.bombCount){
                bombs[i].sprite = bombSprite;
            } else {
                bombs[i].sprite = noBombSprite;
            }
            if(i<numOfBombs) {
                bombs[i].enabled = true;
            }else {
                bombs[i].enabled = false;
            }
        }*/
        for (int i =0; i<bombs.Length; i++ ){
        if (main.bombCount == 0)
        {
            bombs[i].sprite = noBombSprite;

        } else {
            bombs[i].sprite = bombSprite;
        }
        }
        
    }
}

