using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    // linked in editor
    public Animator animator;
    public GameObject spriteRenderer;
    public GameManager gameManager;

    public void Roll(int rolls)
    {
        Color tmp = spriteRenderer.GetComponent<Image>().color;
        tmp.a = 0f;
        spriteRenderer.GetComponent<Image>().color = tmp;
        StartCoroutine(Rolling(rolls));
        gameManager.OnRollStart();
    }

    private IEnumerator Rolling(int rolls)
    {
        for (int i = 0; i < rolls; i++)
        {
            animator.SetBool("Rolling", true);
            yield return new WaitForSeconds(0.16f);
        }
        animator.SetBool("Rolling", false);
        yield return new WaitForSeconds(0.7f);

        StartCoroutine(FadeIn());
        gameManager.OnRollDone();
    }

    private IEnumerator FadeIn()
    {
        Color tmp = spriteRenderer.GetComponent<Image>().color;
        tmp.a = 0f;
        spriteRenderer.GetComponent<Image>().color = tmp;
        float _progress = 0.0f;

        while (_progress < 1)
        {
            Color _tmpColor = spriteRenderer.GetComponent<Image>().color;
            spriteRenderer.GetComponent<Image>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, Mathf.Lerp(tmp.a, 255, _progress)); //startAlpha = 0 <-- value is in tmp.a
            _progress += Time.deltaTime * 0.008f;
            yield return null;
        }
    }
}
