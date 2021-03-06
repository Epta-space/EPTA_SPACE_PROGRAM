using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial_Background_handler : MonoBehaviour
{  
    // Algumas variáveis importantes
    private GameObject manager_object;

    // Tempo para a destruição da tela (segundos)
    public float tempo_destruir;

    // Button animator
    public Animator buttom_animator;

    void Start()
    {   
        manager_object = GameObject.FindWithTag("Game_manager");
 
    }

    public void launch_button()
    {

        // toca a animação do botão
        buttom_animator.SetBool("start_game", true);

        // Makes the screen fall
        this.gameObject.GetComponent<Gravity_Backyground_Initial>().Start_fall();

        // Destrói tela depois de algum tempo
        InvokeRepeating("fall_ui",1f,1f);

        // Inicia fase no game handler
        // TODO

    }

    public void fall_ui()
    {
        float time = manager_object.GetComponent<Game_Manager>().Get_phase_time();
        if (time > tempo_destruir)
        {
            Destroy(this.gameObject);
        }
    }  
}
