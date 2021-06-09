using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    // Update is called once per frame
    public float speed=.5f;
    void Update()
    {
        transform.Translate(Vector3.back *speed);
    }

}
