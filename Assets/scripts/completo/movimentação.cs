using UnityEngine;

public class movimentação : MonoBehaviour
{
    public float speed;
    private bool input_consider = false;
    private Rigidbody2D rb;
    private Vector3 localScreenWidth;

    void Start()
    {
        // Take the players rigid body
        rb = GetComponent<Rigidbody2D>();

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
            transform.position = new Vector3(- 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -1.09 * localScreenWidth.x)
        {
            transform.position = new Vector3( 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);
        }
    }

    // Checa o input do jogador
    public void checkUserInput()
    {
        // Button clicking detection
        if(Input.GetMouseButton(0) && input_consider)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.y < 0){
                if(touchPos.x < 0){
                    rb.velocity = new Vector2( -speed, rb.velocity.y);
                }
                else{
                    rb.velocity = new Vector2( speed, rb.velocity.y);
                }
            }
        }
    }

    // Faz o player cair
    public void movimento_inicial_player()
    {
        // Invoca o método de recuo do jogador
        InvokeRepeating("recuo_jogador_inicial",0f,0.1f);

        // Toca animação do jogador
        Animator player_animator = this.gameObject.GetComponent<Animator>();
        player_animator.SetBool("start_game", true);
    }

    private void recuo_jogador_inicial()
    {
        // Recuo do jogador
        rb.velocity = new Vector2(rb.velocity.x, -0.5f*speed);

        // Checa se está na altura de parada
        if(transform.position.y <= -1.5){
            // Para o método de recuo do jogador
            CancelInvoke();
            input_consider = true;
        }

    }
}
