using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public float fireRate;
    public float nextFire;
    public GameObject projectile;
    public Transform pivotProjectile;
    public bool activoItem;
    float timeController;
    public float timepoDeDuracionItem;
    void Start()
    {
       
    }

    
    void Update()
    {
        ControlDeActivacionItem();
        if (Input.GetMouseButtonDown(1))
        {
            if(activoItem==false)
            {
                Shooting();
            }

            if(activoItem)
            {
                DoubleShooting();
            }
           
        }
    }


    public void Shooting()
    {

        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, pivotProjectile.transform.position, pivotProjectile.rotation);
        }

    }

    public void DoubleShooting()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, new Vector3(pivotProjectile.transform.position.x + 0.3f, pivotProjectile.transform.position.y, pivotProjectile.transform.position.z), pivotProjectile.rotation);
            Instantiate(projectile, new Vector3(pivotProjectile.transform.position.x - 0.3f, pivotProjectile.transform.position.y, pivotProjectile.transform.position.z), pivotProjectile.rotation);
           
        }
    }

    public void ButtonShoot()
    {
        if (activoItem == false)
        {
            Shooting();
        }

        if (activoItem)
        {
            DoubleShooting();
        }
    }

   

    public void ControlDeActivacionItem()
    {
        if(activoItem)
        {
            timeController += 0.1f * Time.deltaTime;

        }

        if(timeController>=timepoDeDuracionItem)
        {
            activoItem = false;
            timeController = 0.0f;
        }
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoubleP"))
        {
            activoItem = true;
            timeController = 0.0f;
            Destroy(collision.gameObject);

        }
    }
}
