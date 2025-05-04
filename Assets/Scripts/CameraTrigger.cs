using System;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Vector3 cameraOffset;
    
    private void OnTriggerEnter(Collider other)
    {
        CameraController.Instance.OverwriteCameraOffset(cameraOffset);
    }
}
