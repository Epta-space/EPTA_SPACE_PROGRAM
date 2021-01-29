using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class save : MonoBehaviour
{
    
    public static string endereço; // endereço na memoria
    public static float Float; // save interno
    public static string verifica_valor_que_sera_salvo; // valor que sera setado em outro script;
    public float valor; // save interno
   
    
    
    public void salvar()
    {
        bool ehValido = verifica_valor_que_sera_salvo.Length == 30 && verifica_valor_que_sera_salvo.All(char.IsDigit); // verifica se a string é numero ou não
        if (ehValido) // se for usa um PlayerPrefs para float 
        {
            valor = float.Parse(verifica_valor_que_sera_salvo);

           PlayerPrefs.SetFloat(endereço,valor);
        }
        else // caso contrario PlayerPrefs para string
        {

            PlayerPrefs.SetString(endereço, verifica_valor_que_sera_salvo);
        }

        // o endereço deve ser setado sempre (como serão endereços diferentes nao a problemas de sobreposição )
       
    }
    
    

}
