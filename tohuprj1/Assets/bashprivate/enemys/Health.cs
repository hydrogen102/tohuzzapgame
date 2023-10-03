using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp,max_hp;
    // Start is called before the first frame update

    public virtual void damage(int dam)
    {
        hp -= dam;
        if(hp <= 0 )
        {
            die();
        }
        else
        if(hp > max_hp)
        {
            hp = max_hp;
        }
    }

    public virtual void die()
    {
        print("hp");
    }
}
