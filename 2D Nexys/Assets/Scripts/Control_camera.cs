using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_camera : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.position;
        position.z = -10.0f;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
