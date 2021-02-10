using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image[] bintang;
    public Sprite fullBintang;
    public Sprite emptyBintang;
    public GameObject Level;
    public GameObject Player;

    public void endGame()
    {
        //Player.GetComponent<Animator>().enabled = false;

        int bintang = Level.GetComponent<Star>().getScore();

        for (int i = 0; i < 3; i++)
        {
            if (i < bintang)
            {
                this.bintang[i].sprite = fullBintang;
            }
            else
            {
                this.bintang[i].sprite = emptyBintang;
            }
        }
    }
}
