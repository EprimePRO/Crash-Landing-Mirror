using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public new Camera camera;

    float cameraDistanceMax = 8f;
    float cameraDistanceMin = 2f;
    float cameraDistance = 5f;
    float scrollSpeed = 100f;


    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * -1 * Time.fixedDeltaTime;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        camera.orthographicSize = cameraDistance;
    }

    private void LateUpdate()
    {
        camera.transform.position = player.transform.position + offset;
    }
}
