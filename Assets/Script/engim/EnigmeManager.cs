using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Threading;

public class EnigmeManager : MonoBehaviour
{
   public static EnigmeManager Instance { get; private set; }
   [SerializeField] public GameObject enigmePrefab;
   public GameObject PlayField;

   public static PlayFieldManager PlayFieldManager;
   
   private GameObject enigmeActuelle;

   [SerializeField] private GameObject menu;
   [SerializeField] private Add but;
   
   private void Awake()
   {
      if (Instance == null) Instance = this;
      else Destroy(gameObject);
      
      if (PlayField == null)
      {
         PlayField = GameObject.Find("PlayField");

         if (PlayField == null)
         {
            Debug.LogError("❌ PlayField introuvable !");
         }
         else
         {
            Debug.Log("✅ PlayField trouvé !");
         }
      }

      if (PlayField != null)
      {
         PlayFieldManager = PlayField.GetComponent<PlayFieldManager>();

         if (PlayFieldManager == null)
         {
            Debug.LogError("❌ PlayFieldManager introuvable sur PlayField !");
         }
         else
         {
            Debug.Log("✅ PlayFieldManager récupéré avec succès !");
         }
      }
   }

   public void LoadEnigme(string ExplanationsText, int PuzzleNumber, string PuzzleTitle)
   {
      if (enigmeActuelle != null)
      {
         Destroy(enigmeActuelle);
      }
      
      if (enigmePrefab == null)
      {
         Debug.LogError("❌ `enigmePrefab` n'est pas assigné dans l'Inspector !");
         return;
      }

      enigmeActuelle = Instantiate(enigmePrefab, transform);
      Debug.Log("✅ Enigme instanciée avec succès !");

      _setup setup = enigmeActuelle.GetComponent<_setup>();
    
      if (setup != null)
      {
         Debug.Log("✅ `_setup` trouvé sur l'objet instancié !");
         setup.Initialiser(ExplanationsText, PuzzleNumber, PuzzleTitle);

         if (PlayFieldManager != null)
         {
            PlayFieldManager.Show();
         }
         else
         {
            Debug.LogError("❌ PlayFieldManager est NULL, impossible d'afficher le PlayField !");
         }
      }
      else
      {
         Debug.LogError("❌ `_setup` est NULL ! Vérifie que le script `_setup` est bien attaché au prefab.");
      }
   }

   public void Validate()
   {
      if (enigmeActuelle != null)
      {
         Enigme enigme = EnigmeGestion.Instance.enigmeActuelle;
         if (enigme != null)
         {
            bool isValid = enigme.Check();
            Debug.Log(isValid ? "✅ Enigme validée !" : "❌ Enigme incorrecte !");
            if (isValid)
            {
               but.Start();
               enigme.finished = true;
               Quit(0);
            }
         }
         else
         {
            Debug.LogError("❌ Enigme actuelle n'a pas de composant Enigme !");
         }
      }
      else
      {
         Debug.LogError("❌ Aucune énigme en cours !");
      }
   }

   public void Quit(int i)
   {
      StartCoroutine(DelayedQuit(i)); 
   }
    
   private IEnumerator DelayedQuit(int i)
   {
      yield return new WaitForSeconds(1f);
      Debug.Log("1s écoulée");
      
      if (enigmeActuelle != null)
      {
         Destroy(enigmeActuelle);
         enigmeActuelle = null;
      }

      if (PlayField != null)
      {
         GameObject background = PlayField.transform.Find("BackGround")?.gameObject;

         foreach (Transform child in PlayField.transform)
         {
            if (child.gameObject != background)
            {
               Destroy(child.gameObject);
            }
         }
         //PlayFieldManager.Hide();
         Debug.Log("✅ PlayField réinitialisé, sauf le background !");
      }

      if (i == 1){
        yield return new WaitForSeconds(10f);
        menu.SetActive(true);
      }
        
   }


   
}
