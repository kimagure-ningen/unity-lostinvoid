using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    Quaternion targetRot;
    Quaternion startRot;
    Vector3 axis = Vector3.up;
    float interpolant = 0.2f;
    float sec;

    void Update() {
        //! fix here
        if (Input.GetKey(KeyCode.W)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = 0f; 
            transform.localEulerAngles = localAngle;  
        }

        // if (Input.GetKey(KeyCode.S)) {
        //     Vector3 localAngle = transform.localEulerAngles;
        //     localAngle.y = 180f; 
        //     transform.localEulerAngles = localAngle;  
        // }

        if (Input.GetKey(KeyCode.S)) {
            startRot = transform.rotation;
            targetRot = Quaternion.AngleAxis(180f, axis) * transform.rotation;
            sec += Time.deltaTime;   
            transform.rotation = Quaternion.Lerp(startRot, targetRot, sec * interpolant);
        }

        if (Input.GetKey(KeyCode.A)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = -90f; 
            transform.localEulerAngles = localAngle;  
        }
        
        if (Input.GetKey(KeyCode.D)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = 90f; 
            transform.localEulerAngles = localAngle;  
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = -45f; 
            transform.localEulerAngles = localAngle;  
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = 45f; 
            transform.localEulerAngles = localAngle;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = -135f; 
            transform.localEulerAngles = localAngle;  
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y = 135f; 
            transform.localEulerAngles = localAngle;  
        }
    }
}
