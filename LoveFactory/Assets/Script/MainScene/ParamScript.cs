using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamScript : MonoBehaviour
{
    [SerializeField] Canvas hidenCanva1;
    [SerializeField] Canvas hidenCanva2;
    [SerializeField] Canvas paramCanva;

    [SerializeField] SelectOnClick selectOnCLickScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void quitParams()
    {
        hidenCanva1.gameObject.SetActive(true);
        hidenCanva2.gameObject.SetActive(true);
        paramCanva.gameObject.SetActive(false);

        selectOnCLickScript.quitParams();
    }
}
