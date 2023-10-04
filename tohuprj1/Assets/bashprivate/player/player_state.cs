using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_state : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        print(collision.gameObject);
    }
}
