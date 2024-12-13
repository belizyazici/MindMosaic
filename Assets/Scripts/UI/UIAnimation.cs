using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float duration = 1f;
    private Vector3 initScale = Vector3.zero;
    private Vector3 lastScale = Vector3.one;
    private float timer;

    private void Start()
    {
        transform.localScale = initScale;
    }

    private void Update()
    {
        
        timer += Time.deltaTime;
        
        float fraction = Mathf.Clamp01(timer / duration); // Calculate the fraction of the duration that has passed

        
        transform.localScale = Vector3.Lerp(initScale, lastScale, fraction); // Interpolate the scale of the UI element from initialScale to targetScale
        
        if (fraction >= 1.0f)
        {
            enabled = false;
        }
    }
}
