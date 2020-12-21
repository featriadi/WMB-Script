using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject scenePilihBarang;
    [SerializeField] private GameObject scenePilihHarga;
    [SerializeField] private GameObject scenePilihKembalian;
    [SerializeField] private GameObject endGame;
    private string status;

    // Start is called before the first frame update
    void Start()
    {
        NPC.SetActive(true);
        Player.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ubahStatus(string status)
    {
        this.status = status;
        cekStatus();
    }

    public void cekStatus()
    {
        if (status == "pilihBarang")
        {
            Debug.Log("Scene Pilih Barang");
            scenePilihBarang.SetActive(true);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(false);
        }
        else if (status == "pilihHarga")
        {
            Debug.Log("Scene Pilih Harga");
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(true);
            scenePilihKembalian.SetActive(false);
        }
        else if (status == "pilihKembalian")
        {
            Debug.Log("Scene Pilih Kembalian");
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(true);
        }
        else
        {
            scenePilihBarang.SetActive(false);
            scenePilihHarga.SetActive(false);
            scenePilihKembalian.SetActive(false);
            Player.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            endGame.SetActive(true);
            endGame.GetComponent<EndGame>().endGame();
        }
    }

    public string getStatus()
    {
        return this.status;
    }
}
