using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<string> Barang;
    private List<string> tempSlot;
    public GameObject SlotBarang;
    public GameObject SlotHargaBarang;
    public GameObject SlotKembalian;
    private bool slotFull;
    private int jumlahHarga;
    
    void Update(){
        if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihBarang"){
            SlotBarang.SetActive(true);
            slotFull = true;

            for (int i = 0; i < SlotBarang.GetComponent<SlotBarang>().Slot.Count; i++)
            {
                if (SlotBarang.GetComponent<SlotBarang>().Slot[i].GetComponent<Slot>().namaBarang == null)
                {
                    slotFull = false;
                }
            }

            if (slotFull == true)
            {
                cekPesanan();
                slotFull = false;
            }
        }
        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihHarga"){
            if (SlotHargaBarang.GetComponent<SlotBarang>().Slot[0].GetComponent<Slot>().namaBarang != null){
                if (cekJumlahHarga(jumlahHarga)){
                    if (GameObject.Find("NPC").GetComponent<NPC>().uang != jumlahHarga){
                        GameObject.Find("Level").GetComponent<Level>().ubahStatus("pilihKembalian");
                        GameObject.Find("NPC").GetComponent<NPC>().Dialogue.GetComponent<Dialogue>().KalimatSelanjutnya();
                        SlotHargaBarang.SetActive(false);
                        SlotKembalian.SetActive(true);
                    }
                    else{
                        GameObject.Find("NPC").GetComponent<NPC>().pesananSelesai();
                    }
                }
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
            //Debug.Log("Total Belanja adalah "+jumlahHarga);

            GameObject.Find("Level").GetComponent<Level>().ubahStatus("pilihHarga");
            GameObject.Find("NPC").GetComponent<NPC>().Dialogue.GetComponent<Dialogue>().KalimatSelanjutnya();
            SlotBarang.SetActive(false);
            SlotHargaBarang.SetActive(true);
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

    public bool cekKembalian(int kembali)
    {
        int kembalian = GameObject.Find("NPC").GetComponent<NPC>().uang - jumlahHarga;
        if (kembalian == kembali){
            return true;
        }
        else{
            return false;
        }
    }


}
