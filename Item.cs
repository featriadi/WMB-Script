using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string nama;
    public int jumlah;
    public GameObject onSlot;

    public GameObject duplicate(){
        GameObject item = Instantiate(gameObject);
        item.GetComponent<CanvasGroup>().alpha = 1f;
        item.GetComponent<CanvasGroup>().blocksRaycasts = true;
        return item;
    }
}
