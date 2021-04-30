using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int characterWarpLimit;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;
        layoutElement.enabled = (headerLength > characterWarpLimit || contentLength > characterWarpLimit) ? true : false;
    }


    //This update function is to make the tool tips resize base on the content
    private void Update()
    {
        //Because the layout component will set the background limit to its max value, so here I made it set off if the content size didn't go over a size
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;
            layoutElement.enabled = (headerLength > characterWarpLimit || contentLength > characterWarpLimit) ? true : false;
        }
        //here is telling the tooltips follow the mouse position
        Vector2 position = Input.mousePosition;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;

    }
}
