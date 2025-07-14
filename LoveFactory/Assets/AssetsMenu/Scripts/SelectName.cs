using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectName : MonoBehaviour
{
    [SerializeField] string firstSceneName;
    [SerializeField] string backSceneName;

    private TMP_InputField inputFactory;
    private string factoryName;


    // Start is called before the first frame update
    void Start()
    {
        inputFactory = GetComponentInChildren<TMP_InputField>();
        if (inputFactory == null )
        {
            Debug.Log("AIE AIE AIE");
        }
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(backSceneName);
    }

    public void selectName()
    {
        if (inputFactory.text != "")
        {
            factoryName = inputFactory.text;
            SceneManager.LoadScene(firstSceneName);
        }
    }

    public string getFactoryName()
    {
        return factoryName;
    }

}
