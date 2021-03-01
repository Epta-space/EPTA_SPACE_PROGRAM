using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{

    public void salvar(string entrada, string endereço)
    {
        PlayerPrefs.SetString(endereço, entrada);
        // o endereço deve ser setado sempre (como serão endereços diferentes nao a problemas de sobreposição )

    }

    // retorna os (valores ou textos) salvos em forma de string.
    public string retornar_save(string endereço)  
    {
        //GetString garante que o será em string.
        return PlayerPrefs.GetString(endereço); 
    }

    // Checa se há algum valor salvo na memória neste endereço
    public bool existe_valor(string endereço)  
    {
        // Função de checagem
        return PlayerPrefs.HasKey(endereço); 
    }
}
