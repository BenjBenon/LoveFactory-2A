using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClippersCostText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string newText = Mathf.FloorToInt(scriptedGO.GetComponent<UpdateCouple>().getClippersCost()).ToString();
        GetComponent<TMP_Text>().text = "(COST: " + newText + "$)";
    }
}

