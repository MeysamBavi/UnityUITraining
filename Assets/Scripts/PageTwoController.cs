using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;

public class PageTwoController : MonoBehaviour
{
    public RTLTextMeshPro counterText;
    public RTLTextMeshPro startText;
    public RTLTextMeshPro stopText;
    public RTLTextMeshPro resumeText;
    int counterValue;
    bool hasStarted;
    bool isStopped;
    IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        isStopped = false;
        counterValue = 0;
        startText.gameObject.SetActive(true);
        stopText.gameObject.SetActive(false);
        resumeText.gameObject.SetActive(false);
    }

    IEnumerator StartCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            counterValue++;
            counterText.text = counterValue.ToString();
        }
    }

    void ToggleStopAndResume(bool showResume)
    {
        resumeText.gameObject.SetActive(showResume);
        stopText.gameObject.SetActive(!showResume);
    }

    public void ButtonPressed()
    {
        if (hasStarted)
        {
            if (isStopped)
            {
                ToggleStopAndResume(false);
                coroutine = StartCounter();
                StartCoroutine(coroutine);
                isStopped = false;
            }
            else
            {
                ToggleStopAndResume(true);
                StopCoroutine(coroutine);
                isStopped = true;
            }
            return;
        }
        startText.gameObject.SetActive(false);
        ToggleStopAndResume(false);
        coroutine = StartCounter();
        StartCoroutine(coroutine);
        hasStarted = true;
    }
}
