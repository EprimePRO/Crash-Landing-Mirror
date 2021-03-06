﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringTurret : Turret {
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
        foreach (Enemy e in this.level.enemyList) {
            float dist = (curPos - e.position).magnitude;
            if (dist < closest.Item2 && dist <= range) {
                closest = (e, dist);
            }
        }
        (this.currentTarget, _) = closest;
    }

    protected virtual void fire() {
        if (this.currentTarget == null) {
            return;
        }
        if (this.timeTillFire <= 0f) {
            this.timeTillFire = 1f / this.fireRate;
            this.spawnProjectile();
        }
    }


    public void FixedUpdate() {
        if (!placed) {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            transform.position = mouse;
            return;
        }
        this.timeTillFire -= Time.fixedDeltaTime;

        this.findTarget();
        if (this.currentTarget != null) {
            //transform.LookAt(currentTarget.transform);
            Vector2 look = this.currentTarget.transform.position - this.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg * -1f);
        }
        this.fire();
    }

}
