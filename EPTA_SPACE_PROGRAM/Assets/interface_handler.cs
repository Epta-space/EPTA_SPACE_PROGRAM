using UnityEngine;
using UnityEngine.UI;

public class interface_handler : MonoBehaviour
{
    // Game references:
    public GameObject Basic_UI;
    public GameObject Pause_UI;
    public int score = 0;
    public Text scoreText;

    void Update() {
        
        // Checa se a distância é maior que mil metros para adequar unidade de medida.
        // Podemos setar o objetivo atual como a lua (384400km). Ou seja depois dessa medida 
        // o jogador passa a dar voltas na lua até a gente aumentar o jogo. 
        if(score < 1000){
            scoreText.text = score + " m  "; 
        }else{
            scoreText.text = score/10 + " km  ";
        }

        // Contador simples para teste. No futuro referenciaremos script "phase_handler"
        if(Input.GetKeyDown(KeyCode.Space)){
            score = score + 100;
        }

    }
    
    // Script executado quando o jogo é pausado.
    public void Pause(){
        Basic_UI.SetActive(false);
        Pause_UI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    // Script executado quando o jogo é resumido. 
    public void Resume(){
        Basic_UI.SetActive(true);
        Pause_UI.SetActive(false);
        Time.timeScale = 1f;
        
    }


}
