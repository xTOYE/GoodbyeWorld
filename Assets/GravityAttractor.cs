using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    //negative because refering to force and negative force is a pull
    public float gravity = -100f;

    public void Attract(Rigidbody body)
    {
        //vector 3 so it can be pulled in every direction
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        //timesing the movement by the gravity
        body.AddForce(gravityUp * gravity);
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }

}