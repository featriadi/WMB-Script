using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject Order;
    public GameObject Dialogue;
    public string nama;
    public int uang;

    void Start()
    {
        Debug.Log(nama + " jalan ke warung");
        Debug.Log(nama + " punya duit " + uang);
        gameObject.GetComponent<Movement>().datang();
        Order.SetActive(true);
        Dialogue.SetActive(true);
        GameObject.Find("Level").GetComponent<Level>().ubahStatus("pilihBarang");
    }

    void Update()
    {

    }

    public void pesananSelesai()
    {
        GameObject.Find("NPCList").GetComponent<NPCList>().getNPC();
        //GameObject.Find("Level").GetComponent<Level>().ubahStatus("idle");
        Order.SetActive(false);
    }
}
