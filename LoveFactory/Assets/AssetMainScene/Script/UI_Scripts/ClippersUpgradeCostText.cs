using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClippersUpgradeCostText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        string newText = scriptedGO.GetComponent<UpdateCouple>().getClippersUpgradeCost().ToString();
        GetComponent<TMP_Text>().text = "(COST: " + newText + "$)";
    }
}