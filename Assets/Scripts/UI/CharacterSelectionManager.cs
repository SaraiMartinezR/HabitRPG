using UnityEngine;
using TMPro;                      
using UnityEngine.SceneManagement; 

public class CharacterSelectionManager : MonoBehaviour
{
    // Campo que escribe el nombre de su mascota
    public TMP_InputField nameInput; 

    // Almacena el nombre del tipo de mascota seleccionada
    private string selectedPet;       

    // Elige una mascota 
    public void SelectPet(string petName)
    {
        selectedPet = petName; // Guardamos el nombre de la mascota elegida
        Debug.Log("Mascota seleccionada: " + petName); // Mensaje en consola para depuración
    }

    // Confirma selección
    public void ConfirmSelection()
    {
        // Comprobamos que el jugador haya escrito un nombre y elegido una mascota
        if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(selectedPet))
        {
            Debug.Log("Falta elegir nombre o mascota"); 
            return; 
        }

        // Guardamos los datos del jugador 
        PlayerPrefs.SetString("PetName", nameInput.text);  // Guarda el nombre de la mascota
        PlayerPrefs.SetString("PetType", selectedPet);     // Guarda el tipo de mascota seleccionada
        PlayerPrefs.Save(); // Asegura que los datos se escriban en el disco

        // Cargamos la escena principal del juego (por ejemplo, "Home")
        SceneManager.LoadScene("Home");
    }
}
