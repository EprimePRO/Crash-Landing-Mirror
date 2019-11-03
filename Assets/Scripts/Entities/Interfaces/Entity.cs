using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour {
    public Level level;

    /// <summary>
    /// The sprite renderer for this entity
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// The sprite of this Entity
    /// </summary>
    public virtual Sprite sprite {
        get => this.spriteRenderer.sprite;
        set => this.spriteRenderer.sprite = value;
    }

    /// <summary>
    /// The name of this Entity
    /// </summary>
    new public string name;

    /// <summary>
    /// This Entity's position
    /// </summary>
    public Vector2 position {
        get => this.gameObject.transform.position;
        set => this.gameObject.transform.position = value;
    }

    public void Awake() {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.level = GameObject.FindObjectOfType<Level>();
    }

    public void Start() {

    }
}
