using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class T_ClassicText : Enigme
{
    private InputField inputField;
    private string _expected;

    public T_ClassicText(string title, string explanations, int number, string expected) : base(title, explanations,
        number)
    {
        _expected = expected;
    }

    void CreateInputField()
    {
        GameObject inputObject = new GameObject("EnigmeInput");
        inputObject.transform.SetParent(PlayField.transform, false);

        Image bgImage = inputObject.AddComponent<Image>();
        bgImage.color = new Color(1, 1, 1, 0.8f);

        inputField = inputObject.AddComponent<InputField>();

        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(inputObject.transform, false);

        Text inputText = textObject.AddComponent<Text>();
        inputText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        inputText.text = "";
        inputText.color = Color.black;
        inputText.alignment = TextAnchor.MiddleLeft;

        RectTransform textRect = textObject.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(280, 40);
        textRect.anchoredPosition = Vector2.zero;

        inputField.textComponent = inputText;

        RectTransform rectTransform = inputObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(300, 50);
        rectTransform.anchoredPosition = Vector2.zero;

        Debug.Log("✅ InputField créé dans le PlayField !");
    }

    public override void Initialize()
    {
        PlayField = GameObject.Find("PlayField");

        if (PlayField == null)
        {
            Debug.LogError("❌ PlayField introuvable !");
            return;
        }

        CreateInputField();
    }
    
    
    public override bool Check()
    {
        if (PlayField == null)
        {
            throw new Exception("Si je te laissais continuer tu aurais validé l'énigme sans PlayField ?!");
        }

        bool result = _expected.ToLower() == inputField.text.ToLower();
        Color newColor;
        if (result)
            ColorUtility.TryParseHtmlString("#B2BEB5", out newColor); // Vert si jamais c'est OK
        else
            ColorUtility.TryParseHtmlString("#8C92AC", out newColor); // Violet si jamais c'est pas ok

        inputField.image.color = newColor;
        
        
        Debug.Log("La réponse est " + result);
        return result;
    }
}