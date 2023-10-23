using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManagerIndexMenu : MonoBehaviour
{
    [Header("Object Ini")]
    public ManagerIndexMenu ManagerIndex;

    public AudioSource SuaraEnter;
    public AudioSource SuaraKlik;
    public GameObject ObjSelect;

    public List<string> NamaAplikasi;
    public List<GameObject> BukaAplikasi;

    [Header("Gk perlu Di isi")]
    public int Index; // disini gk kepake, buat cek aja

    [Header("Gk perlu di isi, udah otomatis pick dari childern")]
    public List<IndexMenu> _content;

    [ContextMenu("Pasang _content")] // harus di pasang ulang jika ada perubahan
    public void PasangContent() //dipanggil dri script menu
    {
        _content = new List<IndexMenu>(); //new list agar saat start: jika ada list di inspector akan di hapus.

        _content = GetComponentsInChildren<IndexMenu>().ToList();

        for (int i = 0; i < _content.Count; i++)
        {
            _content[i].MenuIndex = i;
            _content[i].ManagerIndex = ManagerIndex;
            _content[i].PasangChild();
            #region gk kepake
            /*            EventTrigger.Entry entry = new EventTrigger.Entry();
                        entry.eventID = EventTriggerType.PointerDown;
                        entry.callback.AddListener((eventData) => { DownIndex(); });
                        _content[i].AddComponent<EventTrigger>().triggers.Add(entry);

                        EventTrigger.Entry entry2 = new EventTrigger.Entry();
                        entry2.eventID = EventTriggerType.PointerUp;
                        entry2.callback.AddListener((eventData) => { UpIndex(); });
                        _content[i].AddComponent<EventTrigger>().triggers.Add(entry2);*/
            #endregion
        }
    }

    void Start()
    {


        /*        var elements = GetComponentsInChildren<Ctmz_Index>();
                foreach (var element in elements)
                {
                    _content.Add(element);
                }*/

        /*        _content.ForEach(content =>
                {
                    content.ManagerIndex = ManagerIndex;
                });*/

        ObjSelect.SetActive(false);

        MatikanAplikasi();
    }

    public void MatikanAplikasi()
    {
        foreach (GameObject obj in BukaAplikasi)
        {
            obj.SetActive(false);
        }
    }
}
