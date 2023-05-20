using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    public GameObject ufoShip;  // Добавьте это поле
    public float moveSpeed = 10f; // Добавьте это поле для управления скоростью коровы
    private Vector3 initialPosition;
    private Rigidbody2D cowRigidbody;
    private bool isBeingAbducted = false;

    void Start()
    {
        cowRigidbody = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    public void StartAbduction()
    {
        isBeingAbducted = true;
    }

    public void StopAbduction()
    {
        isBeingAbducted = false;
    }

    void Update()
    {
        if (isBeingAbducted)
        {
            // Если корова притягивается, прекратим здесь и дадим скрипту UFOBeam контролировать движение
            return;
        }

        // Подсчет направления к начальной позиции
        Vector2 direction = (initialPosition - transform.position).normalized;
        cowRigidbody.AddForce(direction * moveSpeed); // Умножение направления на скорость
    }
}
