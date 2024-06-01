using System;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    Rigidbody _rb;
    bool _lock;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (_lock == false)
        {
            _rb.velocity = new Vector3(0, 0, 50);   
        }
        else
        {
            _rb.Sleep();
        }
        
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _lock = true;
        }
    }
}
