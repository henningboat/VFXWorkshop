using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : Singleton<CameraController>
{
   public Vector3 cameraOffset;
    public float speed;
   
   private void Update()
   {
      var targetPosition = Player.Instance.transform.position + cameraOffset;
      transform.position = Vector3.Lerp(transform.position, targetPosition,
         Time.deltaTime * speed);
   }

   public void OverwriteCameraOffset(Vector3 cameraOffset)
   {
      this.cameraOffset = cameraOffset;
   }
}
