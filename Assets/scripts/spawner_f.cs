using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_f: MonoBehaviour {

    public float maxTime = 1;
    private float timer = 0;
    public static GameObject obstacle = Object_Selector.obstacle;
    private float width;
    private Vector3 localScreenWidth;

    private float random_range_a;
    private float random_range_b;
    public int pontos = 5;

    public float score;


    void Start() {
        GameObject obstacle = Object_Selector.obstacle;
        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        random_range_a = localScreenWidth.x - (0.3f * localScreenWidth.x);
        random_range_b = localScreenWidth.x + (0.2f * localScreenWidth.x);

        GameObject new_obstacle = Instantiate(obstacle);
        new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-random_range_a, random_range_b), 0, 0);
    }

    void Update() {
        if (timer > maxTime) {
            GameObject obstacle = Object_Selector.obstacle;
            GameObject new_obstacle = Instantiate(obstacle);
            new_obstacle.transform.position = transform.position + new Vector3(Random.Range(-random_range_a, random_range_b), 0, 0);

            if (new_obstacle.transform.position.y <= (localScreenWidth.y - localScreenWidth.y * 0.06f)) {
                DestroyImmediate(new_obstacle, true);
            }
            timer = 0;
            maxTime = 0.95f * maxTime;
        }
        score += pontos;
        timer += Time.deltaTime;
    }
}