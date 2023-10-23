using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Gk Perlu Di Isi")]
    public List<Item> Items = new List<Item>();
    public List<InventoryItemController> InventoryItems = new List<InventoryItemController>();

    [Header("Di Isi")]
    public Transform ItemContent; // Parent Content
    public GameObject InventoryItem; // Item Prefab

    public GameObject Selection; // Obj selection

    public GameObject CanvasKeterangan;
    public Image itemIMG;
    public Text NamaItem;
    public Text Keterangan;

    public AudioSource suaraClick;
    public AudioSource suaraEnter;

    private void Awake()
    {
        Instance = this;

/*        Instance.CanvasKeterangan.SetActive(false);
        Instance.Selection.SetActive(false);*/
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void CleanListItems()
    {
        //clean/new list
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        InventoryItems = new List<InventoryItemController>();
    }

    public void ListItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemIcon.sprite = item.iconUI;

        }

        SetInventoryItem();
    }

    public void SetInventoryItem()
    {
        InventoryItems = new List<InventoryItemController>();

        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>().ToList();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }

    }

}
