using UnityEngine;
using UnityEngine.UI;

public class interface_handler : MonoBehaviour
{
    // Game references:
    public GameObject Basic_UI;
    public GameObject Pause_UI;
    public GameObject About_UI;
    public GameObject Game_manager; 
    private float score;             // de int -> float para adequar ao get_heigth
    public Text scoreText; 
    private GameObject sound_control;

    void Start() {
        // Turn on ui basic
        Basic_UI.SetActive(true);
        
        // Referência ao game manager
        Game_manager = GameObject.FindWithTag("Game_manager"); 

        // gerenciador de sons, para ativar o som do motor 
        sound_control = GameObject.FindWithTag("audio_control");
    }

    //! Função chamada uma vez por frame. CUIDADO com o que se coloca aqui.
    void Update() {
        
        score = Game_manager.GetComponent<Game_Manager>().Get_height();

        // Checa se a distância é maior que mil metros para adequar unidade de medida.
        // Podemos setar o objetivo atual como a lua (384400km). Ou seja depois dessa medida 
        // o jogador passa a dar voltas na lua até a gente aumentar o jogo.

        // Gerenciador de grandeza 
        if(score < 1000){
            scoreText.text = (int)score + " m  "; 
        }else{
            scoreText.text = (int)score/10 + " km  ";
        }

    }


    //! Funções referentes aos botões de tela principal:

    // Script executado quando o jogo é pausado.
    public void Pause(){
        Basic_UI.SetActive(false);
        Pause_UI.GetComponent<Canvas>().enabled = true;

        // Desliga o som do motor
        sound_control.GetComponent<audio_controls>().motor_ligado(false);

        // Para tempo
        Time.timeScale = 0f;
        
    }


    //! Funções referentes ao menu pause:

    // Script executado quando se quer encerrar o jogo. 
    public void exit(){
        Application.Quit();
    }

    // Script executado quando o jogo é resumido. 
    public void Resume(){
        Basic_UI.SetActive(true);
        Pause_UI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        

        // Descobre fase atual
        int phase = Game_manager.GetComponent<Game_Manager>().Get_phase();

        // Liga o som do motor se a fase não é igual a zero
        if (phase > 0){
            sound_control.GetComponent<audio_controls>().motor_ligado(true);
        }
    }

    // Script executado quando clica-se no botão "about". 
    public void About(){
        About_UI.SetActive(true);
        Pause_UI.GetComponent<Canvas>().enabled = false;
        
    }


    //! Funções referentes ao menu about:

    // Script executado quando clica-se no botão "X" para sair do menu about. 
    public void exit_about(){
        About_UI.SetActive(false);
        Pause_UI.GetComponent<Canvas>().enabled = true;
        
    }

    // Script executado quando clica-se no botão do instagram. 
    public void instagram_about(){
        Application.OpenURL("https://www.instagram.com/equipe_epta/");
    }

    // Script executado quando clica-se no botão do Facebook. 
    public void facebook_about(){
        Application.OpenURL("https://www.facebook.com/eptarocketdesign/");   
    }

    // Engenharia aeronáutica, mecânica, mecatrônica, elétrica, eletrônica e telecomunicações, ciências contábeis, jornalismo e Administração
    // FEMEC                                        , FEELT                                  , FACIC              , FACED        , FAGEN
    // Script executado quando clica-se no botão da femec. 
    public void femec_about(){
        Application.OpenURL("http://www.mecanica.ufu.br/");   
    }

    // Script executado quando clica-se no botão da feelt. 
    public void feelt_about(){
        Application.OpenURL("http://www.feelt.ufu.br/");   
    }

    // Script executado quando clica-se no botão da facic. 
    public void facic_about(){
        Application.OpenURL("http://www.facic.ufu.br/");   
    }

    // Script executado quando clica-se no botão da faced. 
    public void faced_about(){
        Application.OpenURL("http://www.faced.ufu.br/");   
    }

    // Script executado quando clica-se no botão da fagen. 
    public void fagen_about(){
        Application.OpenURL("http://www.fagen.ufu.br/");   
    }

    // Script executado quando clica-se no botão da ufu. 
    public void ufu_about(){
        Application.OpenURL("http://www.ufu.br/");   
    }

}
