using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void sair()
    {
        Application.Quit();
    }
}
