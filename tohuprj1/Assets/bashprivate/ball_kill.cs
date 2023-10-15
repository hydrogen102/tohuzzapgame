using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_kill : MonoBehaviour
{
    public Rigidbody2D ball;
    Rigidbody2D targetri;
    public float damagepower = 2f,parry = 100;
    int damag;
    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("player-1").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { Health heal;


        if (collision.transform.root.TryGetComponent<Health>(out heal))
        { damag = 5;
            bool isat = true;
            if (collision.transform.root.GetComponent<Rigidbody2D>())
            {
                targetri = collision.transform.root.GetComponent<Rigidbody2D>();
                Vector3 target = collision.transform.TransformVector(targetri.velocity);
                float a = Mathf.Atan2(ball.velocity.y, ball.velocity.x);
                if (Mathf.Abs(a - Mathf.Atan2(target.y, target.x)) <= damagepower)
                {
                    damag = (int)Mathf.Abs(a - Mathf.Atan2(target.y, target.x));
                }
                else
                {
                    isat = false;
                }
                if (collision.transform.root.CompareTag("Player"))
                {
                    if (collision.transform.root.GetComponent<stickman_move>().parrying)
                    {
                        ball.AddForce(((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).normalized * parry * 45f);
                    }
                    else
                    {
                        collision.transform.root.GetComponent<player_state>().damage(damag);
                    }

                    return;
                }

            }   
            if(isat)
            heal.damage(damag);
            
        }
        
        if(collision.transform.CompareTag("jump"))
        {
            ball.AddForce(((Camera.main.ScreenToWorldPoint(player.position) - transform.position)).normalized * parry * 45f);
        }
    }
}
