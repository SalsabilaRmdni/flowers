using UnityEngine;
using TMPro;

public class Level2FlowerManager : MonoBehaviour
{
    [Header("Data Bunga")]
    public int bungaDiTangan; // Jumlah bunga yang dibawa dari Level 1
    public int potTerisi = 0;
    public int totalPot = 3;

    [Header("UI Elements")]
    public TextMeshProUGUI clueText;
    public TextMeshProUGUI interactText;

    void Start()
    {
        // 1. BUKA BRANKAS! Ambil data "SavedFlowers" dari Level 1. 
        // Kalau error/gak ada, defaultnya 0.
        bungaDiTangan = PlayerPrefs.GetInt("SavedFlowers", 0);
        
        interactText.gameObject.SetActive(false);
        UpdateUI();
    }

    public void BungaDitaruh()
    {
        // Kurangi bunga di tangan, tambah pot yang terisi
        bungaDiTangan--;
        potTerisi++;
        UpdateUI();

        // Cek kalau semua pot udah terisi
        if (potTerisi >= totalPot)
        {
            clueText.text = "Misi Selesai! Semua pot sudah ditanam.";
            // Disini lu bisa nambahin kode pindah ke Scene Menang kalau ada
        }
    }

    void UpdateUI()
    {
        clueText.text = "Bunga di tangan: " + bungaDiTangan + "\nPot terisi: " + potTerisi + " / " + totalPot;
    }
}