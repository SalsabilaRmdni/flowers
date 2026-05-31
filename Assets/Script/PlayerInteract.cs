using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRange = 3f;
    public Camera playerCamera;
    
    // Sekarang kita pakai Level1Manager
    public Level1Manager levelManager; 

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            // Cek apakah yang ditatap itu Bunga Merah
            if (hit.collider.CompareTag("RedFlower"))
            {
                levelManager.interactText.gameObject.SetActive(true);

                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Destroy(hit.collider.gameObject);
                    levelManager.FlowerCollected();
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