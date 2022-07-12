using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void DigerSahneGec()
    {
        SceneManager.LoadScene("oyun");
    }


    public void CikisYap()
    {
        Application.Quit();
    }
}
