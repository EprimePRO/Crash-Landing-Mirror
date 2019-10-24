using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    
    public GameObject[] enemiesPrefabs;
    public GameObject playerPrefab = null;
    public GameObject player;
    public GameObject[] turretsPrefab = null;
    //public GameObject[] turrets;
    public GameObject rocketPrefab = null;
    public GameObject rocket;
    public List<GameObject> turretList;
    public List<GameObject> enemyList;

    void spawnEnemy() {
        foreach (GameObject e in enemiesPrefabs) {
            for (int i = 0; i < 5; i++) {
                GameObject enemy = Instantiate(e, new Vector2(i * 5, -10), Quaternion.identity);
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
    void Start() {
        Debug.Log("Start called");
        player = Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity);
        rocket = Instantiate(rocketPrefab, new Vector2(0, 0), Quaternion.identity);
        int i = 0;
        foreach (GameObject e in turretsPrefab) {
            GameObject turret = Instantiate(e, new Vector2(i * 5, 0), Quaternion.identity);
            turretList.Add(turret);
            i++;
        }
        spawnEnemy();
    }

    // Update is called once per frame
    void Update() {

    }
}
