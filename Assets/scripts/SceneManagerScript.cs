

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void ExitGame()
    {
        Application.Quit();

    }

    


}
