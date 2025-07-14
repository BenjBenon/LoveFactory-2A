using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnlockMecanic : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] ParticleSystem particules;


    private void Start()
    {
        if (go.CompareTag("Marketing") && GameManager.Instance.isMarketingUnlock == false)
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 20, go.transform.position.z);
        else if (go.CompareTag("Clipper") && GameManager.Instance.isClipperUnlock == false)
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 20, go.transform.position.z);
    }

    public void Unlock()
    {
        particules.Play();
        go.GetComponent<Animation>().Play();
    }
}
