using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // Для управления сценами

public class LevelCompleteCheck : MonoBehaviour
{
    public Rigidbody2D cowRigidbody;  // Rigidbody2D коровы
    public GameObject ufoShip;  // объект корабля пришельца
    public float abductionDistance = 2f;  // дистанция "похищения"
    public float shrinkTime = 2f;  // время уменьшения
    public int cowsRequired = 3;  // количество коров, необходимых для прохождения уровня
    public string victorySceneName;  // Имя сцены победы

    private bool isLevelComplete = false;
    private int cowsAbducted = 0;  // количество похищенных коров

    void Update()
    {
        // Проверяем, достигла ли корова UFO
        float distance = Vector2.Distance(cowRigidbody.position, new Vector2(ufoShip.transform.position.x, ufoShip.transform.position.y));
        if (!isLevelComplete && distance < abductionDistance)
        {
            // здесь код, который должен выполниться при успешном "похищении" коровы
            Debug.Log("Уровень пройден!");
            cowsAbducted++;
            if (cowsAbducted >= cowsRequired)
            {
                isLevelComplete = true;
                SceneManager.LoadScene(victorySceneName);  // загружаем сцену победы
            }
            else
            {
                StartCoroutine(ShrinkCow());
            }
        }
    }

    IEnumerator ShrinkCow()
    {
        float startTime = Time.time;

        while (Time.time - startTime < shrinkTime)
        {
            float t = (Time.time - startTime) / shrinkTime;
            cowRigidbody.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }

        cowRigidbody.transform.localScale = Vector3.zero;
    }
}
