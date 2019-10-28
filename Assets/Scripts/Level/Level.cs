using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public GameObject[] enemiesPrefabs;
    public GameObject playerPrefab = null;
    public Player player;
    public GameObject[] turretsPrefab = null;
    public GameObject rocketPrefab = null;
    public Rocket rocket;
    public List<Turret> turretList;
    public List<Enemy> enemyList;

    void spawnEnemy()
    {
        foreach (GameObject enemyPrefab in enemiesPrefabs)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector2(i * 5, -10), Quaternion.identity);
                Enemy e = enemy.GetComponent<Enemy>();
                e.attackrate = 5;
                e.lastattack = Time.time;
                enemyList.Add(e);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start called");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rocket = Instantiate(rocketPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Rocket>();
        for (int i = 0; i < this.turretsPrefab.Length; i += 1)
        {
            GameObject turret = Instantiate(this.turretsPrefab[i], new Vector2((i+0.2f) * 5, 0), Quaternion.identity);
            Turret t = turret.GetComponent<Turret>();
            turretList.Add(t);
        }
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}