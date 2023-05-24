using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{

    public GameObject Camera;
    public bool aiming;
    public bool CanShoot;
    public GameObject CanonBall;
    public GameObject CanonSpawn;
    public GameObject mirilla;

    public float tiempo;
    public float CanonCooldown;

    public GameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        aiming = Camera.GetComponent<CameraController>().aiming;

        if (aiming)
        {
            this.transform.rotation = Camera.transform.rotation;
            manager.CompleteQuest(0, 2);


        }
        if (!CanShoot)
         {
             tiempo += Time.deltaTime;
             if (tiempo >= CanonCooldown)
             {
                 tiempo = 0;
                 CanShoot = true;
             }

         }

        if (Input.GetKey(KeyCode.Space) && CanShoot && aiming)
        {
            GameObject _canon = Instantiate(CanonBall);
            manager.CompleteQuest(0, 3);




            CanShoot = false;
        }
    }
}
