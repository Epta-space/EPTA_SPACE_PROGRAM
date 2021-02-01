using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_selector : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite explosão; //Variável referente ao sprite de explosão

    void troca_sprite(Sprite nova_imagem){
        spriteRenderer.sprite = nova_imagem;  
    }

    void Start(){
        spriteRenderer =  GetComponent<SpriteRenderer>();
    }

}


