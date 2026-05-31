using UnityEngine;

public class PotScript : MonoBehaviour
{
    [Header("Pengaturan Pot")]
    public GameObject bungaDiDalamPot; // Tempat naruh objek bunga yang disembunyikan
    public bool sudahTerisi = false;   // Penanda apakah pot udah ada bunganya

    // Fungsi ini dipanggil pas player nekan E
    public void IsiBunga()
    {
        // Munculin bunganya!
        bungaDiDalamPot.SetActive(true);
        sudahTerisi = true; // Tandain potnya udah gak kosong
    }
}