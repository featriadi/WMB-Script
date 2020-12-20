using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject pilihBarang;
    [SerializeField] private GameObject pilihHarga;
    [SerializeField] private GameObject pilihKembalian;

    private string status;

    void Start()
    {
        status = "pilihBarang";
        cekStatus();
    }

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
            pilihBarang.SetActive(true);
            pilihHarga.SetActive(false);
            pilihKembalian.SetActive(false);
        }
        else if (status == "pilihHarga")
        {
            pilihBarang.SetActive(false);
            pilihHarga.SetActive(true);
            pilihKembalian.SetActive(false);
        }
        else if (status == "pilihKembalian")
        {
            pilihBarang.SetActive(false);
            pilihHarga.SetActive(false);
            pilihKembalian.SetActive(true);
        }
    }

    public string getStatus()
    {
        return this.status;
    }
}
