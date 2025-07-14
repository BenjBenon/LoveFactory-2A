using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCouple : MonoBehaviour
{
    public int cheatVariable = 1;

    public bool couplePaused = false; 

    private float nbCouples;
    
    private int[,] dataClippers = { { 0, 1 } }; //nbClippers en 1 et lvl en 2
    private int clippersCost = 20;
    private int clippersUpgradeCost = 1000;

    private float delayTime = 4f; //Temps entre chaque clics de l'auto clipper
    private float saveTime = 0f;
    private float saveNbCouple = 0f;
    private float couplePerSecond;

    private int nbSlats = 50;
    private int levelSlatStock = 1;
    private int saveNbCoupleForSlats = 0;
    private int slatsCost = 50;

    private int slatsUpgradeCost = 500;

    private bool canMegaClippers = false;
    private bool animMegaClippersHasPlayed = false;
    private float megaVariable;

    [SerializeField] Animator heartAnimator;

    [SerializeField] GameObject megaClippers;

    [SerializeField] ParticleSystem particules;

    [SerializeField] MessagesManager messagesManager;

    [Header("Messages Couple")]
    [SerializeField] private Message messageCouple100;
    bool isMessageCouple100 = false;
    [SerializeField] private Message messageCouple10000;
    bool isMessageCouple10000 = false;
    [SerializeField] private Message messageCoupleEarth;
    bool isMessageCoupleEarth = false;

    [Header("Message Clipper")]
    [SerializeField] Message messageNewClipper;
    [SerializeField] Message messageUpgradeClipper;






    // Start is called before the first frame update
    void Start()
    {
        nbCouples = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(cheatVariable != 1)
        {
            nbSlats = 500;
        }
        //Update nb couple
        if (nbSlats > 0)
        {
            couplePaused = false;
            for (int i = 0; i < dataClippers.GetLength(0); i++)
            {
                megaVariable = Mathf.Pow(10,i);
                nbCouples += megaVariable * cheatVariable * dataClippers[i, 0] * dataClippers[i, 1] * Time.deltaTime / delayTime;
            }
        }
        else
        {
            couplePaused = true;
        }

        //Update Slats

        if (saveNbCoupleForSlats != Mathf.FloorToInt(nbCouples)
            && nbSlats > 0)
        {
            nbSlats -= (Mathf.FloorToInt(nbCouples) - saveNbCoupleForSlats);
            saveNbCoupleForSlats = Mathf.FloorToInt(nbCouples);
        }
        if (nbSlats < 0)
        {
            nbSlats = 0;
        }
        
        //Calculate couple per second

        if (saveTime + 0.2f < Time.time)
        {
            saveTime = Time.time;
            couplePerSecond = (nbCouples - saveNbCouple) / 0.2f;
            saveNbCouple = nbCouples;
        }

        //Create MegaClickers

        if (dataClippers[0,0] >= 50 &&
            dataClippers[0,1] >= 5 &&
            !canMegaClippers)
        {
            canMegaClippers = true;
            Debug.Log("gain de megaClippers :: MESSAGE CONSOLE");

            int[,] newDataClippers = new int[dataClippers.GetLength(0) + 1, 2];
            for (int i = 0; i < dataClippers.GetLength(0); i++)
            {
                newDataClippers[i, 0] = dataClippers[i, 0];
                newDataClippers[i, 1] = dataClippers[i, 1];
            }
            newDataClippers[dataClippers.GetLength(0), 0] = 0;
            newDataClippers[dataClippers.GetLength(0), 1] = 1;

            dataClippers = newDataClippers;
        }

        if (isMessageCouple100 == false && getNbCouples() >= 100)
        {
            messagesManager.AddMessage(messageCouple100); 
            isMessageCouple100 = true;
        }
        else if (isMessageCouple10000 == false && getNbCouples() >= 10000)
        {
            messagesManager.AddMessage(messageCouple10000);
            isMessageCouple10000 = true;
        }
        else if (isMessageCoupleEarth == false && getNbCouples() >= 8000000)
        {
            messagesManager.AddMessage(messageCoupleEarth);
            isMessageCoupleEarth = true;
        }

    }

    //Used by buttons ------------------------------------------------------
    public void addOneCouple()
    {
        if (nbSlats > 0)
        {
            nbCouples++;
            heartAnimator.SetBool("IsProducing", true);
        }
    }

    public void buySlats()
    {
        float change = GetComponent<FundCalculationScript>().getFunds() - slatsCost;
        if (change > 0)
        {
            GetComponent<FundCalculationScript>().setFunds(change);
            nbSlats += 50 * levelSlatStock;
        }
    }

    public void buyAutoClippers()
    {
        float change = GetComponent<FundCalculationScript>().getFunds() - clippersCost;
        if (change > 0)
        {
            GetComponent<FundCalculationScript>().setFunds(change);
            dataClippers[0, 0]++;
            clippersCost = Mathf.FloorToInt(((20 + 5* dataClippers[0,0]) * dataClippers[0, 0])/10f) * 10;
            messagesManager.AddMessage(messageNewClipper);
        }
    }

    public void upgradeClippers()
    {
        float change = GetComponent<FundCalculationScript>().getFunds() - clippersUpgradeCost;
        if (change > 0)
        {
            GetComponent<FundCalculationScript>().setFunds(change);
            dataClippers[0, 1]++;
            clippersUpgradeCost = Mathf.FloorToInt(((1000 + dataClippers[0, 1]*1000) * dataClippers[0, 1]) / 100f) * 100;
            messagesManager.AddMessage(messageUpgradeClipper);
        }
    }

    public void upgradeSlats()
    {
        float change = GetComponent<FundCalculationScript>().getFunds() - slatsUpgradeCost;
        if (change > 0)
        {
            GetComponent<FundCalculationScript>().setFunds(change);
            levelSlatStock++;
            slatsUpgradeCost = Mathf.FloorToInt(((500 + levelSlatStock) * levelSlatStock) / 100f) * 100;
            slatsCost += 2 * slatsCost / 3;
        }
    }

    public void useCheats()
    {
        if (cheatVariable == 1)
        {
            cheatVariable = 10;
        }
        else
        {
            cheatVariable = 1;
        }
    }

    public void playAnimationMegaClippers()
    {
        if (canMegaClippers &&
            !animMegaClippersHasPlayed)
        {
            animMegaClippersHasPlayed = true;
            Debug.Log("PLAY ANIMATION MEGA CLIPPERS ICI");
            megaClippers.GetComponent<Animation>().Play();
            particules.Play();
        }
    }
    
    //Used by texts------------------------------------------------------------
    public int getNbCouples()
    {
        return Mathf.FloorToInt(nbCouples);
    }

    public float getCouplePerSecond()
    {
        return couplePerSecond;
    }

    public int getNbSlats()
    {
        return nbSlats;
    }
    public int getNbBasicClippers()
    {
        return dataClippers[0, 0];
    }

    public int getClippersCost()
    {
        return clippersCost;
    }
    
    public int getLvlClippers()
    {
        return dataClippers[0, 1];
    }

    public int getClippersUpgradeCost()
    {
        return clippersUpgradeCost;
    }

    public int getSlatsCost()
    {
        return slatsCost;
    }

    public int getSlatsUpgradeCost()
    {
        return slatsUpgradeCost;
    }
}
