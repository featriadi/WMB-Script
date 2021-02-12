using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {
    public List<string> Barang;
    private List<string> tempSlot;
    public GameObject SlotBarang;
    public GameObject SlotHargaBarang;
    public GameObject SlotKembalian;
    private bool slotFull;
    private int jumlahHarga;
    
    void Start(){
        GameObject.Find("Level").GetComponent<Level>().statusLevel("pilihBarang");
    }

    void Update(){
        if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihBarang"){
            SlotBarang.SetActive(true);
            slotFull = true;

            for (int i = 0; i < SlotBarang.GetComponent<SlotBarang>().Slot.Count; i++){
                if (SlotBarang.GetComponent<SlotBarang>().Slot[i].GetComponent<Slot>().namaBarang == null){
                    slotFull = false;
                }
            }

            if (slotFull == true){
                cekPesanan();
                slotFull = false;
            }
        }

        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihHarga"){
            if (SlotHargaBarang.GetComponent<SlotBarang>().Slot[0].GetComponent<Slot>().namaBarang != null){
                GameObject.Find("Level").GetComponent<Star>().tambahScore();
                GameObject.Find("Level").GetComponent<Star>().tambahScore();
                if (GameObject.Find("NPC").GetComponent<NPC>().uang != jumlahHarga){
                    GameObject.Find("Level").GetComponent<Level>().statusLevel("pilihKembalian");
                }
                else{
                    GameObject.Find("NPC").GetComponent<NPC>().pesananSelesai();
                }
            }
        }

        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihKembalian"){
            if (SlotKembalian.GetComponent<SlotBarang>().Slot[0].GetComponent<Slot>().namaBarang != null){
                GameObject.Find("Level").GetComponent<Star>().tambahScore();
                GameObject.Find("Level").GetComponent<Star>().tambahScore();
                GameObject.Find("NPC").GetComponent<NPC>().pesananSelesai();
            }
        }
    }

    public void cekPesanan(){
        tempSlot = new List<string>(Barang);

        for (int i = 0; i < SlotBarang.GetComponent<SlotBarang>().Slot.Count; i++){
            if (tempSlot.Contains(SlotBarang.GetComponent<SlotBarang>().Slot[i].GetComponent<Slot>().namaBarang.GetComponent<Item>().nama)){
                tempSlot.Remove(SlotBarang.GetComponent<SlotBarang>().Slot[i].GetComponent<Slot>().namaBarang.GetComponent<Item>().nama);
            }
        }

        if (tempSlot.Count == 0){
            for (int i = 0; i < SlotBarang.GetComponent<SlotBarang>().Slot.Count; i++){
                jumlahHarga += SlotBarang.GetComponent<SlotBarang>().Slot[i].GetComponent<Slot>().namaBarang.GetComponent<Item>().jumlah;
            }
            GameObject.Find("Level").GetComponent<Star>().tambahScore();
            GameObject.Find("Level").GetComponent<Level>().statusLevel("pilihHarga");
        }
        else{
            for (int j = 0; j < SlotBarang.GetComponent<SlotBarang>().Slot.Count; j++){
                Destroy(SlotBarang.GetComponent<SlotBarang>().Slot[j].GetComponent<Slot>().namaBarang);
                SlotBarang.GetComponent<SlotBarang>().Slot[j].GetComponent<Slot>().namaBarang = null;
            }
            GameObject.Find("Player").GetComponent<Player>().kurangNyawa();
        }

        tempSlot.Clear();
    }

    public bool cekJumlahHarga(int jumlah){
        if (jumlahHarga == jumlah){
            return true;
        }
        else{
            return false;
        }
    }

    public bool cekKembalian(int kembali){
        int kembalian = GameObject.Find("NPC").GetComponent<NPC>().uang - jumlahHarga;
        if (kembalian == kembali){
            return true;
        }
        else{
            return false;
        }
    }
}
