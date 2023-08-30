using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plmove : MonoBehaviour
{
    Rigidbody2D ri;
    public float speed = 4f,delay = 0.1f;
    bool a = true;
    ParticleSystem pa;
    // Start is called before the first frame update
    void Start()
    {pa = transform.GetChild(0).GetComponent<ParticleSystem>();
        ri = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ri.velocity = Vector3.right * Input.GetAxis("Horizontal") * speed + Vector3.up * ri.velocity.y;

        if (a && Input.GetButton("Fire1"))
        {
            a= false;
            pa.Play();
            Invoke("aa", delay);
        }
    }
    void aa()
    {
        a = true;
    }
}
