using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera camera;

    float cameraDistanceMax = 5f;
    float cameraDistanceMin = 2f;
    float cameraDistance = 5f;
    float scrollSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * -1 * Time.fixedDeltaTime;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        camera.orthographicSize = cameraDistance;
    }
}
