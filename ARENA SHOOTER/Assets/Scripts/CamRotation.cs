using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    public float sentative;
    float xRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }
    void rotation()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sentative;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sentative;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
