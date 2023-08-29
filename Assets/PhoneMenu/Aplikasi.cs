using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplikasi : MonoBehaviour
{
    public GameObject TempatHighlight;
    public GameObject Highlight;

    public GameObject TempatMenu;
    [Header("Prefab")]
    public GameObject MenuAplikasi;
    public void In()
    {
        Highlight.SetActive(true);
        Highlight.transform.SetParent(TempatHighlight.transform, false);
    }

    public void Out()
    {
        Highlight.SetActive(false);
    }

    public void scaleDown()
    {
        transform.localScale = new Vector2(0.95f , 0.95f);
    }

    public void scaleUp()
    {
        transform.localScale = new Vector2(1, 1);

        GameObject Obj = Instantiate(MenuAplikasi);
        Obj.transform.SetParent(TempatMenu.transform, false);
    }

}
