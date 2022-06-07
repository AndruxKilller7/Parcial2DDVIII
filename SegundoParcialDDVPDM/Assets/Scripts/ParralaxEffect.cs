using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParralaxEffect : MonoBehaviour
{
    [SerializeField]
    RawImage imagenBackground;
    [SerializeField]
    float velocidadDeMovimiento;
    [SerializeField]
    Vector2 direccion;
    Rect rect;


    void Start()
    {

        rect = imagenBackground.uvRect;
    }

    private void Update()
    {
        rect.y += direccion.y*velocidadDeMovimiento* Time.deltaTime;
        rect.x += direccion.x * velocidadDeMovimiento * Time.deltaTime;
        imagenBackground.uvRect = rect;
        //transform.Translate(Vector2.down * velocidadDeMovimiento * Time.deltaTime);
        //if (transform.position.y < -5)
        //{
        //    transform.position= new Vector3(transform.position.x,transform.position.y+10,transform.position.z);
        //}
       
    }


   
}
