﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text resourceText;
    public int resources = 0;
    private Turret chosenTurret;

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
            t.placed = true;
            turretList.Add(t);
        }
        
    }

    private float spawnInterval = 1f;
    private float spawnTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnInterval <= spawnTimer)
        {
            GameObject enemy = Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)], Random.insideUnitCircle.normalized * 7f, Quaternion.identity);
            Enemy e = enemy.GetComponent<Enemy>();
            e.attackrate = 5;
            e.lastattack = Time.time;
            enemyList.Add(e);
            spawnTimer = 0f;
        }

        //set the amount of resources on UI
        resourceText.text = resources.ToString();
    }

    private void OnMouseDown()
    {
        if (chosenTurret != null)
        {
            chosenTurret.placed = true;
            chosenTurret.transform.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.5f);
            chosenTurret = null;
        }
    }

    public void PickTurret(TurretButton t)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        GameObject turretGO = Instantiate(t.TurretPrefab, mouse, Quaternion.identity);
        FiringTurret turret = turretGO.GetComponent<FiringTurret>();
        turretList.Add(turret);
        turret.transform.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0, 0.5f);
        this.chosenTurret = turret;
    }

}
