using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FundCalculationScript : MonoBehaviour
{
    private float fund;
    private float subCost;

    [SerializeField] GameObject marketingButton;
    private bool markIsActive = false;
    private bool markActivated = false;
    private bool animMarketingPanelHasPlayed = false;

    private float marketingCost = 50000f;
    private int levelMarketing;

    [SerializeField] GameObject marketingPanel;

    [SerializeField] ParticleSystem particules;

    [SerializeField] MessagesManager messagesManager;

    [Header("Messages Thune")]
    [SerializeField] private Message messagefund25;
    bool isMessageFund25 = false;
    [SerializeField] private Message messagefund1000;
    bool isMessageFund1000 = false;
    [SerializeField] private Message messagefund10000;
    bool isMessageFund10000 = false;
    [SerializeField] private Message messagefund100000;
    bool isMessageFund100000 = false;
    [SerializeField] private Message messagefund1000000;
    bool isMessageFund1000000 = false;

    // Start is called before the first frame update
    void Start()
    {
        fund = 0f;
        levelMarketing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int nbUnsub = GetComponent<BuisnessManager>().getNbUnsubCouple();
        int nbCouple = GetComponent<UpdateCouple>().getNbCouples();
        if (!GetComponent<UpdateCouple>().couplePaused)
        {
            subCost = GetComponent<BuisnessManager>().getSubCost();

            fund += GetComponent<UpdateCouple>().cheatVariable * (1 + 0.5f * levelMarketing) * (nbCouple - nbUnsub) * subCost/1000f;
        }
        if (nbCouple >= 1)
        {
            fund += Time.deltaTime * Mathf.FloorToInt(Mathf.Log(nbCouple));
        }

        if (fund >= 30000 &&
            !markIsActive)
        {
            markIsActive = true;
            marketingButton.SetActive(true);
        }

        if (isMessageFund25 == false && fund >= 25)
        {
            messagesManager.AddMessage(messagefund25);
            isMessageFund25 = true;
        }
        else if (isMessageFund1000 == false && fund >= 1000)
        {
            messagesManager.AddMessage(messagefund1000);
            isMessageFund1000 = true;
        }
        else if (isMessageFund10000 == false && fund >= 10000)
        {
            messagesManager.AddMessage(messagefund10000);
            isMessageFund10000 = true;
        }
        else if (isMessageFund100000 == false && fund >= 100000)
        {
            messagesManager.AddMessage(messagefund100000);
            isMessageFund100000 = true;
        }
        else if (isMessageFund1000000 == false && fund >= 1000000)
        {
            messagesManager.AddMessage(messagefund1000000);
            isMessageFund1000000 = true;
        }
        
    }

    public void setFunds(float newFund)
    {
        fund = newFund;
    }

    public float getFunds()
    {
        return fund;
    }

    public int getLvlMarketing()
    {
        return levelMarketing;
    }

    public float getMarketingCost()
    {
        return marketingCost;
    }

    public void upgradeMarketing()
    {
        if (fund - marketingCost > 0) 
        {
            levelMarketing++;
            fund -= marketingCost;
            marketingCost = 50000 * levelMarketing;
        }
    }

    public void getMarketing()
    {
        markActivated = true;
        levelMarketing = 1;
    }

    public void playAnimationMarketingPanel()
    {
        if (markActivated &&
            !animMarketingPanelHasPlayed)
        {
            animMarketingPanelHasPlayed = true;
            Debug.Log("ANIMATION DE MARKETING ");
            marketingPanel.GetComponent<Animation>().Play();
            particules.Play();
        }
    }

}
