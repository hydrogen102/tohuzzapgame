using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class plmove_1 : MonoBehaviour
{



    public Rigidbody2D ri;

    public float speed, jp, fall, bounce;

    public Animator an;
    public bool died, isred, dashing, infoot, parrying;
    public Transform target;
    public GameObject[] diesounds;
    public int maxdash;
    public float delay, dash = 25f, dashcount;
    public ParticleSystem pa;
    public card_throw _card_throw;
    public LayerMask layer;
    public SpriteRenderer dash_bar;
    int dashdir = 1;

    float yvel;
    bool ang, a = true, b = true;
    Rigidbody2D[] childs;
    // Start is called before the first frame update
    void Awake()
    {


        childs = GetComponentsInChildren<Rigidbody2D>();
    }

    void aa()
    {
        a = true;
    }
    void bb()
    {
        b = true;
    }
    public void dash_active()
    {
        dashing = false;
        ri.velocity = Vector2.zero;

        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].velocity = Vector2.zero;
        }

    }

    void FixedUpdate()
    {

        if(Input.GetAxisRaw("Horizontal") >= 0)
        {
            dashdir = 1;
        }
        else
        {
            dashdir = -1;
        }

        if (dashcount < maxdash)
        {
            dashcount += Time.fixedDeltaTime / 1.5f;
        }

        dash_bar.size = new Vector2(dashcount / 1.5f, 1);

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcount >= 1 && b)
        {
            b = false;
            dashcount--;
            dashorhook(transform.position + transform.right * dashdir * 45f, dash);
            Invoke(nameof(parry), 0.03f);
            Invoke("dash_active", 0.1f);
            Invoke("bb", 0.02f);
        }
        if (!died)
        {

            if (a && Input.GetButton("Fire1"))
            {
                a = false;
                _card_throw.throwing();
                //pa.Play();
                Invoke("aa", delay);
            }

            infoot = Physics2D.CircleCast(transform.GetChild(0).position, 0.1f, Vector3.down, 0.55f, layer);
            #region nouse
            //for (int i = 0; i < sc.Length; i++)
            //{
            //    if (!sc[i].CompareTag("foot"))
            //        handed = handed || sc[i].gr;
            //    if (sc[i].CompareTag("infoot"))
            //    {
            //        infoot = infoot || sc[i].gr;
            //    }
            //}
            #endregion
            yvel = ri.velocity.y;
            if (!dashing)
            {
                ri.velocity = transform.right * speed * (Input.GetAxis("Horizontal")) + Vector3.up * (yvel + (((infoot == true) ? fall : -1)));
            }

            //ri.AddForce(Vector3.up * (((isg) ? fall : -1f) + ((isg && infoot == true) ? 2.5f : 0)), ForceMode2D.Impulse); // �߷�(-2) or �ٸ� ��(������ ��)

            


            an.SetBool("walk", Input.GetButton("Horizontal"));
            an.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));
            ri.SetRotation(Input.GetAxis("Horizontal") * 6);

            target.LookAt((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));

            for (int i = 0; i < childs.Length; i++)
            {
                if (Vector3.Distance(childs[i].velocity, Vector3.zero) > 100)
                {
                    childs[i].velocity = Vector3.zero;
                }
            }
        }

        an.SetBool("die", died);
    }

    void parry()
    {
        parrying = true;
        Invoke(nameof(parryend), 0.07f);
    }
    void parryend()
    {
        parrying = false;
    }

    public void dashorhook(Vector3 pos, float dashspeed)
    {
        dashing = true;
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].velocity = (pos - childs[i].transform.position).normalized * dashspeed;
            ri.AddForce((pos - childs[i].transform.position).normalized * dashspeed);
        }
    }

    public void die()
    {

        if (ang)
        {
            ang = false;
            Invoke("diesou", 1.5f);
        }

        died = true;
        Invoke("ress", 7f);
    }

    void diesou()
    {
        ang = true;
    }
    void ress()
    {
        died = false;
    }
}


