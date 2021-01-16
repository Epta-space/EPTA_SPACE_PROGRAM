using UnityEngine;
using UnityEngine.UI;

public class interface_handler : MonoBehaviour
{
    // Game references:
    public GameObject Basic_UI;
    public GameObject Pause_UI;
    public GameObject About_UI,tela_de_perdeu;
    public float score = 0;
    public Text scoreText;
    private string tex;
    public float combustivel_total = 100, combus_atual;
    public Image barra_de_combus;
    

    void Start() {
        // Turn on ui basic
        Basic_UI.SetActive(true);
        combus_atual = 100;
        tela_de_perdeu.SetActive(false);
    }

    //! Função chamada uma vez por frame. CUIDADO com o que se coloca aqui.
    void Update() {
        score = Time.time;
        tex = score.ToString();
        scoreText.text = tex;

        if(combus_atual >= 80)
        {
            barra_de_combus.color = Color.green;
        }

        if (combus_atual < 80 & combus_atual >= 50)
        {
            barra_de_combus.color = Color.yellow;
        }

        if (combus_atual < 25)
        {
            barra_de_combus.color = Color.red;
        }

        if (combus_atual > 0)
        {
            combus_atual -= 1*Time.deltaTime;
        }
        

        float preenchimento = (combus_atual / combustivel_total) / 1;
        barra_de_combus.fillAmount = Mathf.SmoothStep(barra_de_combus.fillAmount, preenchimento, 10* Time.deltaTime);
        if(combus_atual <= 0)
        {
            Time.timeScale = 0;
            tela_de_perdeu.SetActive(true);
        }

    }
    

    //! Funções referentes aos botões de tela principal:

    // Script executado quando o jogo é pausado.
    public void Pause(){
        Basic_UI.SetActive(false);
        Pause_UI.SetActive(true);
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
        Pause_UI.SetActive(false);
        Time.timeScale = 1f;
        
    }

    // Script executado quando clica-se no botão "about". 
    public void About(){
        About_UI.SetActive(true);
        Pause_UI.SetActive(false);
        
    }


    //! Funções referentes ao menu about:

    // Script executado quando clica-se no botão "X" para sair do menu about. 
    public void exit_about(){
        About_UI.SetActive(false);
        Pause_UI.SetActive(true);
        
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
