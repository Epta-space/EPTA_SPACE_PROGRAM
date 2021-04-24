using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marcador_score : MonoBehaviour
{
    private GameObject score_text;
    private Text texto;
    private float score ;
   
  

    private void Start()
    {
        score_text = GameObject.FindWithTag("Score");
        texto = score_text.GetComponent<Text>();
        score = float.Parse(PlayerPrefs.GetString("save_score_endereço"));

    }
    public void recorde()
    {
        

        if(float.Parse(PlayerPrefs.GetString("save_score_endereço")) > score)
        {
            score = float.Parse(PlayerPrefs.GetString("save_score_endereço"));

            if (score < 1000)
            {
                texto.text = score.ToString("00") + " m  ";
            }
            else
            {
                texto.text = (score / 1000).ToString("00") + " km  ";
            }
        }
        


        
    }
}
