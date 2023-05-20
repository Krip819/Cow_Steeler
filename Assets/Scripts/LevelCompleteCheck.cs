using UnityEngine;

public class LevelCompleteCheck : MonoBehaviour
{
    public Rigidbody2D cowRigidbody;  // Rigidbody2D коровы
    public GameObject ufoShip;  // объект корабля пришельца
    public float abductionDistance = 2f;  // дистанция "похищения"

    void Update()
    {
        // Проверяем, достигла ли корова UFO
        float distance = Vector2.Distance(cowRigidbody.position, new Vector2(ufoShip.transform.position.x, ufoShip.transform.position.y));
        if (distance < abductionDistance)
        {
            // здесь код, который должен выполниться при успешном "похищении" коровы
            Debug.Log("Уровень пройден!");
        }
    }
}
