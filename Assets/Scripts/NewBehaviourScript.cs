using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip atisSesi, olmeSesi, CanAlmaSesi, YaralanmaSesi;
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImaji;
    public RandomOlustur randomz1;
    private float canDegeri = 100f;
    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate (mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 23f;
            Destroy(go.gameObject, 1f);
            Destroy(goPatlama.gameObject, 0.4f);

        }
        
    }

    void OnCollisionEnter(Collision c)
    {

        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(YaralanmaSesi, 1f);

            
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount =  x;
            
            canImaji.color = Color.Lerp(Color.red, Color.green,x);

            if (canDegeri <= 0)
            {
                aSource.PlayOneShot(olmeSesi, 1f);
                randomz1.oyunBitti();
            }

            
        }

        

    }

    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(CanAlmaSesi, 1f);
            canDegeri += 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount = x;

            canImaji.color = Color.Lerp(Color.red, Color.green, x);

            Destroy(o.gameObject);
            


        }
    }
}
