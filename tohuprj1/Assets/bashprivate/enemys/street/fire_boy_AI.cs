using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class fire_boy_AI : Health
{
    static public Transform player;
    public int maxhelth,speed;
    public Rigidbody2D ri;
    public float cooldown=1,dis = 2.5f;
    float dir;
    bool dash_ready = true;
    public Animator ani;
    private void Awake()
    {
        if(player == null)
        {

        player = GameObject.Find("player-1").transform;
        }
        ri = GetComponent<Rigidbody2D>();
        hp = maxhelth;
        max_hp = maxhelth;

        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (transform.position.x < player.position.x)
        {
            dir = speed;
            transform.GetChild(1).rotation = Quaternion.Euler(-90, 95, 0);
        }
        else
        {
            dir = -speed;
            transform.GetChild(1).rotation = Quaternion.Euler(-90, -95, 0);
        }

        if(Vector2.Distance(player.position, transform.position) <6f)
        if (dash_ready)
        {

            ri.AddForce(Vector2.right * dir * Vector2.up * 2 , ForceMode2D.Impulse);
            dash_ready = false;
            Invoke("active", cooldown);
        }
        ri.velocity = Vector2.right * dir;

        if(Vector2.Distance(player.position, transform.position) < dis)
        {
            ani.SetBool("attack", true);
        }
        else
        {
            ani.SetBool("attack", false);
        }
    }

    void active()
    {
        dash_ready = true;
    }

    public override void die()
    {
        print("fire");
    }
}
 