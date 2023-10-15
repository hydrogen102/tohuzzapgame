using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ball_enemy : Health
{
    [SerializeField] Rigidbody2D ri;
    public float speed = 1, power = 5,dis;
    public static Transform player,balltr;
    public ParticleSystem dieparticle;
    public bool plat;
    Transform target;
    bool attack_able = true,played = true;
    Vector2 tmptransform;
    float time1, time2;
    public int dmg;
    RaycastHit2D a;

    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("player-1").transform;
        }

        if (balltr == null)
        {
            balltr = GameObject.Find("m_ball").transform;
        }
        if(plat)
        {
            target = player;
        }
        else
        {
            target = balltr;
        }
    }

    private void FixedUpdate()
    {

        if((Vector2.Distance(transform.position, target.position) < dis )&& attack_able)
        {
            if(time1 >= 0.6f)
            {   
                time1 = 0;
                ri.AddForce((tmptransform - (Vector2)transform.position) * power * 5f);
                attack_able = false;
                Invoke(nameof(cooldown), 1f);
            }
            else if(played)
            {
                
                tmptransform = target.position;
                played = false;

            }
            else
            {
                time1 += Time.fixedDeltaTime;
                ri.velocity = Vector2.zero;
            }

        }
        else
        {
            time1 = 0;
        }
    }

    void cooldown()
    {
        ri.velocity = Vector2.zero;
        attack_able = true;
        played = true;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ri.AddForce(new Vector2(((target.position.x > transform.position.x) ? 1 : -1) * speed, power));

        if(plat)
        {

        }
    }
    public override void die()
    {
       dieparticle.Play();
        if(transform.childCount != 0)
        transform.GetChild(0).parent = null;
        Destroy(gameObject);
    }
}
