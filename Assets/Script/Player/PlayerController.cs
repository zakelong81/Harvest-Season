using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public float playerSpeed = 4f;
    public float stamia;
    public float MAXSTAMINA = 10;
    public bool out_stamina = false;
    public bool facingRight = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (out_stamina == true)
        {
            anim.SetInteger("State", 4);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("State", 2);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 1);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("State", 1);
            }
            else
            {
                anim.SetInteger("State", 0);
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;

        if (out_stamina == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed * 3;
                if (stamia < 0)
                {
                    out_stamina = true;
                }
                else
                {
                    stamia = stamia - Time.deltaTime;
                }
            }
            else
            {
                if (stamia < MAXSTAMINA)
                    stamia = stamia + Time.deltaTime;
            }            
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = targetVelocity * 0;
            stamia = stamia + Time.deltaTime;
            if (stamia > 2)
            {
                out_stamina = false;
            }
        }
       
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}