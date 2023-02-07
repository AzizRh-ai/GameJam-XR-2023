using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{


    private void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime*90);
    }
}
