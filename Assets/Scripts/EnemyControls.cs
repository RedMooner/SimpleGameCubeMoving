using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    [HideInInspector]
    public Vector2 direction; // куда будет перемещение
    [HideInInspector]
    public float speed; // Скорость
    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime)); // перемешение объекта в лево
      
    }
/// <summary>
/// Метод для отслеживания соприкосновения с игроком
/// </summary>
/// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") // Проверка на спорикосновение с игроком
        {
            // Lose
            Destroy(other.gameObject);
            Time.timeScale = 0;
            GlobalVar.IsLose = true;
        }
        if (other.gameObject.tag == "Wall") // Проверка на спорикосновение с игроком
        {
            // Lose
    
            Destroy(gameObject);
      
        }
    }
}
