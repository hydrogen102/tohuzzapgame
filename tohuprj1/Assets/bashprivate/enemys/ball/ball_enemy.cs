using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_enemy : Health
{
    public Rigidbody2D ri;
    public float speed = 1, power = 5;
    public static Transform player;
    public ParticleSystem dieparticle;
    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("player-1").transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        ri.AddForce(new Vector2(((player.position.x > transform.position.x) ? 1 : -1) * speed, power));
    }
    public override void die()
    {
       dieparticle.Play();
        transform.GetChild(0).parent = null;
        Destroy(gameObject);
    }
}
