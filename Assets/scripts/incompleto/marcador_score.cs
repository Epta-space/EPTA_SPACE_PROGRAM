using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marcador_score : MonoBehaviour
{
    private GameObject score_text;
    private Text texto;
    private float score,score_atual;
    private string string_score;

    private void Start()
    {
        score_text = GameObject.FindWithTag("Score");
        texto = score_text.GetComponent<Text>();
    }
    void Update()
    {
        string_score = PlayerPrefs.GetString("save_score_endereço");

        score = float.Parse(string_score);

        

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
