using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractFlowerLvl2 : MonoBehaviour
{
    public float interactRange = 3f;
    public Camera playerCamera;
    public Level2FlowerManager levelManager;

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            // Kalau yang ditatap adalah Pot
            if (hit.collider.CompareTag("Pot"))
            {
                // Ambil komponen PotScript dari pot yang lagi ditatap
                PotScript pot = hit.collider.GetComponent<PotScript>();

                // Cek: Apakah potnya ADA scriptnya? Apakah potnya BELUM terisi? Dan apakah player PUNYA bunga?
                if (pot != null && !pot.sudahTerisi && levelManager.bungaDiTangan > 0)
                {
                    levelManager.interactText.text = "Tekan E untuk menanam bunga";
                    levelManager.interactText.gameObject.SetActive(true);

                    // Kalau pencet E
                    if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                    {
                        pot.IsiBunga(); // Panggil fungsi di pot buat munculin bunga
                        levelManager.BungaDitaruh(); // Lapor ke Manager
                        levelManager.interactText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    // Kalau pot udah terisi atau bunga abis, sembunyikan teks
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