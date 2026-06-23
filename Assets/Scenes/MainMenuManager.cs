using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenuManager.cs — Pasang di GameObject kosong di scene MainMenu.
/// Sudah disesuaikan tanpa timer, untuk Android + PC.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [Header("Nama Scene (harus sama persis di Build Settings)")]
    public string namaSceneLevel1 = "Level 1";

    // =============================================
    // Hubungkan ke Button PLAY via OnClick() di Inspector
    // =============================================
    public void TombolPlay()
    {
        // Reset data lama biar gak nge-bug
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        SceneManager.LoadScene(namaSceneLevel1);
    }

    // =============================================
    // Hubungkan ke Button Quit/Keluar via OnClick()
    // =============================================
    public void TombolKeluar()
    {
        Application.Quit();

        // Buat stop di Unity Editor saat testing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
