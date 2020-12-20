using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int nyawa;
    private int jumlahNyawa;

    public Image[] bintang;
    public Sprite fullBintang;
    public Sprite emptyBintang;

    // Start is called before the first frame update
    void Start()
    {
        nyawa = 3;
        jumlahNyawa = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (nyawa > jumlahNyawa)
        {
            nyawa = jumlahNyawa;
        }

        for (int i = 0; i < bintang.Length; i++)
        {
            if (i < nyawa)
            {
                bintang[i].sprite = fullBintang;
            }
            else
            {
                bintang[i].sprite = emptyBintang;
            }

            if (i < jumlahNyawa)
            {
                bintang[i].enabled = true;
            }
            else
            {
                bintang[i].enabled = false;
            }
        }
    }

    public void kurangNyawa()
    {
        nyawa -= 1;
    }
}
