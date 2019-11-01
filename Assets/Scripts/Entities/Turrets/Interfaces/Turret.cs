using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : HealthyEntity {
    public bool placed = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject c = collision.gameObject;
        if (c.CompareTag("level"))
        {
            if (!placed)
            {
                transform.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0, 0.5f);
            }
        }
        else if (c.CompareTag("turret"))
        {
            if (!placed)
            {
                transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject c = collision.gameObject;
        if (c.CompareTag("level"))
        {
            if (!placed)
            {
                transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            }
        }
        else if (c.CompareTag("turret"))
        {
            if (!placed)
            {
                transform.GetComponent<SpriteRenderer>().color = new Color(100, 0, 0, 0.5f);
            }
        }
    }
}
