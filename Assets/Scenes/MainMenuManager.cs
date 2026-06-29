using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void TombolPlay()
    {
        Debug.Log("TombolPlay diklik! Load Level 1");
        SceneManager.LoadScene("Level 1");
    }

    public void TombolKeluar()
    {
        Debug.Log("TombolKeluar diklik!");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
