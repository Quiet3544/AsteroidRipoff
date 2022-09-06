using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
