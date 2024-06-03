using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMouseCursor : MonoBehaviour
{
    [SerializeField] bool Firstclicked = true;
    [SerializeField] float delay = 0;

    private void OnEnable()
    {
        Cursor.visible = false;
        //gameObject.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Firstclicked = false;
    }

    private void FixedUpdate()
    {
        if (delay <= 0)
        {
            UnlockMouse();
        }
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    void UnlockMouse()
    {
        if (Input.GetMouseButton(1) && Firstclicked)
        {
            Cursor.visible = false;
            //gameObject.GetComponent<FirstPersonLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Firstclicked = false;
            delay = 0.5f;
        }
        else if (Input.GetMouseButton(1) && !Firstclicked)
        {
            Cursor.visible = true;
            //gameObject.GetComponent<FirstPersonLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Firstclicked = true;
            delay = 0.5f;
        }
    }
}
