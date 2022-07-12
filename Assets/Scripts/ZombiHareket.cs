using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiHareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombiHP = 3;
    private int zombidengelenpuan = 10;
    private float mesafe;
    private RandomOlustur randomz;
    private AudioSource aSouce;
    private bool zombieOluyor = false;
    // Start is called before the first frame update
    void Start()
    {
        aSouce = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("FPSController");
        randomz = GameObject.Find("_Scripts").GetComponent<RandomOlustur>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if(!aSouce.isPlaying)
            aSouce.Play();
            if(!zombieOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSouce.isPlaying)
                aSouce.Stop();
        }
        
    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.gameObject.tag.Equals("mermi")){

            

            zombiHP--;
            if (zombiHP == 0)
            {
                zombieOluyor = true;
                randomz.PuanArttir(zombidengelenpuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject,1.667f);
            }
        }
        
    }
}
