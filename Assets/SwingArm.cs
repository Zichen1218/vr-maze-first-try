using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingArm : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rotationPoint;
    public float speed = 1.0f;
    public float direction = 1.0f;
    // Update is called once per frame
    void Update()
    {
        float angle = direction*0.1f*Mathf.Sin(Time.time * speed);
        transform.RotateAround(rotationPoint.position, Vector3.forward, angle);
    }
}
