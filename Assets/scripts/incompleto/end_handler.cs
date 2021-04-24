using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_handler : MonoBehaviour
{
    // Game object onde o game manager está
    private GameObject manager_object;

    // Game object onde o save options está
    private GameObject save_options;

    // Game object onde se cuida dos menus
    private GameObject script_UI;

    private GameObject record_script;

    void Start()
    {
        // acha game manager com tag
        manager_object = GameObject.FindWithTag("Game_manager");

        // acha script handler com tag
        script_UI = GameObject.FindWithTag("interface_handler");

        // pega save options com via função do game manager
        save_options = manager_object.GetComponent<Game_Manager>().Get_save_options();


        //record_script = manager_object.GetComponent<marcador_score>();

    }

    // Função para terminar o jogo
    public void End_Game()
    {
        Call_Save();
        Disable_player_input_colision_engine();
        Disable_general_ui();
        Explode_player();
        Stop_time();
        ShowAdd();
        Call_End_Screen();
       
    }

    // Save Score
    private void Call_Save()
    {
        // Get the score value from the player
        float score = manager_object.GetComponent<Game_Manager>().Get_height();
        
        
            save_options.GetComponent<save>().salvar(score.ToString(), "save_score_endereço");
           
        
    }

    // Disable user input
    private void Disable_player_input_colision_engine()
    {
        // player
        GameObject player = manager_object.GetComponent<Game_Manager>().Get_player();

        //desabilita boleana do input la no scrip movimento
        player.GetComponent<movimentação>().desativar_input();

        // Desliga som do motor
        player.GetComponent<movimentação>().Desligar_som_do_motor();

        //desabilita movimentos
        player.GetComponent<movimentação>().Freeze_player_y();

        //desabilita colisão
        player.GetComponent<PolygonCollider2D>().enabled = false;

    }

    //! Disable general UI
    private void Disable_general_ui()
    {
        GameObject Basic_UI = script_UI.GetComponent<interface_handler>().Get_basic_ui();

        // Desabilitar interface de usuário
        Basic_UI.SetActive(false);
    }

    // Change Player sprite to explosion
    private void Explode_player()
    {

        // player
        GameObject player = manager_object.GetComponent<Game_Manager>().Get_player();

        //desabilita boleana do input la no scrip movimento
        player.GetComponent<movimentação>().End_player();
    }

    //! Stop time in a good manner
    private void Stop_time()
    {
        Time.timeScale = 0f;
    }

    // Show Intersticial add
    private void ShowAdd()
    {
        //TODO: Implement the add 
    }

    // Show End screen menu
    private void Call_End_Screen()
    {
        GameObject End_UI = script_UI.GetComponent<interface_handler>().Get_end_ui();

        // Desabilitar interface de usuário
        End_UI.SetActive(true);
    }

}
