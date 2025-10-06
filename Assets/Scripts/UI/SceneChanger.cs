using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas

public class SceneChanger : MonoBehaviour
{
    // Función pública que podemos llamar desde el botón
    public void GoToHabitos()
    {
        SceneManager.LoadScene("Habits"); // Nombre exacto de la escena
    }
}
