using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tela_morte : MonoBehaviour
{
    public GameObject tela;
    void Start()
    {
        tela.SetActive(false);
    }

    public void tela_morte_ativar()
    {
        tela.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void continuar()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void sair()
    {
        Application.Quit();
    }
}
