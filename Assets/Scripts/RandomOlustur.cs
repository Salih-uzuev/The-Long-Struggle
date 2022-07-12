using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomOlustur : MonoBehaviour
{
    public GameObject  Zombie_01;
    private float zamanSayaci;
    private float olusumSureci = 10f;
    public Text Puan;
    private int puan;
    // Start is called before the first frame update
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {

        zamanSayaci -= Time.deltaTime;
        if(zamanSayaci< 0)
        {
            Vector3 pos = new Vector3(Random.Range(104f, 281f), 23.52f, Random.Range(268f, 268f));
            Instantiate(Zombie_01, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
        
    }

    public void PuanArttir(int p)
    {
        puan += p;
        Puan.text = "" + puan;
    }

    public void oyunBitti()
    {
        PlayerPrefs.SetInt("puan",puan);
        SceneManager.LoadScene("bitti");
        Cursor.visible = true;
    }
}
