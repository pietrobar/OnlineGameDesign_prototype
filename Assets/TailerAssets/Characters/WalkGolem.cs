using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkGolem : MonoBehaviour
{

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + transform.forward * Time.deltaTime *.70f);
    }
}
