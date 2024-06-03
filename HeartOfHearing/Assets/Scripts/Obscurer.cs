using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obscurer : MonoBehaviour
{
    public GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideScene());
    }

   IEnumerator HideScene()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject obj in Objects)
        {
            obj.SetActive(false);
        }
    }
}
