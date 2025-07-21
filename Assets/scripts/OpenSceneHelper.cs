using UnityEngine;
using UnityEngine.SceneManagement;

public class openSceneHelper : MonoBehaviour
{
    public string sceneToOpen;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
