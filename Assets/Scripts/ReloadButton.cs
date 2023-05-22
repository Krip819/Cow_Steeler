using UnityEngine;
using UnityEngine.SceneManagement; 

public class ReloadButton : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
