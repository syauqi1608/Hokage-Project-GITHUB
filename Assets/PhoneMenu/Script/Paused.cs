using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public static bool Pause = false;

    [SerializeField] private GameObject Canvas;

    [SerializeField] private GameObject Obj1;
    [SerializeField] private GameObject Obj2;
    [SerializeField] private GameObject Obj3;

    [SerializeField] private Animator AnimHP;
    [SerializeField] private float Delay = 1f;

    private bool BisaPencet = true;

    public bool Active;

    private void Start()
    {
        Obj1.SetActive(true);
        Obj2.SetActive(true);
        Obj3.SetActive(true);

        Canvas.SetActive(false);
        /*AnimHP.SetBool("Buka", false);*/
    }

    private void Update()
    {
        if (BisaPencet == true)
        {
            if (Input.GetKeyDown(KeyCode.P))  //(Input.GetButtonDown("Pause"))
            {
                BukaTutup();
            }
        }


/*        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject MenuAplikasi = GameObject.FindGameObjectWithTag("MenuAplikasi");
            if (MenuAplikasi != null) Destroy(MenuAplikasi);
        }*/
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
        InventoryManager.Instance.ListItems();

        BisaPencet = false;

        /*Active = true;*/

        Canvas.SetActive(true);

        Pause = true;

        AnimHP.SetBool("Buka", true);

        StartCoroutine(Buka());
    }

    IEnumerator Buka()
    {
        yield return new WaitForSeconds(Delay);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        BisaPencet = true;
    }

    public void Out()
    {
        BisaPencet = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        /*Active = false;*/

        List<BackSpaceDestroy> Menus = new List<BackSpaceDestroy>();

        Menus = Canvas.GetComponentsInChildren<BackSpaceDestroy>().ToList();

        foreach (BackSpaceDestroy menu in Menus)
        {
            menu.Back();
        }

        AnimHP.SetBool("Buka", false);

        StartCoroutine(Tutup());
    }

    IEnumerator Tutup()
    {
        yield return new WaitForSeconds(Delay);

        InventoryManager.Instance.CleanListItems();

        Canvas.SetActive(false);
        Pause = false;
        BisaPencet = true;
    }
}
