// CowCounter.cs
using UnityEngine;
using TMPro;  // Для работы с TextMeshPro

public class CowCounter : MonoBehaviour
{
    public LevelCompleteCheck levelChecker;  // ссылка на скрипт LevelCompleteCheck
    public TextMeshProUGUI cowCounterText;  // ссылка на UI текст

    void Update()
    {
        int cowsLeft = levelChecker.cowsRigidbodies.Count;
        cowCounterText.text = "" + cowsLeft.ToString();
    }
}
