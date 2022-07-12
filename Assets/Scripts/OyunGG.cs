using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunGG : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        UnlockMouse();
        
        puan.text = "Toplam Altın Sayısı :" + PlayerPrefs.GetInt ("puan");
       
    }

   public void YenidenOyna()
    {
        SceneManager.LoadScene("AdaSahnesi");
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OyunKapat()
    {
        Application.Quit();
        
    }
}
