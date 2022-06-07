using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyControler : MonoBehaviour
{
    public int cantidadMaximaDeEnemigos;
    public int cantidadCount;
    public float tiempoDeSpawn;
    public float tiempoTranscurrido;
    public GameObject modeloDeEnemigo;
    public bool encendido;
    void Start()
    {
        Instantiate(modeloDeEnemigo, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(1.0f, 3.3f), transform.position.z), modeloDeEnemigo.transform.rotation);
        cantidadCount += 1;
    }

   
    void Update()
    {
        SpawmNow();
    }

    public void SpawmNow()
    {
        if(encendido)
        {
            tiempoTranscurrido += 0.1f * Time.deltaTime;

            if (tiempoTranscurrido >= tiempoDeSpawn)
            {
                Instantiate(modeloDeEnemigo, new Vector3(Random.Range(-7.5f,7.5f), Random.Range(1.0f, 3.3f), transform.position.z), modeloDeEnemigo.transform.rotation);
                tiempoTranscurrido = 0.0f;
                //cantidadMaximaDeEnemigos -= 1;
                cantidadCount += 1;
            }
        }
        if(cantidadCount>=cantidadMaximaDeEnemigos)
        {
            encendido = false;
        }
        
       
    }
}
