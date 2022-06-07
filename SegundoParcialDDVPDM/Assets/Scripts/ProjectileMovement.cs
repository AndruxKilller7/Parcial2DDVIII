using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float velocidad;
    public GameObject efecto;
    
   
   
    void Start()
    {
       
    }

    
    void Update()
    {
        Movimiento();
    }


    public void Movimiento()
    {
        
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        if(transform.position.y>=5f)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemigos>().vida -= 30f;
            Destroy(this.gameObject);
            Instantiate(efecto, collision.transform.position, collision.transform.rotation);

        }
    }
}
