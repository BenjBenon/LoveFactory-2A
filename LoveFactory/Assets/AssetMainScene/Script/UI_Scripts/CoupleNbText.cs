using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoupleNbText : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = scriptedGO.GetComponent<UpdateCouple>().getNbCouples().ToString();
    }
}
