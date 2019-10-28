using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringTurret : Turret {
    /// <summary>
    /// Damage the turret does per shot
    /// </summary>
    public float damage;
    /// <summary>
    /// How many times this turret fires per second. 1f = Fires once per second, 2f = Fires twice per second, etc..
    /// </summary>
    public float fireRate;

    /// <summary>
    /// The range of this turret's effectiveness
    /// </summary>
    public float range;

    //TODO: Change Entity? to Enemy?
    /// <summary>
    /// The entity that this turret is currently targeting
    /// </summary>
    public Enemy currentTarget;

    /// <summary>
    /// How long until this turret can fire again
    /// </summary>
    protected float timeTillFire;

    public GameObject projectilePrefab;

    protected virtual Projectile spawnProjectile() {
        GameObject g = Instantiate(projectilePrefab, transform);
        Projectile p = g.GetComponent<Projectile>();
        p.shootingTurret = this;
        p.target = this.currentTarget;
        return p;
    }

    protected virtual void findTarget() {
        (Enemy, float) closest = ((Enemy)null, float.MaxValue);
        Vector2 curPos = this.position;
        foreach(Enemy e in this.level.enemyList) {
            float dist = (curPos - e.position).magnitude;
            if(dist < closest.Item2) {
                closest = (e, dist);
            }
        }
        (this.currentTarget, _) = closest; 
    }

    protected virtual void fire() {
        if (this.currentTarget == null) {
            return;
        }
        this.timeTillFire -= Time.fixedDeltaTime;
        if (this.timeTillFire <= 0f) {
            this.timeTillFire = 1f / this.fireRate;
            this.spawnProjectile();
        }
    }

    public void FixedUpdate() {
        this.findTarget();
        this.fire();
    }

}
