using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCanvaOnClick : MonoBehaviour
{
    [SerializeField] GameObject canva;

    public void LoadCanva()
    {
        canva.SetActive(true);
    }

    public void UnloadCanva()
    {
        canva.SetActive(false);
    }
}
