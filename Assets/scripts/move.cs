using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour
{
    public float speed;
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - speed);
    }
    public float Get_velocity(){return speed;}
    
}
