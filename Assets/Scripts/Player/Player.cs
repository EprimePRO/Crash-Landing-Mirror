using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : HealthyEntity {
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    public float radius = 5.12f;
    public Text healthText;

    Vector2 movement;

    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //set the player's current health in the UI
        healthText.text = ((int)System.Math.Round(health)).ToString();
        health -= Time.deltaTime; //to be deleted
    }

    private void FixedUpdate() {
        Vector2 pos = rb.position;
        pos += movement * moveSpeed * Time.fixedDeltaTime;

        float magnitude = pos.magnitude;

        if (magnitude > radius) {
            pos = pos.normalized * radius;
        }

        rb.position = pos;
    }

}
