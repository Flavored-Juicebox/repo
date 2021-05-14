using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_individual : MonoBehaviour
{ 
    [SerializeField] Rigidbody rb;
    void OnCollisionEnter(Collision collision)
    {
        //rb.AddForce(Vector3.forward * 25f);
        Destroy(gameObject);
    }
}
