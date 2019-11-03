using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TurretButton : MonoBehaviour {
    [SerializeField]
    private GameObject turretPrefab;

    public GameObject TurretPrefab { get => turretPrefab; }

    private Entity entComponent;
    private Image img;

    public void Start() {
        this.img = this.GetComponent<Image>();
        this.entComponent = turretPrefab.GetComponent<Entity>();
        //Have to manually awake the component since Awake is not called on prefabs
        this.entComponent.Awake();
        this.img.sprite = this.entComponent.sprite;
    }
}
