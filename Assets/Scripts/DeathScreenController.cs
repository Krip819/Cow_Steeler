using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public void TryAgain()
    {
        // Загрузка последней активной сцены
        int lastSceneIndex = PlayerPrefs.GetInt("lastScene");
        SceneManager.LoadScene(lastSceneIndex);
    }
}
