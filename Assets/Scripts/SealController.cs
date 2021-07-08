using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;

    public float MaxHeight;
    public float FlapVelocity;

    public float relativeVelocityX;
    public GameObject sprite;

    public bool IsDead()
    {
        return isDead;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& transform.position.y < MaxHeight)
        {
            if (isDead) return;
            Flap();
        }

        // °¢µµ ¹Ý¿µ
        ApplyAngle();

        animator.SetBool("flap", angle >= 0.0f);
    }

    public void Flap()
    {
        rb2d.velocity = new Vector2(0.0f, FlapVelocity);
    }

    private void ApplyAngle()
    {
        float targetAngle;

        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }

            Debug.Log(targetAngle);

            angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

            sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);


    }

    //ºÎµúÈú¶§ ÄÝ¹é
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        this.isDead = true;
    }
}
