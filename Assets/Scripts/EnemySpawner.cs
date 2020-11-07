using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour

{
    private readonly Vector2 _direction = new Vector2(-1,0); // Куда нужно перемещаться препядствию в нашем случае по x в -1
    [FormerlySerializedAs("MaxPosY")] public float maxPosY = 3.82f; // Нужно для рандома появления препядсвтий ( это максимальная координата для спавна по оси Y)
    [FormerlySerializedAs("MinPosY")] public float minPosY = -4.07f;// Нужно для рандома появления препядсвтий ( это минимальная координата для спавна по оси Y)
    [FormerlySerializedAs("PosX")] public float posX = 6.63f; // Ограничитель позиции X т.е откуда полетит препядсвтие
    public float duration = 2f; // Значение в секундах( таймер в течении которого будут спавнится объекьы) по умолчанию - 2 секунды
    public Enemy[] enemies; // Массив Препядсвтий
    
    private void Start()
    {
        StartCoroutine(SpawnCoroutine()); // Запуск куротины спавнера
    }
    /// <summary>
    /// Спавнер
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnCoroutine() 
    {
        while (true)
        {
            var enemy_type = Random.Range(0, enemies.Length);
            var enemy= Instantiate(enemies[enemy_type].prefab); // создаем препядсвтие на сцене
            var y =  Random.Range(maxPosY , minPosY); // Гереация координат пр Y (где заспавнится объект)
            enemy.transform.position = new Vector3(posX , y);  // Задание координат спавна
            enemy.GetComponent<EnemyControls>().direction = _direction; // Задание движения в справа на лево
            enemy.GetComponent<EnemyControls>().speed = enemies[enemy_type].speed; // Задача скрости 
            GlobalVar.Score += enemies[enemy_type].score;
            yield return new WaitForSeconds(duration);   // Создание таймера с задержкой 
        }
       
        
    }
    [Serializable]
    public class Enemy // Класс Врагов 
    {
        [Header("Имя")]
        [FormerlySerializedAs("Name")] public string name; // Имя врага 
        [FormerlySerializedAs("Speed")] public float speed; // Скрорость
        [FormerlySerializedAs("Prefab")] public GameObject prefab;// Префаб
        [FormerlySerializedAs("Score")] public int score;// Сколько дадут за врага
    }
}
