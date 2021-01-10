using UnityEngine;

public class Destroy_obstacles : MonoBehaviour
{
    
    // Just destroy watever touches this object
     void OnCollisionEnter2D(Collision2D coll) 
     {
        Destroy(coll.gameObject);
     }
}