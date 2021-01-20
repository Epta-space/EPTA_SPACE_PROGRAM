using UnityEngine;

public class movimentação : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector3 localScreenWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        // Button clicking detection
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touchPos.x < 0){
                rb.velocity = new Vector2( -speed, rb.velocity.y);
            }
            else{
                rb.velocity = new Vector2( speed, rb.velocity.y);
            }

        }  

        localScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x >= 1.09 * localScreenWidth.x)
        {

            transform.position = new Vector3(- 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);

        }
        else if (transform.position.x <= -1.09 * localScreenWidth.x)
        {

            transform.position = new Vector3( 1.07f * localScreenWidth.x, transform.position.y, transform.position.z);

        }
    }
}