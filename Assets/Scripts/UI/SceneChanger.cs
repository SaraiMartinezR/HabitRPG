using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    //Configuración del cambio de escena
    public string sceneToLoad;  // Nombre de la escena destino

    public float fadeDuration = 0.5f;  // Para una transición suave

    public CanvasGroup fadePanel;  // Asigna un panel negro semitransparente si lo usas

    // Llamado desde un botón (en OnClick) o desde otro script
    public void ChangeScene()
    {
        // Si hay un panel de fade, usamos la versión con animación
        if (fadePanel != null)
            StartCoroutine(FadeAndChangeScene());
        else
            SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator FadeAndChangeScene()
    {
        fadePanel.gameObject.SetActive(true);

        // Hacer fade a negro
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadePanel.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneToLoad);
    }

    // Métodos rápidos para usar directamente desde botones
    public void GoToHabitos() => SceneManager.LoadScene("Habits");
    public void GoToHome() => SceneManager.LoadScene("Home");
}
