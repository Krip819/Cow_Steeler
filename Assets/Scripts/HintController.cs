using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public float displayTime = 5f;  // Время, в течение которого подсказка будет отображаться

    void Start()
    {
        StartCoroutine(HideHintAfterTime());
    }

    public void OnHintClick()
    {
        // Подсказка исчезает, когда игрок нажимает на неё
        HideHint();
    }

    IEnumerator HideHintAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        HideHint();
    }

    void HideHint()
    {
        gameObject.SetActive(false);  // Делаем подсказку невидимой
    }
}
