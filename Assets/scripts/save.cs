using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class save : MonoBehaviour
{
    
   
    



    public void salvar(object entrada, string endereço)
    {
        Type tipo = entrada.GetType();

        if(tipo.Equals(typeof(string)))
        {
            PlayerPrefs.SetString(endereço, entrada);
        }

        if (tipo.Equals(typeof(int)))
        {
            
            PlayerPrefs.SetInt(endereço, entrada);
        }

        if (tipo.Equals(typeof(float)))
        {
            
            PlayerPrefs.SetFloat(endereço, entrada);
        }

        // o endereço deve ser setado sempre (como serão endereços diferentes nao a problemas de sobreposição )

    }
    
    

}
