using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_background_handler : MonoBehaviour
{
    // Global variables declaration

    // Nuvens:
    public GameObject nuvens_old;
    public GameObject blue_background;
    public GameObject nuvens_new_foreground;
    public GameObject nuvens_new_background_1;
    public GameObject nuvens_new_background_2;
    
    // Estrelas:
    public GameObject black_background;
    public GameObject estrelas;
    
    // Game manager:
    private GameObject manager_object;

    // Cores
    private float blue_background_alpha;
    
    // Start is called before the first frame update
    void Start()
    {
        manager_object = GameObject.FindWithTag("Game_manager");
        InvokeRepeating("checa_estado_jogo",0f,0.1f);
    }

    // Checa estado do jogo 
    private void checa_estado_jogo()
    {
        // Phase info
        int stage = manager_object.GetComponent<Game_Manager>().Get_phase();
        float fraction = manager_object.GetComponent<Game_Manager>().Get_phase_fraction();

        // Color info
        Color final = blue_background.GetComponent<SpriteRenderer>().material.color;

        // Definições por fase
        switch(stage){
        case 1:
            // Configurando as nuvens brancas
            float phase_end = manager_object.GetComponent<Game_Manager>().Get_phase_all_time();
            nuvens_old.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - 1.2f * 10.0f/phase_end);

            // Configurando as nuvens da base
            nuvens_new_background_1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - 0.6f);
            nuvens_new_background_2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - 1.2f);
            break;
        case 2:
            // Cor do ceu azul
            estrelas.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - 0.5f);
            final.a = (1.0f - Mathf.Sqrt(fraction)); 
            blue_background.GetComponent<SpriteRenderer>().material.color = final;
            break;
        case 3:
            break;
        default:
            break;
        }
    }

}
