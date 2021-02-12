using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public GameObject namaBarang;

    public void OnDrop(PointerEventData eventData){
        if (eventData.pointerDrag != null){
            if(GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihBarang"){
                if (eventData.pointerDrag.GetComponent<Item>().onSlot == null){
                    GameObject item = eventData.pointerDrag.GetComponent<Item>().duplicate();
                    namaBarang = item;
                    item.transform.SetParent(GameObject.Find("Barang").GetComponent<Transform>());
                    item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    item.GetComponent<Item>().onSlot = gameObject;
                }
                else{
                    eventData.pointerDrag.GetComponent<Item>().onSlot.GetComponent<Slot>().namaBarang = null;
                    namaBarang = eventData.pointerDrag;
                    namaBarang.GetComponent<Item>().onSlot = gameObject;
                    namaBarang.transform.SetParent(GameObject.Find("Barang").GetComponent<Transform>());
                    namaBarang.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    eventData.pointerDrag.GetComponent<DragDrop>().isRight = true;
                }
            }

            else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihHarga"){
                if (GameObject.Find("Order").GetComponent<Order>().cekJumlahHarga(eventData.pointerDrag.GetComponent<Item>().jumlah)){
                    GameObject item = eventData.pointerDrag.GetComponent<Item>().duplicate();
                    namaBarang = item;
                    item.transform.SetParent(GameObject.Find("Harga").GetComponent<Transform>());
                    item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    item.GetComponent<Item>().onSlot = gameObject;
                }
                else{
                    GameObject.Find("Player").GetComponent<Player>().kurangNyawa();
                }
            }

            else if (GameObject.Find("Level").GetComponent<Level>().getStatus() == "pilihKembalian"){
                if (GameObject.Find("Order").GetComponent<Order>().cekKembalian(eventData.pointerDrag.GetComponent<Item>().jumlah)){
                    GameObject item = eventData.pointerDrag.GetComponent<Item>().duplicate();
                    namaBarang = item;
                    item.transform.SetParent(GameObject.Find("Kembalian").GetComponent<Transform>());
                    item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    item.GetComponent<Item>().onSlot = gameObject;
                }
                else{
                    GameObject.Find("Player").GetComponent<Player>().kurangNyawa();
                }
            }
        }
    }
}
