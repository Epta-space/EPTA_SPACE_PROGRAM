using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_controls: MonoBehaviour
{
    private GameObject music_volume_control;
    // Start is called before the first frame update
    void Start()
    {
        music_volume_control = GameObject.FindWithTag("audio_control");

        // this.gameObject.GetComponent<AudioSource>().volume = music_volume_control.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void volume_controll(float volume){
        music_volume_control.GetComponent<AudioSource>().volume = volume;
    }
}
