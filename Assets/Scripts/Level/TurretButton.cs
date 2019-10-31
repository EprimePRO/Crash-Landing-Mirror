using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretButton : MonoBehaviour
{
    [SerializeField]
    private GameObject turretPrefab;

    public GameObject TurretPrefab { get => turretPrefab; }
}
