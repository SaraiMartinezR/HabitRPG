using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public TMP_InputField nameInput; 
    private string selectedPet;       

    public void SelectPet(string petName)
    {
        selectedPet = petName;
        Debug.Log("Mascota seleccionada: " + petName);
    }

    public void ConfirmSelection()
    {
        if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(selectedPet))
        {
            Debug.Log("Falta elegir nombre o mascota");
            return;
        }

        // Guardamos en PlayerPrefs
        PlayerPrefs.SetString("PetName", nameInput.text);
        PlayerPrefs.SetString("PetType", selectedPet);
        PlayerPrefs.Save(); // asegura que se guarde

        // Cambiamos a la pantalla principal
        SceneManager.LoadScene("Home");
    }
}
