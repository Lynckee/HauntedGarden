using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputs();
    }


    void MovementInputs()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Z))
        {
            // MoveDirection(transform.forward);
            dir += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //MoveDirection(-transform.forward);
            dir += -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //MoveDirection(transform.right);
            dir += transform.right;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //MoveDirection(-transform.right);
            dir += -transform.right;
        }

        MoveDirection(dir);
    }

    void MoveDirection(Vector3 direction)
    {
        Vector3 forward = direction;
        forward.y = 0.0f;
        forward.Normalize();
        forward *= speed;
        //physicalForm.transform.Translate((new Vector3(forward.x, 0, forward.z) * Time.deltaTime));
        rb.velocity = forward;
    }
}
