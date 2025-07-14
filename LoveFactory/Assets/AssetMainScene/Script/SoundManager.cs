using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject mainVolume;
    [SerializeField] GameObject factory;
    [SerializeField] GameObject marketingPanel;
    [SerializeField] GameObject office;

    [SerializeField] Slider volumeSlider;

    private float volumeMain;
    private float volumeFactory;
    private float volumeMarketing;
    private float volumeOffice;

    // Start is called before the first frame update
    void Start()
    {
        volumeMain = mainVolume.GetComponent<AudioSource>().volume;
        volumeFactory = factory.GetComponent<AudioSource>().volume;
        volumeMarketing =marketingPanel.GetComponent<AudioSource>().volume;
        volumeOffice = office.GetComponent<AudioSource>().volume;
    }

    public void changeVolume()
    {
        mainVolume.GetComponent<AudioSource>().volume = volumeMain * volumeSlider.value/0.5f;
        factory.GetComponent<AudioSource>().volume = volumeFactory * volumeSlider.value/0.5f;
        marketingPanel.GetComponent<AudioSource>().volume = volumeMarketing * volumeSlider.value/0.5f;
        office.GetComponent<AudioSource>().volume = volumeOffice * volumeSlider.value/0.5f;
    }
}
