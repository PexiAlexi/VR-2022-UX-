using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportback : MonoBehaviour
{
    public Transform[] teleportTargets; // the positions to teleport to
    public GameObject[] objectsToTeleport; // the objects to teleport
    public float pauseTime = 0.1f; // the amount of time to pause the object after teleporting

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objectsToTeleport.Length; i++)
        {
            if (other.gameObject == objectsToTeleport[i])
            {
                Rigidbody rb = objectsToTeleport[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero; // set velocity to zero
                }
                objectsToTeleport[i].transform.position = teleportTargets[i].position; // teleport the object
                Invoke("ResumeObject", pauseTime); // resume object after pauseTime
            }
        }
    }

    private void ResumeObject()
    {
        for (int i = 0; i < objectsToTeleport.Length; i++)
        {
            Rigidbody rb = objectsToTeleport[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // set velocity to zero again just to be safe
                rb.WakeUp(); // wake up the rigidbody after pausing
            }
        }
    }
}
