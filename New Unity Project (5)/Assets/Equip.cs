using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public static Equip Instance;
    public float distance = 10f;
    public Transform equipPosition;
    GameObject currentWeapon;
    public bool hasBawly;
    bool canGrab;
    public bool canAttack = false;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckGrab();
        if (canGrab) 
        {
            if (Input.GetKeyDown(KeyCode.E))
                PickUp();  

        }
        if (canAttack && Input.GetMouseButtonDown(0))
        {
            ThrustIT();
        }
    }
    private void CheckGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("I can grab it");
              currentWeapon = hit.transform.gameObject;
                canGrab = true;
            }
        }
        else
            canGrab = false;
    }

    private void PickUp() 
    {
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        if (currentWeapon.name.Contains("TV") || currentWeapon.name.Contains("Bankimoun"))
            canAttack = true;
        else if (currentWeapon.name.Contains("CubieBeveled"))
            hasBawly = true;
        Debug.Log("Picked it up");
    }

    private void ThrustIT()
       
    {
        Debug.Log("Testing");
        currentWeapon.transform.parent = null;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }
}
