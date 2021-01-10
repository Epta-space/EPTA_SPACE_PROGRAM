using UnityEngine;

public class Game_Manager : MonoBehaviour{

    // Refere-se à fase
    private int phase = 0;

    // Refere-se ao jogador
    private GameObject player;

    // Refere-se ao tempo relativo da fase
    private float phase_time;

    // Defines the phase brake points in seconds            fase 1     |      fase 2      |  fease 3
    private float[] phase_plan = new float[3]{10.0f, 30.0f , 0.0f};

    void Start()
    {
        // searchs for the player game object
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

        // Phase Query
        if(Time.time > phase_plan[phase] & phase < phase_plan.Length){
            phase++;
            phase_time = Time.time;
        }

    }

    // Function for getting the player x axis -2.6 < x < 2.6
    public float Get_player_x(){return player.GetComponent<Transform>().position.x;}

    // Function for other scripts to aces current phase
    public int Get_phase(){return phase;}
    
    // Function for other scripts to aces current phase time in seconds
    public float Get_phase_time(){return Time.time - phase_time;}

    // Function for Getting time globall time
    public float Get_time(){return Time.time;}

    // Function for getting player game object
    public GameObject Get_player(){return player;}


}