using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShakeText : MonoBehaviour
{
    private float shakeDuration = 1.25f;
    private float shakeAmount = 4f;

    private Vector3 originalPosition;
    public TextMeshProUGUI textMeshProComponent;

    public void Start()
    {
        // textMeshProComponent = GetComponent<TextMeshProUGUI>();
        originalPosition = textMeshProComponent.rectTransform.localPosition;

        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + Random.Range(-1f, 1f) * shakeAmount;
            float y = originalPosition.y + Random.Range(-1f, 1f) * shakeAmount;

            textMeshProComponent.rectTransform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        textMeshProComponent.rectTransform.localPosition = originalPosition;
    }
}
