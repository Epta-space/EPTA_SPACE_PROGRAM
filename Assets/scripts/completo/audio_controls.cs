using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class audio_controls: MonoBehaviour
{
    // public slider
    public Slider my_slide;

    // Referencia ao game manager
    private GameObject game_manager;
    private GameObject save_options;

    // Fontes de audio
    public AudioSource som_musica;
    public AudioSource som_motor;
    public AudioSource som_explosao;

    // Controle do som do motor
    private float percentage_motor;
    
    // Start is called before the first frame update
    void Start()
    {
        // Pega a referência do game manager
        game_manager = GameObject.FindWithTag("Game_manager");

        // Pega referência do save options
        save_options = game_manager.GetComponent<Game_Manager>().Get_save_options();
        
        // Checa se existe valor salvo no endereço que será utilizado
        float volume;
        if(save_options.GetComponent<save>().existe_valor("volume_musica")){
            // Se há um valor, simplesmente carrega-se ele
            volume =  float.Parse(save_options.GetComponent<save>().retornar_save("volume_musica"));
        }else{
            // Se não há o valor na memória executa um primeiro salvamento de volume máximo
            volume = 0.99f;
            save_options.GetComponent<save>().salvar(volume.ToString("#.00"), "volume_musica");
        }

        // Volume inicial da partida é setado a partir do valor salvo em memória 
        percentage_motor = 1f;
        som_musica.volume = volume;
        som_motor.volume = volume * percentage_motor;

        // Determina valor inicial da barra de volume
        my_slide.value = volume;

    }
    
    // Função que é chamada quando o valor do volume muda
    public void volume_controll(float volume){
        som_musica.volume = volume;
        som_motor.volume = volume * percentage_motor;
        save_options.GetComponent<save>().salvar(volume.ToString("#.00"), "volume_musica");
    }

    // Liga e desliga motor. E quando liga ativa o motor e diminui seu volume gradativamente
    public void motor_ligado(bool botao){
        // Se for True, ele liga o motor, mas se for false, ele liga.
        if(botao){
            // Reinicia a porcentagem do motor
            percentage_motor = 1f;

            // Liga o som do motor
            som_motor.enabled = true;

            // Liga a musica
            som_musica.enabled = true;


            // Invoca o método de recuo do jogador
            InvokeRepeating("gradiente_volume_motor", 0f, 0.1f);
        }else{
            som_motor.enabled = false;
        };

    }

    public void explosao(){
        som_explosao.volume = som_musica.volume;
        som_explosao.enabled = true;
    }

    // Diminui o volume gradativamente
    private void gradiente_volume_motor(){
        if(0.65f < percentage_motor){
            percentage_motor -= percentage_motor * 0.01f;
            som_motor.volume = som_musica.volume * percentage_motor;
        }else{
            // Cancela método repetidor
            CancelInvoke();
        }
    }

}
