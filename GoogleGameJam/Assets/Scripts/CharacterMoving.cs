using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shoot
{
    public class CharacterMoving : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public Animator anim;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;

    private bool isRunning = false;

    void Start()
    {
        
    }
    void Update()
    {
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);

        if(!isFacingRight && horizontal >0f)
        {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        anim.SetBool("IsRunning", isRunning);
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 shootDirection = isFacingRight ? firePoint.right : firePoint.right * -1;
            rb.AddForce(shootDirection * 2f, ForceMode2D.Impulse);
        }
    }


   

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
         isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        isRunning = Mathf.Abs(horizontal) > 0f;
    }

    } 
}

