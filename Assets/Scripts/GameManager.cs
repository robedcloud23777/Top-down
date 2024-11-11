using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject scanObject;
    public bool isAciton;

    void Start()
    {
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objectData = scanObj.GetComponent<ObjectData>();
    }
}
