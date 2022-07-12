using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public bool oyunAktif = true;
    public int altinSayisi = 0;
    public UnityEngine.UI.Text altinSayisiText;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        GetComponent<AudioSource>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void AltinArttir()
    {
        altinSayisi += 1;
        altinSayisiText.text = "" + altinSayisi;
    }

   

    public void SahneGec() {
        if(altinSayisi == 3)
        {
            SceneManager.LoadScene("AdaSahnesi");
        }
    }
}
