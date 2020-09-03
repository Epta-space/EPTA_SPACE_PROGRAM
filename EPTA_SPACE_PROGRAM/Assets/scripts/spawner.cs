using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {


    public float maxTime = 10000;
    private float timer;
    public GameObject obstacle;
    public float width;
    public float speed;

    public float maxTime0 = 10000;
    public int pontos = 5;

    public float score;


    void Start() {
        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
    }

    void Update()
    {
        if(timer > maxTime) {
            GameObject new_obstacle = Instantiate(obstacle);
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);
            if(new_obstacle.transform.position.y < (- 7)){
                DestroyImmediate(new_obstacle, true);
            }
            timer = 0; 
            maxTime = 0.9f * maxTime;
        }
        score += pontos; 
        timer += Time.deltaTime; 
    }
}