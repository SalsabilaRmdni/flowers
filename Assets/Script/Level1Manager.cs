using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    [Header("Game Settings")]
    public int totalFlowers = 3; 
    private int flowersCollected = 0; 

    [Header("UI Elements")]
    public TextMeshProUGUI clueText;
    public TextMeshProUGUI interactText;

    void Start()
    {
        interactText.gameObject.SetActive(false);
        UpdateClueUI();
        
        // Reset brankas pas game baru mulai biar gak nge-bug bawa data lama
        PlayerPrefs.SetInt("SavedFlowers", 0); 
    }

    public void FlowerCollected()
    {
        flowersCollected++;
        UpdateClueUI();

        // Cek kalau 3 bunga udah kekumpul
        if (flowersCollected >= totalFlowers)
        {
            // MASUKIN KE BRANKAS!
            // Kita simpan angka flowersCollected ke memori dengan nama "SavedFlowers"
            PlayerPrefs.SetInt("SavedFlowers", flowersCollected);
            PlayerPrefs.Save(); // Kunci brankasnya

            LoadLevel2();
        }
    }

    void UpdateClueUI()
    {
        clueText.text = "Misi: Ambil Bunga Merah! \nTerkumpul: " + flowersCollected + " / " + totalFlowers;
    }

    void LoadLevel2()
    {
        // Pastikan nama scene Level 2 lu sama persis
        SceneManager.LoadScene("Level 2"); 
    }
}