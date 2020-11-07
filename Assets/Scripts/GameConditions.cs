using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditions : MonoBehaviour
{
    public GameObject LosePanel;

    private void Update()
    {
        if (GlobalVar.IsLose) // Проверка на поражение
        {
            LosePanel.SetActive(true);
        }
    }
}
