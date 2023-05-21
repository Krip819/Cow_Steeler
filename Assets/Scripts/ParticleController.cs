using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleController : MonoBehaviour
{
    public GameObject cow;  // Объект коровы
    public ParticleSystem splashParticles;  // Система частиц
    public float shrinkingTime = 2f; // время за которое корова будет уменьшаться

    private Rigidbody2D cowRigidbody;  // Rigidbody2D коровы

    void Start()
    {
        cowRigidbody = cow.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли объект, вошедший в триггер, коровой
        if (other.gameObject == cow)
        {
            // Если это так, воспроизводим систему частиц
            splashParticles.Play();
            Debug.Log("Cow entered the lake trigger area!");
            cowRigidbody.simulated = false;  // Отключаем Rigidbody2D коровы
            StartCoroutine(ShrinkAndDie());
        }
    }

    private IEnumerator ShrinkAndDie()
    {
        float timer = 0;
        Vector3 originalScale = cow.transform.localScale;

        while (timer < shrinkingTime)
        {
            timer += Time.deltaTime;
            float t = timer / shrinkingTime;
            cow.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
            yield return null;
        }
        
        // Здесь нужно вставить имя сцены смерти
        SceneManager.LoadScene("Dead_scene");
    }
}
