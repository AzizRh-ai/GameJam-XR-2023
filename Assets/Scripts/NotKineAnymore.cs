using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.XR;

public class NotKineAnymore : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.constraints = RigidbodyConstraints.None;

        GameObject Handz = this.GetComponent<GameObject>();
        if (Handz.name == "ARight")
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            device.SendHapticImpulse(0, 0.4f, 0.1f);
        }
        else
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            device.SendHapticImpulse(0, 0.4f, 0.1f);
        }
    }
}
