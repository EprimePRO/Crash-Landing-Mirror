using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    public float radius = 5.12f;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() {
        Vector2 pos = rb.position;
        pos += movement * moveSpeed * Time.fixedDeltaTime;

        float magnitude = pos.magnitude;

        if(magnitude > radius) {
            pos = pos.normalized * radius;
        }

        rb.position = pos;
    }

}
