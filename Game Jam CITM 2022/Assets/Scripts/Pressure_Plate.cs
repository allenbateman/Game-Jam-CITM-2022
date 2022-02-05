using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate : MonoBehaviour
{

    public GameObject door;
    public bool isActive;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActive = true;
        door.transform.GetComponent<Door>().UnLock();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isActive = false;
        door.transform.GetComponent<Door>().UnLock();
    }

}
