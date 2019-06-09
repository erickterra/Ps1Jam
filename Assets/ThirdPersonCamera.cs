using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
   public float yAngleMin = 0f;
   public float yAngleMax = 50f;
   public Transform lookAt;
   public Transform camTransform;
   private Camera cam;
   public float distance = 10f;
   private float currentX = 0f, currentY = 0f;
   public float sensitivity = 10f;
   private void Start() 
   {
       camTransform = transform;
       cam = Camera.main;
   }

    void LocknUnlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Update() 
    {
        LocknUnlockCursor();
        currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
    }
   private void LateUpdate() 
   {
       Vector3 dir = new Vector3(0f, 0f, -distance);
       Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
       camTransform.position = lookAt.position + rotation * dir;
       camTransform.LookAt(lookAt.position);
   }

}
