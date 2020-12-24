using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour{
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject scenePilihBarang;
    [SerializeField] private GameObject scenePilihHarga;
    [SerializeField] private GameObject scenePilihKembalian;
    [SerializeField] private GameObject endGame;
    private string status;

    void Start(){
        statusLevel("idle");
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Player.SetActive(true);
        NPC.SetActive(true);
    }

    public string getStatus(){
        return this.status;
    }

    public void statusLevel(string status){
        this.status = status;

        if (this.status == "pilihBarang"){
            Debug.Log("Scene Pilih Barang");
            scenePilihBarang.SetActive(true);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(false);
            GameObject.Find("NPC").GetComponent<NPC>().statusOrder();
        }
        else if (this.status == "pilihHarga"){
            Debug.Log("Scene Pilih Harga");
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(true);
            scenePilihKembalian.SetActive(false);
            GameObject.Find("Dialogue").GetComponent<Dialogue>().KalimatSelanjutnya();
            GameObject.Find("NPC").GetComponent<NPC>().statusOrder();
        }
        else if (this.status == "pilihKembalian"){
            Debug.Log("Scene Pilih Kembalian");
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(true);
            GameObject.Find("Dialogue").GetComponent<Dialogue>().KalimatSelanjutnya();
            GameObject.Find("NPC").GetComponent<NPC>().statusOrder();
        }
        else if (this.status == "idle"){
            Debug.Log("Idle");
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(false);
        }
        else{
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(false);
            Player.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            endGame.SetActive(true);
            endGame.GetComponent<EndGame>().endGame();
        }
    }
}
