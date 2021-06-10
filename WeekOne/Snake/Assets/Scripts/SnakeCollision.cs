using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    public Snake snake;
    public Texture2D myTexture;
    public AudioSource eatingSound;
    private void Start()
    {
        snake = Camera.main.GetComponent<Snake>();
        snake.MoveFood();
    }
    private void OnTriggerEnter2D(Collider2D apple) {
        snake.GrowSnake();
        snake.MoveFood();
        eatingSound.Play();
    }
}
