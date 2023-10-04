using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class card_throw : MonoBehaviour
{
    public int maxcard =5, cardamount;
    public SpriteRenderer cards, reloadbar;
    public ParticleSystem par;
    bool reloading;
    public float reloading_time = 4f;
    float reloadtime;
   public int cardtype = 0; //0=±âº» 1=Æø¹ß 2= »êÅº
    public GameObject boom, multyshot;
    public Color[] cardclors;
    public wiplash wi;
    public hook grabhook;

    private KeyCode[] keyCodes = {
    KeyCode.Alpha1,
    KeyCode.Alpha2,
    KeyCode.Alpha3,
    KeyCode.Alpha4,
    KeyCode.Alpha5,
    KeyCode.Alpha6,
    KeyCode.Alpha7,
    KeyCode.Alpha8,
    KeyCode.Alpha9,
                                };

    // Start is called before the first frame update
    void Awake()
    {
        cardamount = maxcard;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKey(keyCodes[i]))
            {
               
                cardtype = i;
            }
        }
        cardtype += (int)Input.GetAxisRaw("Mouse ScrollWheel");
        if(cardtype >3)
        {
            cardtype = 0;
        }
        else if(cardtype < 0)
        {
            cardtype = 3;
        }

        cards.color = cardclors[cardtype];

    }

    private void inactive_wiplash()
    {

    }

    void shot()
    {
        cardamount--;

        switch (cardtype)
        {
            case 0:
                par.Play();
                break;
            //±âº»
            case 1:
                Instantiate(boom, par.transform.position, par.transform.rotation);
                break;
            //boom
            case 2:
                Instantiate(multyshot, par.transform.position, par.transform.rotation);
                break;
            //grab
            case 3:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    public void throwing()
    {
        bool throwed = true;


        
            if(!transform.GetChild(0).gameObject.activeInHierarchy)
            {
                if (cardamount > 0 && !reloading)
                    shot();
            }
            else if(throwed)
            {
                grabhook.deactive();
                transform.GetChild(0).gameObject.SetActive(false);
                grabhook.gameObject.SetActive(false);
               // Invoke(nameof(inactive_wiplash), 0.1f);
                throwed = false;
            }

            cards.size = new Vector2(cardamount, 1.5f);
            if(cardamount  <= 0&& !reloading)
            {
                reloadtime = 0;
                reloading = true;
                reloadbar.transform.parent.gameObject.SetActive(true);
                reload();
            }
        
    }

    void reload()
    {   
        reloadtime += 0.05f;
        reloadbar.size = new Vector2(reloadtime / reloading_time, 0.9f);
        reloadbar.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        if (reloadtime > reloading_time )
        {
            reloadbar.transform.parent.gameObject.SetActive(false);
            reloading = false;
            cardamount = maxcard;
            cards.size = new Vector2(cardamount, 1.5f);
            return;
        }
        Invoke(nameof(reload),0.05f);
    }


}
