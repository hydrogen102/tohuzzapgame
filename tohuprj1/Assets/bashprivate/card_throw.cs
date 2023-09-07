using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_throw : MonoBehaviour
{
    public int maxcard =5, cardamount;
    public SpriteRenderer cards, reloadbar;
    public ParticleSystem par;
    bool reloading;
    public float reloading_time = 4f;
    float reloadtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void throwing()
    {
        if(cardamount > 0 && !reloading)
        {
            cardamount--;
            par.Play();

            if(cardamount  <= 0)
            {   
                reloadtime = 0;
                reloading = true;
                reload();
            }
        }
    }

    int reload()
    {
        reloadtime += Time.deltaTime;
        //reloadbar.
        return reload();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
