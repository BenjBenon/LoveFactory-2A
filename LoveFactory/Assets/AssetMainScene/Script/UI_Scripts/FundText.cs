using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FundText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float final = Mathf.FloorToInt(scriptedGO.GetComponent<FundCalculationScript>().getFunds() * 10f)/10f;
        GetComponent<TMP_Text>().text = final.ToString();
    }
}
