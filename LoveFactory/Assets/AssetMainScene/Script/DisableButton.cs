using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;
    public int buttonID;

    private float mainVar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (buttonID)
        {
            case 0:
                mainVar = scriptedGO.GetComponent<UpdateCouple>().getSlatsCost();
                break;
            case 1:
                mainVar = scriptedGO.GetComponent<UpdateCouple>().getSlatsUpgradeCost();
                break;
            case 2:
                mainVar = scriptedGO.GetComponent<UpdateCouple>().getClippersCost();
                break;
            case 3:
                mainVar = scriptedGO.GetComponent<UpdateCouple>().getClippersUpgradeCost();
                break;
            case 4:
                mainVar = scriptedGO.GetComponent<FundCalculationScript>().getMarketingCost();
                break;
            default:
                mainVar = 0f;
                break;
        }


        if (mainVar > scriptedGO.GetComponent<FundCalculationScript>().getFunds())
        {
            GetComponent<Button>().interactable = false;
        }
        else 
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
