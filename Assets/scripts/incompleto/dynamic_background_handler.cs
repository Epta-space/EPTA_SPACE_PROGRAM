using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_background_handler : MonoBehaviour
{
    //! Global variables declaration

    // Nuvens:
    public GameObject nuvens;
    public float nuvens_velocity;
    
    // Estrelas:
    public GameObject estrelas;
    
    // Fundo azul:
    public GameObject fundo_azul;
    
    // Start is called before the first frame update
    void Start()
    {
       nuvens.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - nuvens_velocity);
    }

}
