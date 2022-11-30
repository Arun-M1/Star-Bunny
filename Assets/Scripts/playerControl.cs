using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{

    public float moveSpeed;
    float moveInput;
    Rigidbody2D rb;
    float scaleX;
    public float jumpForce;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    bool isGrounded;
    private Animator anim;

    public List<string> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();

        rb = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void Flip()
    {
        if(moveInput > 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        } 

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {
        CheckIfGrounded(); 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
            }
        }
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("StarItem"))
        {
            //print("we have collected a star");
            string itemType = collision.gameObject.GetComponent<ItemCollecter>().itemType;
            print("we have collected a : " + itemType);

            Debug.Log(collision.gameObject);

            items.Add(itemType);
            print("Items length: " + items.Count);

            Destroy(collision.gameObject);

        }
    }
}
