using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class miv : MonoBehaviour
{
    public float speed;
    public LayerMask San;
    public Transform duocpheppnhay;
[SerializeField]  private bool duocphepnhay;
    private float movee;
    public float jump;
    private float jumpingg;
    private bool doublejump;
    private bool xoay = true;
    private Rigidbody2D rb;
    private Animator anim;


    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 2f;
    [SerializeField] private TrailRenderer tr;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }
       duocphepnhay = Physics2D.OverlapCircle(duocpheppnhay.position,0.2f,San);
        movee = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movee * speed, rb.velocity.y);
        flip();
        anim.SetFloat("move", Mathf.Abs(movee));
      
        Jumpp();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }


    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(movee * speed, rb.velocity.y);
    }






    void flip()
    {
        if (xoay && movee < 0 || !xoay && movee > 0)
        {
            xoay = !xoay;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;

        }


    }

    private void Jumpp()
    {
        if(duocphepnhay && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
        {
           
            doublejump = false;
        }
       
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
               if(duocphepnhay  || doublejump)
            {

                anim.SetTrigger("jumping");
                rb.velocity = new Vector2(rb.velocity.x, jump);
                doublejump = !doublejump;
            }
           
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
   

   
}
