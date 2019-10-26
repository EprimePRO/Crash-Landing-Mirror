using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthyEntity {
    public Entity target;
    public int damage;
    public float range;
    public float attackrate;
    public float lastattack;

    Entity selectTarget(List<Turret> turrets, Player player, Rocket rocket) {
        if (Vector2.Distance(transform.position, player.transform.position) >= Vector2.Distance(transform.position, rocket.transform.position)) {
            target = rocket;
        } else {
            target = player;
        }
        foreach (Turret t in turrets) {
            if (Vector2.Distance(transform.position, target.transform.position) > Vector2.Distance(transform.position, t.transform.position)) {
                target = t;
            }
        }
        return target;
    }

    void moveToTarget() {
        float speed = Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
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
        if (Time.time >= lastattack && Vector2.Distance(transform.position, target.transform.position) <= range) {
            return true;
        } else {
            return false;
        }
    }


    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {
        selectTarget(level.turretList, level.player, level.rocket);
        moveToTarget();
        attackTarget();
    }
}
