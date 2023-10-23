using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpaceDestroy : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Code();
        }
    }

    public void Back()
    {
        Code();
    }

    public void Code()
    {
        gameObject.SetActive(false);

        InventoryManager.Instance.Selection.transform.SetParent(InventoryManager.Instance.transform, false);
        InventoryManager.Instance.Selection.SetActive(false);

        InventoryManager.Instance.CanvasKeterangan.SetActive(false);
    }
}
