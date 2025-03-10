using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnigmeGestion enigmeGestion;
    public int number;

    public void JouerEnigme()
    {
        enigmeGestion.LoadEnigmes(number);
    }
}