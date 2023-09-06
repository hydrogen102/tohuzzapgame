
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class wptow : MonoBehaviour
{
    public TargetJoint2D tj;
    public Transform tr;
    Vector3 tpos;
    Quaternion trot;

    float last;
    public float time;
    public Animator ani;
    public bool wpab,haswp;
    bool trac;
    BoxCollider2D col;

    bool coli;
    
    public GameObject gunfire;
    // Start is called before the first frame update
    void Start()
    {

        if(wpab)
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

            if(trac||haswp)
            {
                tj.enabled = true;
                tj.target = (Vector2)tr.position;
            }
            else
            {
                    tj.enabled = false;
            }
            if(Input.GetButton("Fire2"))
            {
                    trac = true;
                    if(wpab)
                    col.enabled = true;
            }
            else
            {
               trac=false;
                if (wpab)
                    col.enabled = coli;
            }



        
        //tpos = transform.position;
        //trot = transform.rotation; 
    }



    public void OnAtorpt()
    {
        tj.enabled = true;
        tj.target = (Vector2)tr.position;
    }

    public void Ondisatpt()
    {
        tj.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D wps)
    {
    }
    
}
