using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [Header("Jarak Interaksi")]
    public float interactRange = 5f; // Gw gedein jadi 5 biar di HP sentuhnya lebih gampang
    public Camera playerCamera;      
    public Level1Manager levelManager; 

    // FUNGSI BARU KHUSUS ANDROID: 
    // Fungsi ini bakal dipanggil pas jempol lu nekan tombol "AMBIL" di layar HP
    public void AmbilBungaViaHP()
    {
        RaycastHit hit;
        // Bikin laser buat ngecek lu lagi natep bunga atau gak
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("RedFlower"))
            {
                Destroy(hit.collider.gameObject); // Bunga hancur
                levelManager.FlowerCollected();   // Lapor ke manager
                levelManager.interactText.gameObject.SetActive(false); // Sembunyiin teks
            }
        }
    }

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("RedFlower"))
            {
                // Teks diganti biar relevan buat PC dan HP
                levelManager.interactText.text = "Tap AMBIL / Tekan E";
                levelManager.interactText.gameObject.SetActive(true);

                // Ini buat PC (Keyboard E)
                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    AmbilBungaViaHP(); // Manggil fungsi yang sama
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