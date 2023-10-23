using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaycastPlayer : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        float distanceToClosestOBJ = Mathf.Infinity;
        ObjectTake closestOBJ = null;
        // Catatan: Kalau pakai List bisa di Add/Remove listnya satu satu, kalau pakai [] hanya bisa di isi length sekaligus semua (List pakai .Count, kalau [] pakai .Length).
        ObjectTake[] allOBJ = GameObject.FindObjectsOfType<ObjectTake>();

        foreach (ObjectTake currentOBJ in allOBJ)
        {
            float distanceToOBJ = (currentOBJ.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToOBJ < distanceToClosestOBJ)
            {
                distanceToClosestOBJ = distanceToOBJ;
                closestOBJ = currentOBJ;
            }
        }

        if (other.gameObject.TryGetComponent<ObjectTake>(out ObjectTake objCOM))
        {
            if (objCOM == closestOBJ)
            {
                if ((objCOM.transform.position - this.transform.position).sqrMagnitude <= 1.6f)
                {
                    objCOM.NotSee();
                }
                else
                {
                    objCOM.See();
                }

            }
            else
            {
                objCOM.NotSee();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<ObjectTake>(out ObjectTake objCOM))
        {
            objCOM.NotSee();
        }
    }
}
