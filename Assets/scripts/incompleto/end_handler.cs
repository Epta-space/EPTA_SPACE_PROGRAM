using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_handler : MonoBehaviour
{
    // Game object onde o game manager está
    private GameObject manager_object;

    // Game object onde o save options está
    private GameObject save_options;

    // Game object onde estão os controles de som
    private GameObject sound_control;

    // Game object onde se cuida dos menus
    private GameObject script_UI;

    void Start()
    {
        // acha game manager com tag
        manager_object = GameObject.FindWithTag("Game_manager");

        // acha script handler com tag
        script_UI = GameObject.FindWithTag("interface_handler");

        // gerenciador de sons, para ativar o som da explosão
        sound_control = GameObject.FindWithTag("audio_control");

        // pega save options com via função do game manager
        save_options = manager_object.GetComponent<Game_Manager>().Get_save_options();

    }

    // Função para terminar o jogo
    public void End_Game(int modo_de_termino)
    {
        Call_Save();
        Disable_player_input_colision_engine();
        Disable_general_ui();
        Explode_player(modo_de_termino);
        Stop_time();
        ShowAdd();
        StartCoroutine(Restart_match());
    }

    // Save Score
    private void Call_Save()
    {
        // Get the score value from the player
        float score = manager_object.GetComponent<Game_Manager>().Get_height();

        if (save_options.GetComponent<save>().existe_valor("save_score_endereço") ) {
            if (float.Parse(save_options.GetComponent<save>().retornar_save("save_score_endereço")) < score) {
                // Save the score value in memory
                save_options.GetComponent<save>().salvar(score.ToString(), "save_score_endereço");
            } 
        } else {
            // Save the score value in memory
            save_options.GetComponent<save>().salvar(score.ToString(), "save_score_endereço");
        }
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
    private void Explode_player(int explosion_type)
    {

        // player
        GameObject player = manager_object.GetComponent<Game_Manager>().Get_player();

        //desabilita boleana do input la no scrip movimento
        player.GetComponent<movimentação>().End_player(explosion_type);

        // Habilita o som da explosão
        sound_control.GetComponent<audio_controls>().explosao();
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

    // Restart the scene
    IEnumerator Restart_match()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Player");
    }

}
