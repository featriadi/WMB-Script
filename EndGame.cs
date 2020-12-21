using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image[] bintang;
    public Sprite fullBintang;
    public Sprite emptyBintang;
    public GameObject Player;

    public void endGame()
    {
        int bintang = Player.GetComponent<Player>().getNyawa();

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
