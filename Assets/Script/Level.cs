using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{


    public GameObject[] enemies;
    public GameObject player;
    public GameObject[] turrets;
    public GameObject rocket;
    public List<GameObject> turretList;
    public List<GameObject> enemyList;

    void spawnEnemy()
    {
        foreach(GameObject e in enemies)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject enemy = Instantiate(e, new Vector2(i*5, -10), Quaternion.identity);
                enemy.GetComponent<Enemy>().health = 0;
                enemy.GetComponent<Enemy>().target = player;
                enemy.GetComponent<Enemy>().damage = 5;
                enemy.GetComponent<Enemy>().range = 1;
                enemy.GetComponent<Enemy>().attackrate = 5;
                enemy.GetComponent<Enemy>().level = gameObject;
                enemy.GetComponent<Enemy>().lastattack = Time.time;
                enemyList.Add(enemy);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemies = Resources.LoadAll<GameObject>("Enemies");
        player = Instantiate(Resources.Load<GameObject>("PlayerCapsule"), new Vector2(10, 0), Quaternion.identity);
        turrets = Resources.LoadAll<GameObject>("Turrets");
        rocket = Instantiate(Resources.Load<GameObject>("RocketCylinder"), new Vector2(20, 0), Quaternion.identity);
        int i = 0;
        foreach (GameObject e in turrets)
        {
            GameObject turret = Instantiate(e, new Vector2(i*5,0), Quaternion.identity);
            turretList.Add(turret);
            i++;
        }
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
