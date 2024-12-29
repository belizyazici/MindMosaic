using System.Collections;
using UnityEngine;

public class FadeInPanel : MonoBehaviour
{
    public CanvasGroup panelCanvasGroup; 
    public float fadeDuration = 2f; 

    void Start()
    {
        if (panelCanvasGroup != null)
        {
            panelCanvasGroup.alpha = 0f; 
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            panelCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panelCanvasGroup.alpha = 1f;
    }
}
