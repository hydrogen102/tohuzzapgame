using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class wiplash : MonoBehaviour
{
   public LineRenderer line;
    public Transform target,grab;
    bool hooking;

    private void OnEnable()
    {
        grab.position = transform.position;
        grab.rotation = transform.rotation;
        grab.gameObject.SetActive(true);
        
    }

    void FixedUpdate()
    {
        
        line.SetPosition(0,transform.position);
        line.SetPosition(1,grab.position);
    }
}
