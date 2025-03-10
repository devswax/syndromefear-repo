using TMPro;
using UnityEngine;

public class _setup : MonoBehaviour
{
    private TextMeshProUGUI Number;
    private TextMeshProUGUI Title;
    private TextMeshProUGUI Explanations;
    private TextMeshProUGUI Header;

    void Awake()
    {
        Number = transform.Find("Body/TitlePage/EnigmeNumber").GetComponent<TextMeshProUGUI>();
        Title = transform.Find("Body/TitlePage/EnigmeTitle").GetComponent<TextMeshProUGUI>();
        Explanations = transform.Find("Body/Explanations/ExplanationText").GetComponent<TextMeshProUGUI>();
        Header = transform.Find("Body/Header/Title").GetComponent<TextMeshProUGUI>();
        
        Debug.Log($"🔍 Number: {(Number != null ? "✅ Trouvé" : "❌ Introuvable")}");
        Debug.Log($"🔍 Title: {(Title != null ? "✅ Trouvé" : "❌ Introuvable")}");
        Debug.Log($"🔍 Explanations: {(Explanations != null ? "✅ Trouvé" : "❌ Introuvable")}");
        Debug.Log($"🔍 Header: {(Header != null ? "✅ Trouvé" : "❌ Introuvable")}");

        if (Header == null || Explanations == null || Number == null || Title == null)
        {
            Debug.LogError("Au moins un tmp non trouvé");
        }

    }

    public void Initialiser(string ExplanationsText, int PuzzleNumber, string PuzzleTitle)
    {
        Explanations.text = ExplanationsText;
        Explanations.fontSize = 64;
        Title.text = PuzzleTitle;
        Number.text = "Enigme n° " + PuzzleNumber;
        Header.text = Number.text + " - " + Title.text;
    }

    
}


