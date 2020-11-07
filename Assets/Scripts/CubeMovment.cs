using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeMovment : MonoBehaviour
{
    [Header("Персонаж")] public GameObject PlayerCube; // Игровой объект персонажа

    [Header("Настройки передвижения:")] [Header("Позиция X для куба (ограничитель)")]
    public float positionX = 0;

    [Header("Скорость перемещения")] public float speed; // Скорость перемещения куба за машкойэ

    public Vector2 min;
    public Vector2 max;
    void Start (){
        // границы екрана
        min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
    }
    /// <summary>
    /// Метод перевижения куба
    /// </summary>
    private void Move()
    {
        if (Camera.main != null) // Проверка есть ли камера
        {
           var mp = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Позиция курсора
           
                
                PlayerCube.transform.position = Vector2.Lerp(new Vector2(positionX, PlayerCube.transform.position.y),
                    new Vector2(positionX, mp.y),
                    Time.deltaTime * speed); // Перемещение куюа к позиции курсора mp со скростью speed
            
        }
    }

    private void FixedUpdate()
    {
        Move(); // Запуск прередвжиние куба
    }
}