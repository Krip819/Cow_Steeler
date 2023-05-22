using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public string nextLevelName;  // Имя следующей сцены
    public string mainMenuName;  // Имя главной сцены

    // Метод для загрузки следующей сцены
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    // Метод для возврата в главное меню
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
