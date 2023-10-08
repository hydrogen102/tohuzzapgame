using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electronic_box : MonoBehaviour
{
    public GameObject paricle_parent, enemy_spawn;
    public Collider2D thiscol;
    public Sprite destroyed_img;
    public bool destroed =false;

    private void Awake()
    {
        if(enemy_spawn != null)
        enemy_spawn.SetActive(false);
    }
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
        Destroy(transform.GetChild(1).gameObject);

        if(enemy_spawn != null)
        {
        enemy_spawn.SetActive(true);

        while(enemy_spawn.transform.childCount > 0)
            {
                enemy_spawn.transform.GetChild(0).parent = null;
            }
            Destroy(enemy_spawn.gameObject);
        }

    }
}
