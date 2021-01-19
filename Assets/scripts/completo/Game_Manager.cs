using UnityEngine;

public class Game_Manager : MonoBehaviour{

    // Refere-se à fase
    private int phase = 0;

    // Refere-se ao jogador
    private GameObject player;

    // Refere-se ao tempo relativo da fase
    private float phase_time;

    // Tempo da próxima fase
    private float next_phase;

    // Refere-se ao tempo total de jogo
    private float game_time;

    // Define a duração de cad fase
    private float[] phase_plan = new float[2]{10.0f, 10.0f};

    void Start()
    {
        // Procura pelo objeto de jogo do jogador
        player = GameObject.FindWithTag("Player");

        // Tempo inicial, após dado play
        game_time = Time.time;
        next_phase = 0.0f;

    }

    void Update()
    {

        // Phase Query from time
        if(Time.time > next_phase){

            if (phase >= phase_plan.Length){
                // final com fase infinita
                next_phase = 36000000.0f;
            }else{
                // Registra tempo de conversão para nova fase
                next_phase = phase_plan[phase] + Time.time;
            }

            // Passa a fase e registra tempo
            phase++;
            phase_time = Time.time;
            
        }

    }

    // Pega posição em x do jogador -2.6 < x < 2.6
    public float Get_player_x(){return player.GetComponent<Transform>().position.x;}
    
    // Pega objeto do jogador
    public GameObject Get_player(){return player;}
    
    // Pega fase atual (começa em 1)
    public int Get_phase(){return phase;}
    
    // Pega tempo de fase atual
    public float Get_phase_time(){return Time.time - phase_time;}

    // Pega fração de completude de fase de 0 a 1
    public float Get_phase_fraction(){return (Time.time - phase_time)/phase_plan[phase];}
    
    // Pegar tempo global de execução
    public float Get_time(){return Time.time - game_time;}
}