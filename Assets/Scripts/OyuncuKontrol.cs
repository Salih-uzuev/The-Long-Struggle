using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public AudioClip altin, dusme;
    public OyunKontrol oyunk;
    private float hiz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunk.oyunAktif) { 
        float x = Input.GetAxis("Horizontal"); // İleri Tuşu (Yukarı)
        float y = Input.GetAxis("Vertical");  // Geri Tuşu (Aşağı)

        x *= Time.deltaTime * hiz;
        y *= Time.deltaTime * hiz;     // Aşırı Önemli !



        transform.Translate(x, 0f, y);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("altin"))
        {
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);
            oyunk.AltinArttir();

            Destroy(collision.gameObject);

            oyunk.SahneGec();
            
            


        }else if (collision.gameObject.tag.Equals("dusman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 1f);
            oyunk.oyunAktif = false;
            btn.gameObject.SetActive(true);
            Cursor.visible = true;
        }
    }
}
