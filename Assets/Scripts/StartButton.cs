using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string sceneToLoad;  // Имя сцены, которую следует загрузить

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
