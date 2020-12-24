using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector2 target;
    private Vector2 awal;
    private float speed = 10f;
    
    void Start()
    {
        //LeanTween.moveX(gameObject, 300, 2);
    }

    void Update()
    {
        
    }

    public void datang(){
        Debug.Log("Pindah dulu gaes");
        //LeanTween.moveX(gameObject, 300, 2);
        //gameObject.transform.GetChild(2).gameObject.SetActive(true);
        //gameObject.transform.GetChild(2).gameObject.GetComponent<Dialogue>().datang();
        //pindah tempat
    }

    public void pergi() { 
    
    }
}
