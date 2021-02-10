using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private int score;
    private int jumlahBintang;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        jumlahBintang = 3;
    }

    public void tambahScore()
    {
        if (score < 3)
        {
            score += 1;
        }
    }

    public void kurangScore()
    {
        if (score > 0)
        {
            score -= 1;
        }
    }

    public int getScore()
    {
        return score;
    }
}
