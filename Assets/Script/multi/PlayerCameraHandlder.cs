using Unity.Netcode;
using UnityEngine;

public class PlayerCameraHandler : NetworkBehaviour
{
    [SerializeField] private Camera playerCamera;
    private bool isSetup = false;

    // Séparer l'initialisation de la caméra d'OnNetworkSpawn
    private void Start()
    {
        // Attendre d'être prêt sur le réseau avant d'activer la caméra
        if (NetworkManager.Singleton.IsListening)
        {
            SetupCamera();
        }
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        SetupCamera();
    }

    private void SetupCamera()
    {
        // Éviter les doublons d'initialisation
        if (isSetup) return;

        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
            if (playerCamera == null)
            {
                Debug.LogError("Aucune caméra trouvée sur le joueur!", this);
                return;
            }
        }

        // Important: Désactiver l'AudioListener sur les caméras des joueurs non-locaux
        AudioListener audioListener = playerCamera.GetComponent<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = IsOwner;
        }

        // Activer uniquement la caméra du joueur local
        playerCamera.gameObject.SetActive(IsOwner);

        // Si ce joueur est le propriétaire local, désactiver la caméra principale
        if (IsOwner)
        {
            Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<Camera>();
            if (mainCamera != null && mainCamera != playerCamera)
            {
                mainCamera.gameObject.SetActive(false);
            }
        }

        isSetup = true;
        
        Debug.Log($"Caméra configurée pour le joueur {OwnerClientId}, IsOwner: {IsOwner}, Caméra active: {playerCamera.gameObject.activeSelf}");
    }

    // Pour protéger contre les changements tardifs
    public override void OnNetworkDespawn()
    {
        isSetup = false;
    }
}