using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    public Rigidbody2D par,rb;
    public float power, hookpower;
    Collider2D col;
    public stickman_move movescript;
    bool actived = true, hooked;
    public Transform grabmodule;
    public Vector3 lossy;



    private void Awake()
    {
        dashing();
    }

    private void FixedUpdate()
    {
        if (hooked)
        {
            rb.AddForce((grabmodule.position - transform.position).normalized * hookpower);
            //transform.position = Vector2.Lerp(transform.position, grabmodule.position, Time.deltaTime * hookpower);
            if(Vector3.Distance(transform.position, grabmodule.position) < 0.8f)
            {
                deactive();
                grabmodule.gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
            }
        }
        if(actived)
        {
            movescript.dashorhook(transform.position, 21f);
        }
    }

    private void OnEnable()
    {
        hooked = false;
        transform.parent = null;
        transform.localScale = lossy;
        transform.position = grabmodule.position;
        transform.rotation = grabmodule.rotation;
        rb.isKinematic = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(transform.GetChild(0).up * power);
        rb.useFullKinematicContacts = false;
    }

    public void deactive()
    {
        if (transform.childCount > 1)
        {
            par.isKinematic = false;
            par.bodyType = RigidbodyType2D.Dynamic;
            rb.useFullKinematicContacts = false;
            transform.GetChild(1).parent = null;
        }
        transform.position = grabmodule.position;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rigidbodytmp;
        if (collision.transform.root.CompareTag("Player"))
        {
            hooked = false;
            actived = false;
            movescript.dash_active();
            if(transform.childCount > 1)
            {
                deactive();
            }
            grabmodule.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
        }
        else if (collision.TryGetComponent<Rigidbody2D>(out rigidbodytmp))
        {
            par = rigidbodytmp;
            if (!hooked)
            {
                rb.useFullKinematicContacts = true;
                par.velocity = Vector2.zero;
                par.isKinematic = true;
                par.bodyType = RigidbodyType2D.Kinematic;
                collision.transform.parent = transform;
            }

            hooked = true;
            
            //rb.AddForce(grabmodule.position - transform.position, ForceMode2D.Impulse);
        }
        else
        {   
            if(!hooked)
            {

            actived = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.useFullKinematicContacts = true;
            transform.parent = collision.transform;
            transform.parent = null;
            transform.localScale = lossy;
            transform.parent = collision.transform;
            
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbodytmp;
        if (collision.transform.root.CompareTag("Player"))
        {
            hooked = false;
            actived = false;
            movescript.dash_active();
            if (transform.childCount > 1)
            {
                deactive();
            }
            grabmodule.gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
        }
        else if (collision.transform.TryGetComponent<Rigidbody2D>(out rigidbodytmp))
        {
            par = rigidbodytmp;
            if (!hooked)
            {
                rb.useFullKinematicContacts = true;
                par.velocity = Vector2.zero;
                par.isKinematic = true;
                par.bodyType = RigidbodyType2D.Kinematic;
                collision.transform.parent = transform;
            }

            hooked = true;

            //rb.AddForce(grabmodule.position - transform.position, ForceMode2D.Impulse);
        }
        else
        {
            if (!hooked)
            {

                actived = true;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.useFullKinematicContacts = true;
                transform.parent = collision.transform;
                transform.parent = null;
                transform.localScale = lossy;
                transform.parent = collision.transform;

            }
        }

    }

    void dashing()
    {
        if(actived)
        {
           
        }
        Invoke("dashing", 0.07f);
    }
}
