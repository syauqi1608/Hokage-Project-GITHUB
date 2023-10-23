using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IndexMenu : MonoBehaviour
{
    [Header("Gk perlu di isi")]
    public int MenuIndex;
    public ManagerIndexMenu ManagerIndex;
    public Text Judul;
    public List<Transform> ChildTrans;

    private void Start()
    {
        if (ManagerIndex.NamaAplikasi.Count >= 0)
        {
            Judul = GetComponent<Text>();
            Judul.text = ManagerIndex.NamaAplikasi[MenuIndex].ToString();
        }

    }

    public void PasangChild() // dipanggil di Manager Index
    {
        ChildTrans = new List<Transform>();
        ChildTrans = GetComponentsInChildren<Transform>().ToList();
    }

    public void EnterIndex()
    {
        ManagerIndex.ObjSelect.transform.SetParent(ChildTrans[1],false);
        ManagerIndex.ObjSelect.SetActive(true);

        ManagerIndex.SuaraEnter.Play();
    }
    public void ExitIndex()
    {
        ManagerIndex.ObjSelect.SetActive(false);
    }

    public void DownIndex()
    {
        ChildTrans[2].localScale = new Vector2(0.95f, 0.95f);
        ManagerIndex.SuaraKlik.Play();
    }

    public void UpIndex()
    {
        ChildTrans[2].localScale = new Vector2(1f, 1f);
        ManagerIndex.Index = MenuIndex;

        for (int i = 0; i < ManagerIndex.BukaAplikasi.Count; i++)
        {
            if (i == MenuIndex)
            {
                if (ManagerIndex.BukaAplikasi[MenuIndex] != null)
                {
                    ManagerIndex.BukaAplikasi[MenuIndex].SetActive(true);
                }

            }
            else
            {
                if (ManagerIndex.BukaAplikasi[i] != null)
                {
                    ManagerIndex.BukaAplikasi[i].SetActive(false);
                }

            }
        }  
    }

}
