using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiringTurret : Turret {
    /// <summary>
    /// Damage the turret does per shot
    /// </summary>
    public float damage { get; set; }
    /// <summary>
    /// How many times this turret fires per second. 1f = Fires once per second, 2f = Fires twice per second, etc..
    /// </summary>
    public float fireRate { get; set; }

    /// <summary>
    /// The range of this turret's effectiveness
    /// </summary>
    public float range { get; set; }
    
    //TODO: Change Entity? to Enemy?
    /// <summary>
    /// The entity that this turret is currently targeting
    /// </summary>
    public Entity? currentTarget { get; set; }

    /// <summary>
    /// How long until this turret can fire again
    /// </summary>
    protected float timeTillFire { get; set; }

    protected abstract Projectile spawnProjectile();

    public void FixedUpdate() {
        this.timeTillFire -= Time.fixedDeltaTime;
        if(this.timeTillFire <= 0f) {
            this.timeTillFire = 1f / this.fireRate;
            Projectile p = this.spawnProjectile();
            p.target = this.currentTarget;
        }
    }



}
