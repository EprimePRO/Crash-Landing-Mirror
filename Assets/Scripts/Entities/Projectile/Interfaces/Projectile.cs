using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity {
    /// <summary>
    /// The target that this entity is moving towards
    /// </summary>
    public Enemy target;

    /// <summary>
    /// The turret that shot the projectile
    /// </summary>
    public FiringTurret shootingTurret;

    /// <summary>
    /// The speed that this projectile moves at
    /// </summary>
    public float moveSpeed;

    private void move() {
        if(this.target == null) {
            GameObject.Destroy(this);
            return;
        }
        Vector2 curPos = this.position;
        Vector2 goalPos = target.position;
        Vector2 dir = (goalPos - curPos).normalized;
        this.position += dir * this.moveSpeed * Time.fixedDeltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith == this.target.gameObject) {
            Enemy e = collidedWith.GetComponent<Enemy>();
            e.doDamage(this.shootingTurret.damage);
            GameObject.Destroy(this);
        }
    }

    public void FixedUpdate() {
        this.move();
    }
}
