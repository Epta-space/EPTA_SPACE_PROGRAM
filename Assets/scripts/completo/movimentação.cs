using UnityEngine;

public class movimentação : MonoBehaviour
{
    public float speed;
    public static bool input_consider;
    private Rigidbody2D rb;
    private Vector3 localScreenWidth;

    private GameObject sound_control;

    void Start()
    {
        // Take the players rigid body
        rb = GetComponent<Rigidbody2D>();

        // gerenciador de sons, para ativar o som do motor 
        sound_control = GameObject.FindWithTag("audio_control");

        // Take the screen size
        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Procura por toque na tela
    void FixedUpdate()
    {

        checkUserInput();

        // Teleporta jogador para o outro canto da tela.
        if (transform.position.x >= 1.09 * localScreenWidth.x)
        {
            transform.position = new Vector3(-1.07f * localScreenWidth.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -1.09 * localScreenWidth.x)
        {
            transform.position = new Vector3(1.07f * localScreenWidth.x, transform.position.y, transform.position.z);
        }
    }

    // Checa o input do jogador
    public void checkUserInput()
    {
        // Button clicking detection
        if (Input.GetMouseButton(0) && input_consider == true)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.y < 4)
            {
                if (touchPos.x < 0)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
        }
    }

    // Faz o player cair
    public void movimento_inicial_player()
    {
        // Invoca o método de recuo do jogador
        InvokeRepeating("recuo_jogador_inicial", 0f, 0.1f);

        // Toca animação do jogador
        Animator player_animator = this.gameObject.GetComponent<Animator>();
        player_animator.SetBool("start_game", true);

        // Liga o som do motor
        sound_control.GetComponent<audio_controls>().motor_ligado(true);
    }

    // Repetidor invocado
    private void recuo_jogador_inicial()
    {
        // Recuo do jogador
        rb.velocity = new Vector2(rb.velocity.x, -0.5f * 2);

        // Checa se está na altura de parada
        if (transform.position.y <= -1.5)
        {
            // Para o método de recuo do jogador
            CancelInvoke();
            // Atiba input jogador
            ativar_input();
        }

    }

    public void desativar_input()
    {
        input_consider = false;
    }
    public void ativar_input()
    {
        input_consider = true;
    }

    public void End_player(int explosion_type){
        // Toca animação do jogador
        Animator player_animator = this.gameObject.GetComponent<Animator>();

        // Checa condição de fim de jogo
        if (explosion_type == 0){
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f,transform.position.z);
            player_animator.SetBool("explosion1", true);
        } else if (explosion_type == 1) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f,transform.position.z);
            player_animator.SetBool("explosion2", true);
        } else if (explosion_type == 2) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f,transform.position.z);
            player_animator.SetBool("explosion3", true);
        }
    }



    public void Freeze_player_y(){
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY
                                                        | RigidbodyConstraints2D.FreezeRotation
                                                        | RigidbodyConstraints2D.FreezePositionX;
    }

    public void Desligar_som_do_motor(){
        sound_control.GetComponent<audio_controls>().motor_ligado(false);
    }

}
