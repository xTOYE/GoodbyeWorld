using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using NaughtyAttributes;

public class OnEnter : MonoBehaviour
{
    // Is it going to destroy the incoming object?
    [Tag] public string hitTag = "";
    public bool destroySelf = false;
    public bool destroyOther = false;
    public UnityEvent onEnter;

    void HandleCollision(Collider col)
    {
        // If hitTag matches incoming object's tag OR hitTag is set to nothing
        if (hitTag == col.tag || hitTag == "")
        {
            // Destroy other!
            if (destroyOther)
                Destroy(col.gameObject);

            if (destroySelf)
                Destroy(gameObject);

            // Run Unity Event
            onEnter.Invoke();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        HandleCollision(col);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.collider);
    }
}
