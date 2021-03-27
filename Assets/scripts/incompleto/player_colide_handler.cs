using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_colide_handler : MonoBehaviour
{
    // No momento em que ocorre a colisão ele chama essa função
    void OnCollisionEnter2D(Collision2D objeto_alvo)
    {
        // Chama o gerenciador de colisões
        ColisorHandler(objeto_alvo.gameObject.tag);
    }

    private void ColisorHandler(string colidido){
        Debug.Log(colidido);

    }
}
