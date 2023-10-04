using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electronic_box : MonoBehaviour
{
    public GameObject paricle_parent;
    public Collider2D thiscol;
    public Sprite destroyed_img;
    public bool destroed =false;
    private void OnCollisionEnter2D(Collision2D co)
    {
        if(co.transform.CompareTag("ball"))
        {
            destroy();
        }

    }
    void destroy()
    {
        destroed = true;
        paricle_parent.SetActive(true);
        thiscol.enabled = false;
        GetComponent<SpriteRenderer>().sprite = destroyed_img;
        transform.root.GetComponent<door>().el_destroy();
    }
}
