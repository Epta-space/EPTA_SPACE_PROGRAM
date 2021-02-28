using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class audio_controls: MonoBehaviour
{
    // Reference to the scene audio control 
    private GameObject music_volume_control;
    private GameObject barra;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        music_volume_control = GameObject.FindWithTag("audio_control");
        barra = GameObject.FindWithTag("music_control_1");

        music_volume_control.GetComponent<AudioSource>().volume = float.Parse(GetComponent<save>().retornar_save("volume_musica"));
        barra.GetComponent<Slider>().value = float.Parse(GetComponent<save>().retornar_save("volume_musica"));




    }

    
    public void volume_controll(float volume){
        music_volume_control.GetComponent<AudioSource>().volume = volume;
        GetComponent<save>().salvar(volume, "volume_musica");
    }
}
