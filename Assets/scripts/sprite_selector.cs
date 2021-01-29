using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_selector : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite explosão; //Variável referente ao sprite de explosão
    Game_Manager scriptInstance = null;

    void troca_sprite(Sprite sprite){
        spriteRenderer.sprite = sprite;  
        // scriptInstance.Pause();
    }

    // Start is called before the first frame update
    void Start(){
        // GameObject tempObj = GameObject.Find("GameManager");
        // scriptInstance = tempObj.GetComponent<Game_Manager>(); //Importa o script do objeto GameManager
        //TODO: Atualmente a função está em interface handler, torná-la parte do game manager e descomentar essa parte do código
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        troca_sprite(explosão); //Troca o sprite atual pelo sprite de explosão
    }
}
