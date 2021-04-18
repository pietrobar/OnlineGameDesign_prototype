using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform cam;
    

    private void Update()
    {
        if (!cam && Camera.main)
        {
            cam = Camera.main.transform;
        }
    }


    // Chiamato dopo l'Update, così da farlo dopo che la camera si è spostata
    void LateUpdate()
    {
        if (cam)
            transform.LookAt(transform.position + cam.forward);
    }
}
