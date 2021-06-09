using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 5 * Time.deltaTime, Space.Self);
    }
}
