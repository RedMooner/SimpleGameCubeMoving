using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   public Text ScoreText;
   public Text ScoreTextLose;
   private void Update()
   {
      if (!GlobalVar.IsLose)
      {
         ScoreText.text = "Score: " + GlobalVar.Score.ToString(); // Добавление очокв
      }else{
        ScoreTextLose.text = "Your Score: " + GlobalVar.Score.ToString(); // Добавление очокв
      }
   }
}
