using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public float rotationSpeed = 50f;  // скорость вращения

    void Update()
    {
        // вращаем объект вокруг своей оси
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }
}
