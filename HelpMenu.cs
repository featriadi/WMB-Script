using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject helpMenuUI;
    public Text txt;

    public void resume()
    {
        helpMenuUI.SetActive(false);
        GameIsPaused = false;
        GameObject.Find("NPC").GetComponent<Animator>().enabled = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
    }

    public void help()
    {
        helpMenuUI.SetActive(true);
        GameIsPaused = true;
        GameObject.Find("NPC").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player").GetComponent<Animator>().enabled = false;

        if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihBarang")
        {
            txt.text = "Pindahkan barang yang diminta ke kotak diatas";
        }
        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihHarga")
        {
            txt.text = "Pindahkan angka sesuai dengan jumlah harga ke kotak diatas";
        }
        else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihKembalian")
        {
            txt.text = "Pindahkan angka sesuai dengan jumlah kembalian ke kotak diatas";
        }
    }
}
