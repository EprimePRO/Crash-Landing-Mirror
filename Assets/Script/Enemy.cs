using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float health;
    public GameObject target;
    public int damage;
    public float range;
    public float attackrate;
    public float lastattack;
    public GameObject level;

    GameObject selectTarget(List<GameObject> turrets, GameObject player, GameObject rocket)
    {
        if (Vector2.Distance(transform.position, player.transform.position) >= Vector2.Distance(transform.position, rocket.transform.position))
        {
            target = rocket;
        }
        else
        {
            target = player;
        }
        foreach (GameObject t in turrets)
        {
            if (Vector2.Distance(transform.position, target.transform.position) > Vector2.Distance(transform.position, t.transform.position))
            {
                target = t;
            }
        }
        return target;
    }

    void moveToTarget()
    {
        float speed = Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
    }

    void attackTarget()
    {
        if (ableToAttack())
        {
            lastattack = Time.time+attackrate;
            if (target.GetComponent<Player>())
            {
                Player t = target.GetComponent<Player>();
                t.health = t.health - damage;
                Debug.Log("dealt " + damage + " to Player " + t.name + "(" + t.health + ")");

            }
            else if (target.GetComponent<Rocket>())
            {
                Rocket t = target.GetComponent<Rocket>();
                t.shield_power = t.shield_power - damage;
                Debug.Log("dealt " + damage + " to Rocket " + t.name + "(" + t.shield_power + ")");

            }
            else if (target.GetComponent<Turret>())
            {
                Turret t = target.GetComponent<Turret>();
                Debug.Log("dealt " + damage + " to Turret " + t.name + "(" + ")");

            }
        }
    }

    bool ableToAttack()
    {

        if ((Time.time) >= lastattack && Vector2.Distance(transform.position, target.transform.position) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selectTarget(level.GetComponent<Level>().turretList, level.GetComponent<Level>().player, level.GetComponent<Level>().rocket);
        moveToTarget();
        attackTarget();
    }
}
