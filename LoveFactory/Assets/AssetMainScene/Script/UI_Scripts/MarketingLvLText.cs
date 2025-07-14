using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarketingLvLText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string newText = scriptedGO.GetComponent<FundCalculationScript>().getLvlMarketing().ToString();
        GetComponent<TMP_Text>().text = "Marketing Lvl: " + newText;
    }
}
