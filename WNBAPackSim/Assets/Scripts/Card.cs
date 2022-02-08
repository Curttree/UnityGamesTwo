using System.Collections;
using UnityEngine;

public class Card : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        Vector3 goal = transform.localScale;
        Vector3 t = Vector3.zero;
        for (float scale = 0; scale <= goal.x; scale += 0.01f)
        {
            t = new Vector3(scale, scale, scale);
            transform.localScale = t;
            yield return new WaitForSeconds(.01f);
        }
    }
    IEnumerator FadeOut()
    {
        Vector3 t = transform.localScale;
        Vector3 goal = Vector3.zero;

        //Assume uniform scaling.
        for (float scale = t.x; scale >= goal.x; scale -= 0.02f)
        {
            t = new Vector3(scale, scale, scale);
            transform.localScale = t;
            yield return new WaitForSeconds(.01f);
        }
        transform.localScale = Vector3.zero;
    }
    public void TriggerFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}