using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCList : MonoBehaviour
{
    public List<GameObject> NPC;
    private int i;

    void Start(){
        i = 0;
        NPC[i].SetActive(true);
    }

    void Update(){
        
    }

    public void getNPC(){
        Debug.Log("NPC Keluar");
        NPC[i].SetActive(false);
        i++;
        if (i < NPC.Count){
            GameObject.Find("Level").GetComponent<Level>().statusLevel("idle");
            NPC[i].SetActive(true);
        }
        else{
            Debug.Log("NPC Abis");
            GameObject.Find("Level").GetComponent<Level>().statusLevel("endGame");
        }
    }
}
