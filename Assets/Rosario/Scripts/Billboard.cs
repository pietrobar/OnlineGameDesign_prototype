using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    // Chiamato dopo l'Update, così da farlo dopo che la camera si è spostata
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
