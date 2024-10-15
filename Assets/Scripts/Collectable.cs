using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotateItem();
    }

    void rotateItem()
    {
        float rotY = transform.eulerAngles.y + rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotY, 0);
    }
}