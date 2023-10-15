using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class bulets : MonoBehaviour
{
    public bool isboom,yellow;
    public float speed = 10f,rotsp = -0.1f,speed_y;
    public Rigidbody2D rb;
    public GameObject plusshot,dieboom;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.GetChild(0).up * speed + Vector3.up*speed/10f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (yellow)
        {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            
        }
        else if(isboom)
        {
            direction = (transform.GetChild(0).up + Vector3.up * -80f).normalized;
        }
        float angle = Mathf.Atan2(direction.y, direction.x);

            // 라디안 각도를 쿼터니언으로 변환합니다.
            Quaternion rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

            // 부드러운 회전을 위해 Quaternion.Slerp를 사용
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotsp * Time.fixedDeltaTime);
            rb.velocity = (Vector2.Lerp( rb.velocity,(Vector2)transform.GetChild(0).up * speed,10f * Time.deltaTime));
    }

    public void hit()
    {
        Instantiate(plusshot, transform.root.position, transform.root.rotation);
        Destroy(transform.root.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isboom)
            Instantiate(dieboom, transform.position, transform.rotation);

        if (col.transform.CompareTag("ball"))
        {
            col.rigidbody.velocity = Vector2.up * speed_y;
        }

            if (col.transform.CompareTag("grab"))
        {

        }
        else
        {
            Destroy(transform.root.gameObject);

        }
    }

    
}
