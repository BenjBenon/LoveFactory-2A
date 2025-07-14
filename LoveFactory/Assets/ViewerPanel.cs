using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ViewerPanel : MonoBehaviour
{
    [SerializeField] List<VideoClip> video;
    [SerializeField] VideoPlayer player;

    private void Start()
    {
        StartCoroutine(Video());
    }

    IEnumerator Video()
    {
        int count = 0;

        while (true)
        {
            yield return new WaitForSeconds(15);
            count++;
            player.clip = video[count % 2];
            player.Play();
        }
    }
}
