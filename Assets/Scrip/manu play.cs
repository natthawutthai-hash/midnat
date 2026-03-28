using UnityEngine;
using UnityEngine.SceneManagement;

public class manuplay : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
