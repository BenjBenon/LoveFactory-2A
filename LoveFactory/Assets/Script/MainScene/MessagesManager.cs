using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagesManager : MonoBehaviour
{
    [SerializeField] GameObject _content;
    [SerializeField] GameObject _prefabMessage;

    [SerializeField] AnimationClip _animation;

    [SerializeField] List<Message> _messages;

    private void Start()
    {
        StartCoroutine(MessagesDrop());
    }


    public void AddMessage(Message message)
    {
        GameObject go = Instantiate(_prefabMessage);

        TextMeshProUGUI tmp = go.GetComponent<TextMeshProUGUI>();
        tmp.text = GetText("<" + message.senderText + "> ", message.sendercolor) + GetText(message.contentText, message.contentColor);

        go.transform.SetParent(_content.transform, false);

        StartCoroutine(UpdateLineCount(go));

        StartCoroutine(LifeDuration(go));
    }

    private IEnumerator UpdateLineCount(GameObject go)
    {
        yield return null;

        int lineCount = go.GetComponent<TextMeshProUGUI>().textInfo.lineCount;

        RectTransform rectTransform = go.GetComponent<RectTransform>();
        Vector2 currentSize = rectTransform.sizeDelta;
        currentSize.y *= lineCount;
        rectTransform.sizeDelta = currentSize;
    }

    public string GetText(string text, Color color)
    {
        string colorHex = ColorUtility.ToHtmlStringRGB(color);

        string finalText = $"<color=#{colorHex}>{text}</color>";

        return finalText;
    }

    IEnumerator LifeDuration(GameObject go)
    {
        yield return new WaitForSeconds(5);
        go.GetComponent<Animation>().clip = _animation;
        go.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        Destroy(go);
    }

    IEnumerator MessagesDrop()
    {
        int toDisplay = 0;

        int timeToWait = 0;

        while (true)
        {
            toDisplay = Random.Range(0, _messages.Count);

            timeToWait = Random.Range(3, 20);

            yield return new WaitForSeconds(timeToWait);
        
            AddMessage(_messages[toDisplay]);
        }
    }


}
