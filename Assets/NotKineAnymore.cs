using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotKineAnymore : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.constraints = RigidbodyConstraints.None;
    }
}
