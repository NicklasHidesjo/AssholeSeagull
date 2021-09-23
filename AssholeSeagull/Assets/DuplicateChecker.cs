using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateChecker : MonoBehaviour
{
    private void Awake()
    {
        DuplicateChecker[] Duplicates = FindObjectsOfType<DuplicateChecker>();
        if(Duplicates.Length > 0)
        {
            Debug.Log("Found duplicate");
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
