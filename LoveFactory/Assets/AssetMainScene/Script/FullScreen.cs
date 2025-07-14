using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public int windowedWidth = 1280; 
    public int windowedHeight = 720; 

    public void changeFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

        if (!Screen.fullScreen)
        {
            Screen.SetResolution(windowedWidth, windowedHeight, false); 
        }

        Debug.Log("Plein écran activé : " + Screen.fullScreen);
    }
}
