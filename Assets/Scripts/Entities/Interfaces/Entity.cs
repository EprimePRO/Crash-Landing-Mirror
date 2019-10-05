using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    /// <summary>
    /// The sprite of this Entity
    /// </summary>
    public virtual Sprite sprite { get; protected set; }

    /// <summary>
    /// The name of this Entity
    /// </summary>
    new public string name { get; set; }

    /// <summary>
    /// This Entity's position
    /// </summary>
    public Vector2 position {
        get => this.gameObject.transform.position;
        set => this.gameObject.transform.position = value; 
    }

    /// <summary>
    /// Spawns a new GameObject and adds the component
    /// </summary>
    /// <typeparam name="T">The type of the Entity</typeparam>
    /// <param name="position">The position of the Entity</param>
    /// <param name="sprite">The sprite of the Entity</param>
    /// <returns>The component</returns>
    public static T spawnEntity<T>(Vector2 position, Sprite sprite) where T: Entity {
        GameObject go = new GameObject();
        T t = go.AddComponent<T>();
        t.position = position;
        t.sprite = sprite;
        return t;
    }
}
