using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Delete : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<Item>().onSlot == true)
            {
                eventData.pointerDrag.GetComponent<Item>().onSlot.GetComponent<Slot>().namaBarang = null;
                Destroy(eventData.pointerDrag.gameObject);
            }
        }
    }
}
