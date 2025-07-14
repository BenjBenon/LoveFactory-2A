using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddTitle : MonoBehaviour
{
    private GameObject[] masterGO;
    private string title;

    // Start is called before the first frame update
    void Start()
    {
        masterGO = GameObject.FindGameObjectsWithTag("Master");
        if (masterGO == null)
        {
            Debug.Log("Object master non trouvé");
        }
        if (masterGO != null)
        {
            for (int i = 0; i < masterGO.Length; i++)
            {
                title = masterGO[i].GetComponent<GameManager>().getName();
                if (title != null)
                {
                    break;
                }
            }
            Debug.Log(title);

            if (GetComponent<TMP_Text>() == null)
            {
                Debug.Log("Pas de component TextMeshPo");
            }
            else
            {
                GetComponent<TMP_Text>().text = title;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}