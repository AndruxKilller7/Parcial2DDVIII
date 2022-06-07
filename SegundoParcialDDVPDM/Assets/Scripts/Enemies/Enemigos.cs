using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemigos : MonoBehaviour
{
    public float velocidad;
    public Image barraDeVida;
    public float vida;
    public bool ping;
    public float distanciaDeDisparo;
    public Transform pivoteRayo;
    public bool detectado;
    public float fireRate;
    public float nextFire;
    public GameObject projectile;
    public GameObject explosiveAttack;
    RaycastHit2D hit;
    PlayerMovement playerControl;
    public GameObject[] items;

    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

   
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100f);
        barraDeVida.fillAmount = vida / 100;
        Movimiento();
        DibujarRayCast();
        DisparoEnemigo();
        ControlDeVida();
      

    }

    public void ControlDeVida()
    {
        if(vida<=0.0f)
        {
            Destroy(this.gameObject);
            Instantiate(explosiveAttack,transform.position, explosiveAttack.transform.rotation);
            playerControl.enenemigosDestruidos += 1;
            playerControl.contadorDeEnemigos += 1;
            if(playerControl.enenemigosDestruidos==2)
            {
                Instantiate(items[Random.Range(0,3)], transform.position, items[Random.Range(0, 3)].transform.rotation);
            }
        }
    }

    public void DibujarRayCast()
    {
        hit = Physics2D.Raycast(pivoteRayo.transform.position, pivoteRayo.up, distanciaDeDisparo);

        if (hit.collider == null)
        {
            detectado = false;
            Debug.DrawRay(pivoteRayo.transform.position, pivoteRayo.up * distanciaDeDisparo, Color.red);
        }
        else if (hit.collider.CompareTag("Player"))
        {
            detectado = true;
            Debug.DrawRay(pivoteRayo.transform.position, pivoteRayo.up * distanciaDeDisparo, Color.green);
        }

     


    }
    public void Movimiento()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, -2.9f, 4f), transform.position.z);

        if(ping==false)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        
        if(ping==true)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }

        if(transform.position.x>=7)
        {
            ping = true;
        }

        if (transform.position.x <= -7)
        {
            ping = false;
        }


    }

    public void DisparoEnemigo()
    {
        if (Time.time >= nextFire && detectado)
        {
            nextFire = Time.time + fireRate;
            
            Instantiate(projectile, pivoteRayo.transform.position, pivoteRayo.rotation);
        }

    }
        
      
        


    

}
