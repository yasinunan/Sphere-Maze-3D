using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGravity : MonoBehaviour
{
    public Transform gravityTarget;

    public float power;
    public float torque;
    public float gravity;

    public bool autoOrient;
    public float autoOrientSpeed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
       // ProcessInput();
        ProcessGravity();
    }

    void ProcessInput()
    {
        float vt = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(0f, 0f, vt * power);
        rb.AddRelativeForce(force);


        float hz = Input.GetAxis("Horizontal");
        Vector3 rforce = new Vector3(0f, 0f, vt * power);
        rb.AddRelativeTorque(rforce);
    }
    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized*gravity* (rb.mass));

        if (autoOrient)
        {
            AutoOrient(-diff);
        }
    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, autoOrientSpeed * Time.deltaTime);
    }
}
