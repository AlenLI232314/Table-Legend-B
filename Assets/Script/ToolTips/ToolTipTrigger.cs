using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipTrigger : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private static LTDescr delay;
    public string header;
    [Multiline()]
    public string content;
    public CanvasGroup uiElement;




    public void OnPointerEnter(PointerEventData eventData)
    {
        //FadeIn();
        //ToolTipSystem.Show(content, header);
        LeanTween.delayedCall(1f, () =>
        {
            ToolTipSystem.Show(content, header);


        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();

        LeanTween.cancel(delay.uniqueId);

    }

    //public void FadeIn()
    //{

    //    StartCoroutine(FadeToolTips(uiElement, uiElement.alpha, 1));
    //}

    //public void FadeOut()
    //{
    //    StartCoroutine(FadeToolTips(uiElement, uiElement.alpha, 0));
    //}

    //public IEnumerator FadeToolTips(CanvasGroup cg, float start, float end, float lerpTime = 3f)
    //{
    //    float _timeStartedLearping = Time.time;
    //    float timeSinceStarted = Time.time - _timeStartedLearping;
    //    float percentageComplete = timeSinceStarted / lerpTime;

    //    while (true)
    //    {
    //        timeSinceStarted = Time.time - _timeStartedLearping;
    //        percentageComplete = timeSinceStarted / lerpTime;

    //        float currentValue = Mathf.Lerp(start, end, percentageComplete);

    //        cg.alpha = currentValue;

    //        if (percentageComplete >= 1) break;

    //        yield return new WaitForEndOfFrame();
    //    }
    //}





}
