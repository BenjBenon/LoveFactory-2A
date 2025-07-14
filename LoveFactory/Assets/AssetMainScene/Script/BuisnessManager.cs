using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuisnessManager : MonoBehaviour
{
    private float subCost = 1f;
    private float limitCost = 0.03f;
    private float nbCouple;
    private float nbUnsubCouple;

    // Start is called before the first frame update
    void Start()
    {
        nbUnsubCouple = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nbCouple = GetComponent<UpdateCouple>().getNbCouples();

        updateUnsub();
    }

    private void updateUnsub()
    {
        if (subCost > 10)
        {
            nbUnsubCouple += nbCouple / 10;
        }
        else
        {
            nbUnsubCouple += nbCouple * (((subCost/100f) -limitCost) / 20f);
        }

        if (nbUnsubCouple < 0)
        {
            nbUnsubCouple = 0;
        }
        if (nbUnsubCouple > nbCouple)
        {
            nbUnsubCouple = nbCouple;
        }

        //Debug.Log("NB COUPLE = "+ nbCouple+ " ET UNSUB = "+ nbUnsubCouple);

    }

    public int getNbUnsubCouple()
    {
        return Mathf.FloorToInt(nbUnsubCouple);
    }

    public float getSubCost()
    {
        return subCost;
    }

    public void addSubCost()
    {
        subCost += 0.1f;
    }

    public void substractSubCost()
    {
        subCost -= 0.1f;
    }


}