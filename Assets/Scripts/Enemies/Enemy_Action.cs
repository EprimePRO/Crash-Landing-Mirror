using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action : MonoBehaviour
{
    // Start is called before the first frame update

    new Transform transform;
    Entity target;
    public void SelectMovement(Enemy obj)
    {
        transform = obj.transform;
        target = obj.target;

        if (obj.tag == "circlemove")
            CircleMovement();
        else if (obj.tag == "backforthmove")
            BackforthMovement();
        else
            NormalMovement();

    }

    void NormalMovement()
    {
        float speed = Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
        Vector2 look = target.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg * -1f);
    }
    void CircleMovement()
    {
        float speed = Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position + transform.right * Mathf.Sin(Time.time) * speed * 3f, target.transform.position, speed);
        Vector2 look = target.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg * -1f);
    }

    void BackforthMovement()
    {
        float speed = Mathf.Ceil(Mathf.Sin(Time.time * 3f)) * Time.deltaTime;
        Debug.Log(speed);
        transform.position = Vector2.MoveTowards(transform.position + transform.up * Mathf.Sin(Time.time * 3f) * 0.04f, target.transform.position, speed);
        Vector2 look = target.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(look.x, look.y) * Mathf.Rad2Deg * -1f);
    }
}
