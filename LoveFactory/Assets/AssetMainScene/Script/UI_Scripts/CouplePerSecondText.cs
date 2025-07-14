using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CouplePerSecondText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string nb = (Mathf.FloorToInt(scriptedGO.GetComponent<UpdateCouple>().getCouplePerSecond() * 10f) / 10f).ToString();
        GetComponent<TMP_Text>().text = "COUPLES CREATED: (" + nb + "/ s)";
    }
}
