using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectToolTipTrigger : MonoBehaviour
{
    private static LTDescr delay;
    public string header;
    [Multiline()]
    public string content;


    public void OnMouseEnter()
    {
        {
            LeanTween.delayedCall(0.5f, () =>
            {
                ToolTipSystem.Show(content, header);
            });

        }
    }

    public void OnMouseExit()
    {
        ToolTipSystem.Hide();
    }


    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    LeanTween.delayedCall(0.5f, () =>
    //    {
    //        ToolTipSystem.Show(content, header);
    //    });

    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    ToolTipSystem.Hide();

    //}
}
