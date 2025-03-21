using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float ZhenFu = 1f;
    public float Pinlv = 2f;

    public float iniDownSpeed = 8f;
    public float decelerationRate = 3f;
    public float minSpeed = 4f;
    public float targetY = -9.45f;

    private bool isActivated = false;
    private float curDownSpeed;
    private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        curDownSpeed = iniDownSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActivated)
        {
            float NewY = initialPosition.y + Mathf.Sin(Time.time * Pinlv) * ZhenFu;
            transform.position = new Vector3(initialPosition.x, NewY, transform.position.z);
        }
        else
        {
            if(transform.position.y > targetY)
            {
                transform.Translate(Vector2.down * curDownSpeed * Time.deltaTime);
                curDownSpeed = Mathf.Max(curDownSpeed - decelerationRate * Time.deltaTime, minSpeed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isActivated && collision.gameObject.CompareTag("Player"))
        {
            initialPosition = transform.position;
            isActivated = true;

            Collider2D col = GetComponent<Collider2D>();
            if(col!=null) col.enabled = true;
        }
    }
}
