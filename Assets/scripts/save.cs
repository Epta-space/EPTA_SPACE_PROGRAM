using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class save : MonoBehaviour
{
    
    private static string endereço; // endereço na memoria
    private float valor_float; // save interno
    private int valor_int;



    public void salvar(object entrada)
    {
        Type tipo = entrada.GetType();

        if(tipo.Equals(typeof(string)))
        {
            layerPrefs.SetString(endereço, entrada);
        }

        if (tipo.Equals(typeof(int)))
        {
            valor_int = int.Parse(entrada);
            PlayerPrefs.SetInt(endereço, valor_int);
        }

        if (tipo.Equals(typeof(float)))
        {
            valor_float = float.Parse(entrada);
            PlayerPrefs.SetFloat(endereço, valor_float);
        }

        // o endereço deve ser setado sempre (como serão endereços diferentes nao a problemas de sobreposição )

    }
    
    

}
