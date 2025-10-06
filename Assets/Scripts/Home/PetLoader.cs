using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetLoader : MonoBehaviour
{
    [Header("UI references")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Image petImage;

    [Header("Pet sprites (match the keys used in CharacterSelection)")]
    public Sprite pet1Sprite;
    public Sprite pet2Sprite;
    public Sprite pet3Sprite;
    public Sprite pet4Sprite;

    void Start()
    {
        LoadPetFromPrefs();
    }

    void LoadPetFromPrefs()
    {
        // Leer PlayerPrefs (valores guardados en la escena de selección)
        string petName = PlayerPrefs.GetString("PetName", "MiMascota");
        string petType = PlayerPrefs.GetString("PetType", "Pet1");
        int petLevel = PlayerPrefs.GetInt("PetLevel", 1);

        // Asignar textos (comprueba null para evitar errores)
        if (nameText != null) nameText.text = petName;
        if (levelText != null) levelText.text = "Nivel: " + petLevel.ToString();

        // Asignar sprite según la clave petType
        if (petImage != null)
        {
            switch (petType)
            {
                case "Pet1":
                    petImage.sprite = pet1Sprite;
                    break;
                case "Pet2":
                    petImage.sprite = pet2Sprite;
                    break;
                case "Pet3":
                    petImage.sprite = pet3Sprite;
                    break;
                case "Pet4":
                    petImage.sprite = pet4Sprite;
                    break;
                default:
                    petImage.sprite = pet1Sprite;
                    break;
            }

            // Ajustar tamaño si quieres que adopte su tamaño nativo
            petImage.SetNativeSize();
        }
    }
}
