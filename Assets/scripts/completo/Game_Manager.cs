using UnityEngine;

public class Game_Manager : MonoBehaviour{

    // Refere-se à fase
    private int phase = 0;

    // Refere-se ao jogador
    private GameObject player;
    
    // referencia à rotina de fim de jogo
    private GameObject fim_do_jogo;

    // Refere-se ao tempo relativo da fase
    private float phase_time;

    // Tempo da próxima fase
    private float next_phase;

    // Refere-se ao tempo total de jogo
    private float game_time;

    // Define a duração de cad fase
    private float[] phase_plan = new float[2]{100.0f, 100.0f};

    // Define a Altura de cada fase
    private float[] phase_height = new float[2]{36000.0f,50000.0f};

    void Start()
    {
        // Procura pelo objeto de jogo do jogador
        player = GameObject.FindWithTag("Player");

        // Pega a referência às rotinas de fim de jogo
        fim_do_jogo = transform.GetChild(1).gameObject;

        // Inicializa a fase 0
        phase_time = 0.0f;
        next_phase = 3600000000.0f;
    }

    void Update()
    {
        // Phase Query from time
        if(Get_phase_time() > next_phase){

            if (phase >= phase_plan.Length){
                // final com fase infinita
                next_phase = 3600000000.0f;
            }else{
                // Registra tempo de conversão para nova fase
                next_phase = phase_plan[phase];
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
    public float Get_phase_fraction()
    {
        if(phase >= phase_plan.Length)
        {
            // Se estamos na ultima fase ou na fase 0, retorna 1 sempre
            return 1.0f;
        }else{
            // Se estamos em uma fase comum retorna porcentagem da fase
            return (Time.time - phase_time)/phase_plan[phase - 1];
        }
    }
    
    // Pegar tempo global de execução
    public float Get_time(){return Time.time - game_time;}

    // Get save options component
    public GameObject Get_save_options(){return this.gameObject.transform.GetChild(0).gameObject;}

    // Função para iniciar jogo
    public void Initiate_game()
    {
        // Zera next phase para iniciar partida
        next_phase = 0.0f;

        // Tempo inicial, após dado play
        game_time = Time.time;

        // Faz o player cair pra trás
        Get_player().GetComponent<movimentação>().movimento_inicial_player();
    }

    // Termina o jogo
    public void Terminar_jogo(){
        // Chama a rotina de fim de jogo
        fim_do_jogo.GetComponent<end_handler>().End_Game();
    }

    // Função para Pegar a altura
    public float Get_height()
    {
        if (Get_phase() == 1){
            return Get_phase_fraction() * phase_height[phase - 1] ;
        }else if (Get_phase() == 2){
            return Get_phase_fraction() * phase_height[phase - 1] + phase_height[phase - 2];
        }else{
            return -12;
        }
    }
}
