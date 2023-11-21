using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 RotationSpeed = new Vector3(90, 0, 0);

    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(RotationSpeed*Time.deltaTime);
    }
}
