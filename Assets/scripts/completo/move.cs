using UnityEngine;


public class move : MonoBehaviour
{
    // Some variables 
    public float speed;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - speed);
    }

    // Get current velocity
    public float Get_velocity(){return speed;}

    // Set the speed of object
    public void SetSpeed(float speed_to_set){
        speed = speed_to_set;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - speed_to_set);
    }
    
}
