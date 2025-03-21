using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementUp : MonoBehaviour
{
    public float ZhenFu = 0.4f;
    public float Pinlv = 1.5f;

    public float iniUpSpeed = 0f;
    public float decelerationRate = 2f;
    public float maxSpeed = 5f;
    public float targetY = 5.4f;

    private bool isActivated = false;
    private float curUpSpeed;
    private Vector2 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        curUpSpeed = iniUpSpeed;
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
            if(transform.position.y < targetY)
            {
                transform.Translate(Vector2.up * curUpSpeed * Time.deltaTime);
                curUpSpeed = Mathf.Min(curUpSpeed + decelerationRate * Time.deltaTime, maxSpeed);
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
