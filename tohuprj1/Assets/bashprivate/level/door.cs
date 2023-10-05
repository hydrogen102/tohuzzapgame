using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform door_parent,box_par;
    Animator [] doors;
    electronic_box[] boxes;
    public string ani_par_name;
    public bool all_destroyed;

    void Awake()
    {
        doors = door_parent.GetComponentsInChildren<Animator>();
        boxes = box_par.GetComponentsInChildren<electronic_box>();
    }

    // Update is called once per frame
    public void el_destroy()
    {
       all_destroyed = true;
        for(int i = 0; i < boxes.Length; i++)
        {
            all_destroyed = all_destroyed && boxes[i].destroed;
        }

        if(all_destroyed)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetTrigger(ani_par_name);
            }
        }


    }
}
