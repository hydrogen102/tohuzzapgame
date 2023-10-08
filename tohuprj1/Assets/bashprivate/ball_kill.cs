using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_kill : MonoBehaviour
{
    public Rigidbody2D ball;
    private void OnCollisionEnter2D(Collision2D collision)
    { Health heal;


        if (collision.transform.root.TryGetComponent<Health>(out heal))
        {
            Vector3 target = collision.transform.position - transform.position;
            float a = Mathf.Atan2(ball.velocity.y, ball.velocity.x);

            if (Mathf.Abs(a - Mathf.Atan2(target.y, target.x)) <= 2)
            {
                heal.damage(5);
            }
        }
    }
}
