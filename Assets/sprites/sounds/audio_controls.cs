using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class audio_controls: MonoBehaviour
{
    private GameObject music_volume_control;
    public UnityEngine.UI.Slider som;
    private void Awake()
    {
        music_volume_control = GameObject.FindWithTag("audio_control");
        music_volume_control.GetComponent<AudioSource>().volume = 1f;
        
        
    }
    void Start()
    {
        music_volume_control.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
        som.value = PlayerPrefs.GetFloat("volume"); // atribui o valor do volume no slider
        
    }



    public void volume_controll(float volume){
        music_volume_control.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("volume", volume); //salva valor do volume
        
    }
}
