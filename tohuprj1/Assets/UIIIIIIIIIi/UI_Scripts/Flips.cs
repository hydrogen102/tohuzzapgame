using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flips : MonoBehaviour
{
    SpriteRenderer minhoSpriteRenderer;

    private void OnEnable()
    {
        minhoSpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("FlipMinhoFace");
    }

    private IEnumerator FlipMinhoFace()
    {
        if (minhoSpriteRenderer == null) yield break;
        while (true)
        {
            if (minhoSpriteRenderer.flipX == false)
            {
                minhoSpriteRenderer.flipX = true;
            }
            else if (minhoSpriteRenderer.flipX == true)
            {
                minhoSpriteRenderer.flipX = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
