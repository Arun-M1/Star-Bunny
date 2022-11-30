using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (FacingRight())
        {
            //move right
            rb.velocity = new Vector2(speed, 0f);

        }
        else
        {
            //move left
            rb.velocity = new Vector2(-speed, 0f);
        }
    }

    private bool FacingRight()
    {
        return transform.localPosition.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //turn
        transform.localPosition = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);

    }
}
