using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadDeMovimiento;
    public Image barraDeVida;
    public float vida;
    public Text porcentajeDeVida;
    public int enenemigosDestruidos;
    public bool activoItem;
    float timeController;
    public float timepoDeDuracionItem;
    public int contadorDeEnemigos;
    SpawnEnemyControler controlEnemys;
    public GameObject panelWin;
    public Camera mainCam;
    void Start()
    {
        controlEnemys = GameObject.Find("SpawnEnemies").GetComponent<SpawnEnemyControler>();
        Time.timeScale = 1f;
    }

   
    void Update()
    {
       
        vida = Mathf.Clamp(vida, 0, 100f);
        barraDeVida.fillAmount = vida / 100;
        porcentajeDeVida.text = vida.ToString() + "%";
        Movimiento();
        ControlDeItems();
        ControlDeActivacionItem();
        ControlDeVida();
        GameVictory();
        

    }

    public void Movimiento()
    {
        if(activoItem)
        {
            velocidadDeMovimiento = 18;
        }
        else
        {
            velocidadDeMovimiento = 15;
        }



        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, -2.9f, 4f), transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, mainCam.transform.position.x-9, mainCam.transform.position.x+9), Mathf.Clamp(transform.position.y, -2.9f, 4f), transform.position.z);

        Vector3 acelerometroVector = new Vector3(Mathf.Clamp(Input.acceleration.x, -7, 7), Mathf.Clamp(Input.acceleration.y, -2.9f, 4f), 0);

        transform.Translate(acelerometroVector * velocidadDeMovimiento * Time.deltaTime);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.up * velocidadDeMovimiento * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.down * velocidadDeMovimiento * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * velocidadDeMovimiento * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * velocidadDeMovimiento * Time.deltaTime);
        //}


    }
    public void ControlDeVida()
    {
        if (vida <= 0.0f)
        {
            SceneManager.LoadScene(2);
        }
    }


    public void ControlDeItems()
    {
        if(enenemigosDestruidos>1)
        {
            enenemigosDestruidos = 0;
        }
    }
    

    public void GameVictory()
    {
        if(contadorDeEnemigos>=controlEnemys.cantidadMaximaDeEnemigos)
        {

            panelWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ControlDeActivacionItem()
    {
        //if (activoItem)
        //{
        //    timeController += 0.1f * Time.deltaTime;

        //}

        //if (timeController >= timepoDeDuracionItem)
        //{
        //    activoItem = false;
        //    timeController = 0.0f;
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("AddVelocity"))
        {
            activoItem = true;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("AddLife"))
        {
            vida += 7f;
            Destroy(collision.gameObject);
        }
    }
}
