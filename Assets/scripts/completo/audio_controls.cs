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

    // Reference to the scene audio control 
    private GameObject music_volume_control;
    
    // Start is called before the first frame update
    void Start()
    {
        // Pega a referência do game manager
        game_manager = GameObject.FindWithTag("Game_manager");

        // Pega referência do save options
        save_options = game_manager.GetComponent<Game_Manager>().Get_save_options();
        
        // Achando barra de controle de volume da interface de usuário
        music_volume_control = GameObject.FindWithTag("audio_control");

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
        music_volume_control.GetComponent<AudioSource>().volume = volume;

        // Determina valor inicial da barra de volume
        my_slide.value = volume;

    }
    
    // Função que é chamada quando o valor do volume muda
    public void volume_controll(float volume){
        music_volume_control.GetComponent<AudioSource>().volume = volume;
        save_options.GetComponent<save>().salvar(volume.ToString("#.00"), "volume_musica");
    }
}
