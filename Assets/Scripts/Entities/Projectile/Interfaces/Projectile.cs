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
        if (this.target == null) {
            Destroy(gameObject);
            return;
        }
        Vector2 curPos = this.position;
        Vector2 goalPos = target.position;
        Vector2 diffVec = goalPos - curPos;
        Vector2 dir = diffVec.normalized;
        float expectedDist = this.moveSpeed * Time.fixedDeltaTime;
        float neededDist = diffVec.magnitude;
        float actualDist = Mathf.Min(expectedDist, neededDist);
        this.position += dir * actualDist;
        Vector2 look = target.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg * -1f);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith == this.target.gameObject) {
            Enemy e = collidedWith.GetComponent<Enemy>();
            e.doDamage(this.shootingTurret.damage);
            Destroy(gameObject);
        }
    }

    public void FixedUpdate() {
        this.move();
    }
}
