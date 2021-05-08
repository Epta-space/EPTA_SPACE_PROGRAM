using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colide_handler : MonoBehaviour
{
    // Vetor de obstáculos
    private List<string> obstacle_list = new List<string>{"Nuv_1_0", "Nuv_1_1", "Nuv_3_0", "Balao"  , "Alien"  , "Met_1", "Met_2"  , "Met_3"  , "Sat_1", "Sat_2"  , "Sat_3"};

    // Game manager reference
    private GameObject Game_manager;

    // Função chamada no início do jogo
    void Start()
    {
        // Acha o script game manager via tag
        Game_manager = GameObject.FindWithTag("Game_manager");
        
    }

    // No momento em que ocorre a colisão ele chama essa função
    void OnCollisionEnter2D(Collision2D objeto_alvo)
    {
        // Calcula dados sobre a colisão
        float x_offset = this.gameObject.transform.position.x - objeto_alvo.gameObject.transform.position.x;
        float y_offset = this.gameObject.transform.position.y - objeto_alvo.gameObject.transform.position.y;

        // Chama o gerenciador de colisões
        ColisorHandler(objeto_alvo.gameObject.tag, x_offset, y_offset);
    }

    private void ColisorHandler(string colidido, float x_offset, float y_offset){
        if(obstacle_list.Contains(colidido)){

            if (y_offset < -0.8){
                // Chama a função de fim de jogo
                // player está abaixo de obstáculo
                Game_manager.GetComponent<Game_Manager>().Terminar_jogo(0);
            } else {
                if (x_offset < 0){
                    // Chama a função de fim de jogo
                    // player está acima e a esquerda do obstáculo
                    Game_manager.GetComponent<Game_Manager>().Terminar_jogo(1);
                } else {
                    // Chama a função de fim de jogo
                    // player está acima e a direita do obstáculo
                    Game_manager.GetComponent<Game_Manager>().Terminar_jogo(2);
                }
            }
        }
    }
}
