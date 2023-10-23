using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    [Header("Gk Perlu Di Isi")]
    public Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void pointerEnter()
    {
        InventoryManager.Instance.suaraEnter.Play();
    }

    public void pointerDown()
    {
        InventoryManager.Instance.suaraClick.Play();
        transform.localScale = new Vector2(0.95f, 0.95f);
    }

    public void pointerUp()
    {
        transform.localScale = new Vector2(1f, 1f);
        InventoryManager.Instance.Selection.transform.SetParent(transform, false);
        InventoryManager.Instance.Selection.SetActive(true);

        InventoryManager.Instance.CanvasKeterangan.SetActive(true);
        InventoryManager.Instance.itemIMG.sprite = item.imgUI;
        InventoryManager.Instance.NamaItem.text = item.itemName;
        InventoryManager.Instance.Keterangan.text = item.itemDesc;
    }

}
