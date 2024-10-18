using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject objectToFocus;
    [SerializeField]
    float cameraDistance;
    [SerializeField]
    float cameraHight;
    // Start is called before the first frame update
    void Start()
    {
        updateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        updateCamera();
    }

    void updateCameraRotation()
    {
        Quaternion cameraRotation = objectToFocus.transform.rotation;
        //Quaternion rotationOffset = Quaternion.Euler(0, 0, 0);
        transform.rotation = cameraRotation;
    }

    void updateCameraPosition()
    {
        float camPosX = objectToFocus.transform.position.x;
        float camPosY = objectToFocus.transform.position.y + cameraHight;
        float camPosZ = objectToFocus.transform.position.z;
        Vector3 camPosition = new Vector3(camPosX, camPosY, camPosZ) - (transform.forward * cameraDistance);
        transform.position = camPosition;
    }

    void updateCamera()
    {
        updateCameraRotation();
        updateCameraPosition();
    }
}
