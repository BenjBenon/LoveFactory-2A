using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubPriceText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TMP_Text>().text = (Mathf.FloorToInt(scriptedGO.GetComponent<BuisnessManager>().getSubCost() * 10f) / 10f).ToString() + " $";
    }
}
