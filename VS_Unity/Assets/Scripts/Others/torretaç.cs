using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretaç : MonoBehaviour
{
    public Transform puntoDeDisparo; // Objeto que representa el punto de disparo
    public GameObject proyectilPrefab; // Prefab del proyectil
    public GameObject objetivo;
    public float velocidadRotacion = 5f; // Velocidad de rotación de la torreta
    public float shootForce;
    private float tiempo;
    private float dist;
    public float howClose;
    public List<GameObject> objetivos = new List<GameObject>();
    public float fireRate;

    void Start()
    {
        objetivo = null;
    }

    void Update()
    {
        //Apuntar hacia el objetivo
        if (Input.GetKeyDown(KeyCode.Tab))
            SelectEnemy();

        if (objetivo != null) {
            Vector3 direccion = objetivo.transform.position - transform.position;
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);
            if (tiempo >= fireRate)
            {
                if (objetivo.GetComponent<EnemyController>().Life > 0 || objetivo.GetComponent<MobController>().Life > 0)
                {
                    Disparar();
                }
                else
                {
                    SelectEnemy();
                }
                tiempo = 0;
            }
            tiempo += Time.deltaTime;
        } 
        }

    void Disparar()
    {
        //Crear un proyectil en el punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        //Aplicar fuerza al proyectil en la dirección del punto objetivo
        Vector3 direccion = objetivo.transform.position - puntoDeDisparo.position;
        proyectil.GetComponent<Rigidbody>().AddForce(direccion.normalized * shootForce);
    }
    void SelectEnemy()
    {
        
            for (int i = 0; i < objetivos.Count; i++)
            {
                if (objetivos[i]!=null)
                     dist = Vector3.Distance(objetivos[i].transform.position, transform.position);

                if (objetivos[i] != objetivo && dist <= howClose)
                {
                    
                    if (objetivos[i].GetComponent<EnemyController>().Life > 0)
                    {
                        objetivo = objetivos[i];
                        return;
                    }
                }
            }
    }
    
}

