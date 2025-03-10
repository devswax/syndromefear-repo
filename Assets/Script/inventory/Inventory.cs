using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum ObjectType
    {
        Type1,
        Type2,
        Type3
    }

    [System.Serializable]
    public class UIElement
    {
        public string Name;
        public ObjectType Type;
        public Sprite Image;
    }

    public List<UIElement> elements = new List<UIElement>();
    public Transform parentContainer;
    public GameObject rawImagePrefab; // A prefab containing a RawImage and a Text

    private void Update()
    {
        RefreshUI();
    }

    public void AddElement(string name, ObjectType type, Sprite image)
    {
        elements.Add(new UIElement { Name = name, Type = type, Image = image });
    }

    private void RefreshUI()
    {
        foreach (Transform child in parentContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var element in elements)
        {
            GameObject newElement = Instantiate(rawImagePrefab, parentContainer);
            RawImage rawImage = newElement.GetComponentInChildren<RawImage>();
            Text text = newElement.GetComponentInChildren<Text>();

            if (rawImage != null) rawImage.texture = element.Image.texture;
            if (text != null) text.text = element.Name;
        }
    }
}
