using System.Collections.Generic;
using UnityEngine;

public class EnigmeGestion : MonoBehaviour
{
    public static EnigmeGestion Instance {get; private set;}
    
    private List<Enigme> enigmes= new List<Enigme>();
    public Enigme enigmeActuelle;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        AddEnigmes();
    }

    private void AddEnigmes()
    {   
        // 0xx : Enigmes de fin de chapitre
        
        // 1xx : Enigmes ClassicText
        
        enigmes.Add(new T_ClassicText("Les chiffres de la porte", "Vous vous trouvez devant une lourde porte verrouillée, sans serrure apparente.\nSur le mur à côté, une plaque porte cette inscription :\n\n\"Mon premier est le double de mon second.\nMon troisième est la somme de mon premier et de mon second.\nMon quatrième est la somme de mon deuxième et de mon troisième.\nAinsi de suite...\nLorsque mon cinquième est différent de 7, pas la peine d'insister, la porte ne s'ouvrira pas.\"\n\nSous cette inscription, un pavé numérique attend votre réponse. Que devez-vous entrer pour ouvrir la porte ?", 101, "21347"));
        enigmes.Add(new T_ClassicText("Errance", "Un voyageur marche seul sur un sentier forestier lorsqu'il arrive à une intersection avec trois panneaux indicateurs.\nChacun pointe vers un chemin différent et porte une inscription :\n\n 1 \"Ce chemin mène à la ville, mais seulement si l’un des deux autres panneaux dit vrai.\"\n 2 \"Ce chemin est le bon si et seulement si le premier panneau ment.\"\n 3 \"Ce chemin ne mène nulle part.\"\n\nLe voyageur sait qu’un seul de ces panneaux dit la vérité, tandis que les deux autres mentent.\nQuel chemin doit-il prendre pour atteindre la ville ? Ecrivez le numéro du panneau qu'il devrait suivre.", 102, "2"));
        
        
        
        
        
        // 9xx : Enigmes de Test
        
        enigmes.Add(new T_TestType("Test d'UI", "Les explications sont une partie intégrante de l'énigme. Comme leur nom l'indique c'est ici que le joueur pourra avoir toutes les informations qu'il lui faut pour résoudre l'énigme. \nConcrètement, dans le code, la classe <Enigme> prend en paramètre un titre, des explications et un numéro et s'occupe automatiquement de tout bien placer dans les différents champs. \nLe texte est mis à l'échelle automatiquement.\nVous remarquerez aussi la présence d'une partie Notes qui permet au joueur de prendre des notes manuscrites.", 900));
        enigmes.Add(new T_ClassicText("Test T_ClassicText", "Les énigmes les plus simples du point de vue du code mais plus complexes à créer sont celles-ci. Pour répondre à l'énigme il suffit d'entrer la réponse dans la barre de texte.\nLe champ de réponse devient violet lorsque la réponse et fausse et vert lorsqu'elle est juste.\nIci, la réponse est Réponse", 910, "Réponse"));
               
    }

    public void LoadEnigmes(int number)
    {
        enigmeActuelle = enigmes.Find(e => e.Number == number);
        
        if (enigmeActuelle != null)
        {
            Debug.Log($"🔍 Chargement de l'énigme : {enigmeActuelle.Title}");
            EnigmeManager.Instance.LoadEnigme(enigmeActuelle.Explanations, enigmeActuelle.Number, enigmeActuelle.Title);
            
            enigmeActuelle.Initialize();
        }
        else
        {
            Debug.LogError($"❌ Aucune énigme trouvée avec le numéro {number}.");
        }
    }

    public void Check()
    {
        if (enigmeActuelle != null && enigmeActuelle.Check())
        {
            Debug.Log("Enigme résolue !");
        }
    }

}