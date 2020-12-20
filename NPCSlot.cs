using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCSlot : MonoBehaviour
{
    public List<GameObject> Slot;
    public List<string> daftarBarang;
    private List<string> tempDaftarBarang;
    public int jumlahHarga;
    private GameObject kosong;

    private bool slotFull;

    void Update()
    {
        if (GameObject.Find("Play").GetComponent<Play>().getStatus() == "pilihBarang")
        {
            slotFull = true;

            for (int i = 0; i < Slot.Count; i++)
            {
                if (Slot[i].GetComponent<Slot>().namaBarang == null)
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
    }

    public void cekPesanan()
    {
        tempDaftarBarang = new List<string>(daftarBarang);

        for (int i = 0; i < Slot.Count; i++)
        {
            if (tempDaftarBarang.Contains(Slot[i].GetComponent<Slot>().namaBarang.GetComponent<Item>().nama)){
                tempDaftarBarang.Remove(Slot[i].GetComponent<Slot>().namaBarang.GetComponent<Item>().nama);
            }
        }

        if (tempDaftarBarang.Count == 0)
        {
            GameObject.Find("Play").GetComponent<Play>().ubahStatus("pilihHarga");
        }
        else
        {
            for (int j = 0; j < Slot.Count; j++)
            {
                Destroy(Slot[j].GetComponent<Slot>().namaBarang);
                Slot[j].GetComponent<Slot>().namaBarang = null;
            }
            GameObject.Find("Player").GetComponent<Player>().kurangNyawa();
        }

        tempDaftarBarang.Clear();
    }

    public bool cekJumlahHarga(int jumlahHarga)
    {
        if (this.jumlahHarga == jumlahHarga)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
