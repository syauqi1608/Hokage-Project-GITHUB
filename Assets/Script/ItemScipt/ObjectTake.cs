using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTake : MonoBehaviour
{
    public Item Item;

    public GameObject TapIMG;

    private bool bisaPickup = false;

    private void Start()
    {
        bisaPickup = false;

        TapIMG.SetActive(false);
    }

    private void Update()
    {
        if (bisaPickup == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InventoryManager.Instance.Add(Item);
                Destroy(gameObject);
            }
        }

    }

    public void See()
    {
        if ( Paused.Pause == false )
        {
            TapIMG.SetActive(true);
            TapIMG.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);

            bisaPickup = true;
        }

    }

    public void NotSee()
    {
        bisaPickup = false;

        TapIMG.SetActive(false);
    }

/*    private void OnMouseDown() // ini untuk collider yang di klik degan kursor mouse
    {
        if (bisaPickup == true)
        {
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
        }
    }*/

}
