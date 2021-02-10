using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int nyawa;

    public Image[] hati;
    public Sprite fullHati;
    public Sprite emptyHati;

    // Start is called before the first frame update
    void Start()
    {
        nyawa = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (nyawa > 3)
        {
            nyawa = hati.Length;
        }

        for (int i = 0; i < hati.Length; i++)
        {
            if (i < nyawa)
            {
                hati[i].sprite = fullHati;
            }
            else
            {
                hati[i].sprite = emptyHati;
            }

            if (i < hati.Length)
            {
                hati[i].enabled = true;
            }
            else
            {
                hati[i].enabled = false;
            }
        }
    }

    public void kurangNyawa()
    {
        if (nyawa > 0)
        {
            nyawa -= 1;
        }
    }

    public int getNyawa()
    {
        return nyawa;
    }
}
