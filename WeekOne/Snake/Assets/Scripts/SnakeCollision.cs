using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    public Snake snake;
    
    private void Start()
    {
        snake = Camera.main.GetComponent<Snake>();
    }
private void OnTriggerEnter2D(Collider2D apple) {
    Debug.Log("hit");
    //snake.GrowSnake();
    snake.MoveFood();        
}
    
}
