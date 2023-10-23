using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    [SerializeField] private float rotX;
    [SerializeField] private float rotY;
    [SerializeField] private float rotZ;
    public float rotSpeed;
    public bool rotClockwise;

    void Update()
    {
        if(rotClockwise==false)
        {
            rotX += Time.deltaTime * rotSpeed;
            rotY += Time.deltaTime * rotSpeed;
            rotZ += Time.deltaTime * rotSpeed;
        }
        else
        {
            rotX += Time.deltaTime * rotSpeed;
            rotY += Time.deltaTime * rotSpeed;
            rotZ -= Time.deltaTime * rotSpeed;
        }
        
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);

    }
}
