using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_state : Health
{
    public float maxheal;
    // Start is called before the first frame update
    void Awake()
    {
        maxheal = maxheal;
        hp = (int)maxheal;
    }


    void Update()
    {
        
    }

    public override void die()
    {
        base.die();
        print("asdf");

    }
}
