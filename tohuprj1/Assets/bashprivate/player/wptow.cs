
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class wptow : MonoBehaviour
{
    public TargetJoint2D tj;
    public Transform tr,mother;
    public Rigidbody2D ri;
    public float power;
    public Animator ani;
    public bool wpab,haswp;
    public HingeJoint2D hinge,parent_hinge;
    JointMotor2D motor,parent_motor;
    public GameObject gunfire;
    // Start is called before the first frame update
    private void Awake()
    {
        if (wpab)
        {
            motor = hinge.motor;
            hinge.motor = motor;
            parent_motor = parent_hinge.motor;
            parent_hinge.motor = parent_motor;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        tj.target = (Vector2)tr.position;

        if(wpab)
        {
        motor.motorSpeed = toquecale(transform);
        hinge.motor = motor;

        parent_motor.motorSpeed = toquecale(mother);
        parent_hinge.motor = parent_motor;
        }
    }

    float toquecale(Transform mytr)
    {
        Vector2 directionToTarget = tr.position - mytr.position;
        float angleToTarget = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // 현재 각도와 대상을 향한 각도 차이 계산
        float angleDifference = Mathf.DeltaAngle(mytr.eulerAngles.z, angleToTarget);

        // 토크 적용 방향과 양 결정
        float torque = angleDifference * power;

        return torque;
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
