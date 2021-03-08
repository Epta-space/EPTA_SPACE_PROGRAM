using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_background_handler : MonoBehaviour
{
    // Global variables declaration

    // Nuvens:
    public GameObject nuvens;
    public float nuvens_velocity;
    
    // Estrelas:
    public GameObject estrelas;
    
    // Fundo azul:
    public GameObject fundo_azul;

    private GameObject manager_object;
    
    // Start is called before the first frame update
    void Start()
    {
        manager_object = GameObject.FindWithTag("Game_manager");
        InvokeRepeating("checa_estado_jogo",0f,0.2f);
    }

    // Checa estado do jogo 
    private void checa_estado_jogo()
    {
        if (manager_object.GetComponent<Game_Manager>().Get_phase() > 0){
            nuvens.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - nuvens_velocity);
        }
    }

}
