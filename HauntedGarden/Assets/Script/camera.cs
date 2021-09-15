using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector2 mousePosition = new Vector2();
    public Vector3 rotationS;
    float timer = 0;
    public float speed = 6;
    public float originalSpeed;
    public Quaternion rotationFinal;
    public bool inCinematic;
    public bool ded;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inCinematic || ded)
        {
            return;
        }
        // partie caméra
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        mousePosition = new Vector2(h, v);

        Vector3 currentRotation = transform.rotation.eulerAngles;
        rotationS = currentRotation;
        if ((currentRotation.x - v >= 90 && currentRotation.x - v <= 306))
        {
            return;
        }
        rotationFinal = Quaternion.Euler(currentRotation.x - v, currentRotation.y + h, 0);
        transform.rotation = rotationFinal;

        // partie tremblement 
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        {
           
        }
    }

    public Quaternion getRotation()
    {
        return rotationFinal;
    }
}
