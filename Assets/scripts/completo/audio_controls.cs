using UnityEngine;

public class audio_controls: MonoBehaviour
{
    // Reference to the scene audio controll 
    private GameObject music_volume_control;

    // makes the starting volume change in UI
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        // Acha o game audio principal, com a música do jogo via tag (GameObject Audio Source)
        music_volume_control = GameObject.FindWithTag("audio_control");
        
        // Declara o volume 
        music_volume_control.GetComponent<AudioSource>().volume = volume;

    }

    // Quando o valor do volume muda, atualiza o valor no Audio source da música
    public void volume_controll(float volume){
        music_volume_control.GetComponent<AudioSource>().volume = volume;
    }
}
