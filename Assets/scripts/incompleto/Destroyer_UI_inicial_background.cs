using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_UI_Initial_background : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
 
    }

    public float timeRemaining = 10;
    public int Get_phase() { return phase; }

    void Update()
    {
        if (phase != 0)
        {
            // Destruir o UI_Initial_Background
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
