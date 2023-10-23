using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpine : MonoBehaviour
{
    public static bool EnterCol;

    private void OnTriggerEnter(Collider other)
    {
        EnterCol = true;
    }
    private void OnTriggerStay(Collider other)
    {
        EnterCol = true;
    }
    private void OnTriggerExit(Collider other)
    {
/*        EnterCol = false;*/
    }
}
