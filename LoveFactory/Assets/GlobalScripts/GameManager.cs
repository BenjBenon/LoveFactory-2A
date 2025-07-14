using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager> 
{
    [SerializeField] GameObject factoryNameGO;
    private string factoryName;

    public bool isMarketingUnlock = false;
    public bool isClipperUnlock = false;

    public void setName()
    {
        factoryName = factoryNameGO.GetComponent<SelectName>().getFactoryName();
    }

    public string getName()
    {
        return factoryName;
    }
}
