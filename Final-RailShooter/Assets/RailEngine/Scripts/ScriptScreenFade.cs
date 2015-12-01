using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// Author: Andrew Seba
/// Description: Fades in from black
/// </summary>
public class ScriptScreenFade : MonoBehaviour {

    [Tooltip("How long it takes to fade in from clear to black")]
    public float fadeInLength = 1.5f;

    [Tooltip("How long solid black will stay displayed.")]
    [Range(0, 10f)]
    public float fadeStay = 1.0f;

    [Tooltip("How long it takes to fade out from black to clear.")]
    public float fadeOutLength = 1.0f;

    GameObject blackImage;


#if UNITYEDITOR
    void Awake()
    {
        if(GameObject.Find("Canvas/Image") != false)
        {
            blackImage = GameObject.Find("Canvas/Image");
        }
        else
        {
            Debug.Log("No Canvas Added. Please add Canvas prefab from the Prefab Folder.");
        }
    }

#else
    void Awake()
    {
        blackImage = GameObject.Find("Canvas/Image");
    }
#endif


    public void Activate()
    {
        StartCoroutine("FadeIn");
    }

    //@ mike @ reference Andrew
    public void Activate(float pEffectTime, float pFadeInTime, float pFadeOutTime)
    {
        fadeStay = pEffectTime;
        fadeInLength = pFadeInTime;
        fadeOutLength = pFadeOutTime;
        StartCoroutine("FadeIn");
    }
    // end @ mike

    IEnumerator FadeIn()
    {
        float timePassed = 0;

        while(timePassed <= fadeInLength)
        {
            blackImage.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, timePassed / fadeInLength);
            timePassed += 1 * Time.deltaTime;
            Debug.Log(blackImage.GetComponent<Image>().color.a);
            yield return null;

        }

        StartCoroutine("FadeStay");
    }

    IEnumerator FadeStay()
    {
        float timePassed = 0.0f;

        while(timePassed <= fadeStay)
        {
            timePassed += 1 * Time.deltaTime;
            yield return null;
        }
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        float timePassed = 0.0f;

        while(timePassed <= fadeOutLength)
        {
            timePassed += 1 * Time.deltaTime;
            blackImage.GetComponent<Image>().color = Color.Lerp(blackImage.GetComponent<Image>().color, Color.clear,  timePassed / fadeOutLength);

            yield return null;
        }
    }
}
