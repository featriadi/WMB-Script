using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public GameObject Order;
    public GameObject Dialogue;
    public string nama;
    public int uang;

    void Start(){
        Dialogue.SetActive(true);
        Order.SetActive(true);
    }

    public void statusOrder(){
        if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihBarang"){
            Order.GetComponent<Order>().SlotBarang.SetActive(true);
            Order.GetComponent<Order>().SlotHargaBarang.SetActive(false);
            Order.GetComponent<Order>().SlotKembalian.SetActive(false);
        }
        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihHarga"){
            Order.GetComponent<Order>().SlotBarang.SetActive(false);
            Order.GetComponent<Order>().SlotHargaBarang.SetActive(true);
            Order.GetComponent<Order>().SlotKembalian.SetActive(false);
        }
        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihKembalian")
        {
            Order.GetComponent<Order>().SlotBarang.SetActive(false);
            Order.GetComponent<Order>().SlotHargaBarang.SetActive(false);
            Order.GetComponent<Order>().SlotKembalian.SetActive(true);
        }
    }

    public void pesananSelesai(){
        GameObject.Find("NPCList").GetComponent<NPCList>().getNPC();
        Order.SetActive(false);
    }
}
