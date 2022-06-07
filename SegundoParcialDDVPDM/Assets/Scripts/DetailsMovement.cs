using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsMovement : MonoBehaviour
{
    public float velocidad;

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        if(transform.position.y>25f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-43f, transform.position.z);
        }
    }
}
