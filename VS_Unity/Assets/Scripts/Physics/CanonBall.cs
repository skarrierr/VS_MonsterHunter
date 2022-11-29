using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float force;
    public GameObject Spawnpoint;
 
    void Start()
    {
        Spawnpoint = GameObject.FindGameObjectWithTag("SpawnCanon");

        transform.position = Spawnpoint.transform.position;
        transform.rotation = Spawnpoint.transform.rotation;
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }
    

}
