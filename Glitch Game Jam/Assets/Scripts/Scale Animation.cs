using System.Collections;
using UnityEngine;

public class ScaleAnimation:MonoBehaviour
{
    private Vector3 originalScale;

    [SerializeField] private float scaleAmount;
    [SerializeField] private float duration = 0.1f;

    void Start()
    {
        originalScale = this.transform.localScale;
        transform.localScale *= scaleAmount;
        StartCoroutine(AnimationScale());
    }

    private IEnumerator AnimationScale()
    {
        while ((transform.localScale - originalScale).sqrMagnitude > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, 0.1f);
            yield return duration;
        }
    }
}