using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public LineRenderer lin;
    RaycastHit2D hit2d;
    public LayerMask layer;
    void FixedUpdate()
    {
        hit2d = Physics2D.Raycast(transform.position, transform.right, 250f,layer);
        Vector3[] positions = {Vector3.zero,transform.InverseTransformPoint(hit2d.point)};
        lin.SetPositions(positions);
    }

}
