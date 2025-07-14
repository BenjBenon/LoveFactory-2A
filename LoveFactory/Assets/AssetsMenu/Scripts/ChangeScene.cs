using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string firstSceneName;
    [SerializeField] string secondSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeNextScene()
    {
        SceneManager.LoadScene(firstSceneName);
    }

    public void changeSecondScene()
    {
        SceneManager.LoadScene(secondSceneName);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
