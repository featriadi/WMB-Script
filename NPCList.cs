using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCList : MonoBehaviour
{
    public List<GameObject> NPC;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        NPC[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getNPC()
    {
        Debug.Log("NPC Keluar");
        NPC[i].SetActive(false);
        i++;
        if (i < NPC.Count)
        {
            NPC[i].SetActive(true);
        }
        else
        {
            Debug.Log("NPC Abis");
            GameObject.Find("Level").GetComponent<Level>().ubahStatus("endGame");
        }
    }
}
