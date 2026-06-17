using UnityEngine;
using UnityEngine.InputSystem; // Wajib dipasang

public class PlayerInteractFlowerLvl2 : MonoBehaviour
{
    [Header("Jarak Interaksi")]
    public float interactRange = 5f; // Gw set ke 5f biar di HP lebih gampang kena potnya
    public Camera playerCamera;
    public Level2FlowerManager levelManager;

    // FUNGSI BARU KHUSUS ANDROID:
    // Fungsi ini bakal dipanggil pas jempol lu ngetap tombol "TANAM" di HP
    public void TanamBungaViaHP()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Pot"))
            {
                PotScript pot = hit.collider.GetComponent<PotScript>();

                // Cek syarat menanam bunga
                if (pot != null && !pot.sudahTerisi && levelManager.bungaDiTangan > 0)
                {
                    pot.IsiBunga(); // Munculin bunga di pot
                    levelManager.BungaDitaruh(); // Kurangi stok bunga di tangan
                    levelManager.interactText.gameObject.SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Pot"))
            {
                PotScript pot = hit.collider.GetComponent<PotScript>();

                if (pot != null && !pot.sudahTerisi && levelManager.bungaDiTangan > 0)
                {
                    // Update teks bantuan biar cocok buat PC dan HP
                    levelManager.interactText.text = "Tap TANAM / Tekan E";
                    levelManager.interactText.gameObject.SetActive(true);

                    // Inputan buat di PC (Keyboard E)
                    if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        TanamBungaViaHP(); // Manggil fungsi yang sama
                    }
                }
                else
                {
                    levelManager.interactText.gameObject.SetActive(false);
                }
            }
            else
            {
                levelManager.interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            levelManager.interactText.gameObject.SetActive(false);
        }
    }
}