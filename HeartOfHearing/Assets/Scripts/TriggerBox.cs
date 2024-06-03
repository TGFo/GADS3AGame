using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public GameObject[] Objects;
    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in Objects)
        {
            obj.SetActive(true);
        }
    }
}
