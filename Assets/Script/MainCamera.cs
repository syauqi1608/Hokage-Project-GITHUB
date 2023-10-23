using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{
    private GameObject MainCam;
    [SerializeField] private Transform HeadRig;

    void Start()
    {
        MainCam = this.gameObject;
        /*MainCam.transform.SetParent(HeadRig.transform, true);*/
    }

    private void Update()
    {
        transform.position = HeadRig.transform.position;

        // Mengambil rotasi dari objek referensi
        Quaternion targetRotation = HeadRig.rotation;

        // Hanya menyimpan rotasi pada sumbu X
        Vector3 targetEulerAngles = targetRotation.eulerAngles;
        Vector3 newEulerAngles = transform.rotation.eulerAngles;
        newEulerAngles.x = targetEulerAngles.x;

        // Mengubah rotasi objek ini untuk mengikuti rotasi sumbu X objek referensi
        transform.rotation = Quaternion.Euler(newEulerAngles);
    }
}
