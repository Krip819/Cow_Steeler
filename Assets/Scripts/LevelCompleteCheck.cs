using UnityEngine;
using System.Collections;
using System.Collections.Generic;  // Для работы со списками
using UnityEngine.SceneManagement;  // Для управления сценами

public class LevelCompleteCheck : MonoBehaviour
{
    public List<Rigidbody2D> cowsRigidbodies;  // Список Rigidbody2D коров
    public GameObject ufoShip;  // объект корабля пришельца
    public float abductionDistance = 2f;  // дистанция "похищения"
    public float shrinkTime = 2f;  // время уменьшения
    public string victorySceneName;  // Имя сцены победы

    private bool isLevelComplete = false;
    private int cowsAbducted = 0;  // количество похищенных коров

    // Создаем свойство для доступа к cowsAbducted извне
    public int GetCowsAbducted()
    {
        return cowsAbducted;
    }

    void Update()
    {
        if (isLevelComplete)
            return;

        List<Rigidbody2D> abductedCows = new List<Rigidbody2D>();

        foreach (Rigidbody2D cowRigidbody in cowsRigidbodies)
        {
            // Проверяем, достигла ли каждая корова UFO
            float distance = Vector2.Distance(cowRigidbody.position, new Vector2(ufoShip.transform.position.x, ufoShip.transform.position.y));
            if (distance < abductionDistance)
            {
                abductedCows.Add(cowRigidbody);
                StartCoroutine(ShrinkCow(cowRigidbody, cowRigidbody.transform.localScale));

                break;
            }
        }

        foreach (Rigidbody2D abductedCow in abductedCows)
        {
            cowsRigidbodies.Remove(abductedCow);
        }
    }

    IEnumerator ShrinkCow(Rigidbody2D cowRigidbody, Vector3 initialScale)
    {
        float startTime = Time.time;

        while (Time.time - startTime < shrinkTime)
        {
            float t = (Time.time - startTime) / shrinkTime;
            cowRigidbody.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
            yield return null;
        }

        cowRigidbody.transform.localScale = Vector3.zero;

        // Увеличиваем количество похищенных коров только после того, как корова полностью исчезает
        cowsAbducted++;

        // Проверяем, все ли коровы были похищены и уменьшены
        if (cowsAbducted >= cowsRigidbodies.Count + 1)
        {
            isLevelComplete = true;
            Debug.Log("Уровень пройден!");
            yield return new WaitForSeconds(shrinkTime);  // Даём коровам время уменьшиться до конца
            SceneManager.LoadScene(victorySceneName);  // загружаем сцену победы
        }
    }
}
