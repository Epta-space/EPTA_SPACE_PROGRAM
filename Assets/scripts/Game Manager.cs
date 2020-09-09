using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public int stage;
    public float time = 0;
    public float n = 1;

    void Start()
    {
        time += Time.deltaTime;
    }

    void Update()
    {
        if(time >= 30000 * n){
            stage++;
            n *= 1.5f;
        }
    }
}
