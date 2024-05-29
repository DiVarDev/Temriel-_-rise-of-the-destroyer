using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // OnCollision
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
