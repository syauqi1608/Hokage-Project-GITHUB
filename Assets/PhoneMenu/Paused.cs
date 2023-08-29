using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public GameObject Phone;

    [SerializeField] GameObject obj;

    public bool Active;

    private void Start()
    {
        Phone.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            BukaTutup();
        }

        if (Input.GetButtonDown("Back"))
        {
            GameObject MenuAplikasi = GameObject.FindGameObjectWithTag("MenuAplikasi");
            if (MenuAplikasi != null) Destroy(MenuAplikasi);
        }
    }

    public void BukaTutup()
    {
        Active = !Active;

        if (Active)
        {
            In();
        }

        if (!Active)
        {
            Out();
        }
    }

    public void In()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Active = true;

        obj.SetActive(true);
    }

    public void Out()
    {
        GameObject MenuAplikasi = GameObject.FindGameObjectWithTag("MenuAplikasi");
        if (MenuAplikasi != null) Destroy(MenuAplikasi);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Active = false;

        obj.SetActive(false);
    }
}
