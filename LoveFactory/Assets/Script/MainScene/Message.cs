using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName ="new Message", menuName = "ScripatbleObjects/Messages")]
public class Message : ScriptableObject
{
    [Header("Sender")]
    public string senderText;
    public Color sendercolor;

    [Header("Content")]
    public string contentText;
    public Color contentColor;

}
