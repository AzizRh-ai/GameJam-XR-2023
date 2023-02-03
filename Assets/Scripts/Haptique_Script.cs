using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Haptique_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Handz = this.GetComponent<GameObject>();
        if (Handz.tag == "ARight")
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
