using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthyEntity {
    public Entity target;
    public int damage;
    public float range;
    public float attackrate;
    public float lastattack;
    public int resourceDrop = 1;
    public Enemy_Action action;

    Entity selectTarget(List<Turret> turrets, Player player, Rocket rocket) {
        if ((player == null && rocket != null) || Vector2.Distance(transform.position, player.transform.position) >= Vector2.Distance(transform.position, rocket.transform.position)) {
            target = rocket;

        } else if (player != null) {
            target = player;
        }
        foreach (Turret t in turrets) {
            if ((target == null || Vector2.Distance(transform.position, target.transform.position) > Vector2.Distance(transform.position, t.transform.position))
                && t.placed) {
                target = t;
            }
        }
        return target;
    }

    void moveToTarget() {
        if (target == null)
        {
            return;
        }
        action.SelectMovement(this);
    }

    void attackTarget() {
        if (ableToAttack()) {
            lastattack = Time.time + attackrate;
            if (target is Player p) {
                p.health -= damage;
                Debug.Log("dealt " + damage + " to Player " + p.name + "(" + p.health + ")");

            } else if (target is Rocket r) {
                r.shield_power -= damage;
                Debug.Log("dealt " + damage + " to Rocket " + r.name + "(" + r.shield_power + ")");

            } else if (target is Turret t) {
                Debug.Log("dealt " + damage + " to Turret " + t.name + "(" + ")");
            }
        }
    }

    bool ableToAttack() {
        if (target != null && Time.time >= lastattack && Vector2.Distance(transform.position, target.transform.position) <= range) {
            return true;
        } else {
            return false;
        }
    }

    // Start is called before the first frame update
    new void Start() {
        base.Start();
        action = gameObject.GetComponent<Enemy_Action>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        selectTarget(level.turretList, level.player, level.rocket);
        moveToTarget();
        attackTarget();
    }
}
