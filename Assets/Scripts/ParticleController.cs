using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleController : MonoBehaviour
{
    public List<GameObject> cows;  // Список объектов коров
    public ParticleSystem splashParticles;  // Система частиц
    public float shrinkingTime = 2f; // время за которое корова будет уменьшаться
    public float deathSceneDelay = 2f; // время задержки перед отображением сцены смерти

    private List<Rigidbody2D> cowRigidbodies = new List<Rigidbody2D>();  // Список Rigidbody2D коров

    void Start()
    {
        // Получаем компоненты Rigidbody2D для всех коров
        foreach (GameObject cow in cows)
        {
            cowRigidbodies.Add(cow.GetComponent<Rigidbody2D>());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли объект, вошедший в триггер, коровой
        if (cows.Contains(other.gameObject))
        {
            // Если это так, воспроизводим систему частиц
            splashParticles.Play();
            Debug.Log("Cow entered the lake trigger area!");
            other.attachedRigidbody.simulated = false;  // Отключаем Rigidbody2D коровы
            StartCoroutine(ShrinkAndDie(other.gameObject));
        }
    }

    private IEnumerator ShrinkAndDie(GameObject cow)
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
        
        // Задержка перед отображением сцены смерти
        yield return new WaitForSeconds(deathSceneDelay);
        
        // Сохраняем текущую сцену перед переходом на экран смерти
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        
        // Здесь нужно вставить имя сцены смерти
        SceneManager.LoadScene("Dead_scene");
    }
}
