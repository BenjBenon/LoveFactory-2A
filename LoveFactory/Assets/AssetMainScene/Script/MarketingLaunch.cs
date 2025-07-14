using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketingLaunch : MonoBehaviour
{
    [SerializeField] GameObject scriptedGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchMarketing()
    {
        float newFunds = scriptedGO.GetComponent<FundCalculationScript>().getFunds() - 20000;
        if(newFunds>0)
        {
            gameObject.SetActive(false);
            scriptedGO.GetComponent<FundCalculationScript>().setFunds(newFunds);
            scriptedGO.GetComponent<FundCalculationScript>().getMarketing();
        }
    }
}
