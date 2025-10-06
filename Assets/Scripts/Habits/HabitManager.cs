using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class HabitManager : MonoBehaviour
{
    [Header("Prefab y UI")]
    public GameObject habitItemPrefab;          // Prefab del hábito
    public Transform habitsListContent;         // Content del Scroll View
    public PetStatsManager petStatsManager;     // Referencia al PetStatsManager (Home)
    public ScrollRect scrollRect;               // ScrollRect de la lista de hábitos

    [Header("UI Añadir Hábito")]
    public TMP_InputField habitNameInput;       // Input nombre
    public TMP_InputField habitXPInput;         // Input XP
    public TMP_Dropdown habitStatDropdown;      // Dropdown de stat
    public Button addHabitButton;               // Botón añadir
    public Button cancelButton;                 // Botón cancelar

    private List<Habit> habits = new List<Habit>();

    void Start()
    {
        // Conectar botones a funciones
        if (addHabitButton != null)
            addHabitButton.onClick.AddListener(OnAddHabitButtonClicked);

        if (cancelButton != null)
            cancelButton.onClick.AddListener(OnCancelAddHabit);

        // Agregamos hábitos de ejemplo
        AddHabit("Hacer ejercicio", "Strength", 10);
        AddHabit("Leer un libro", "Intelligence", 15);
        AddHabit("Dormir bien", "Health", 8);

        // Opcional: ordenar alfabéticamente
        habits.Sort((a, b) => a.name.CompareTo(b.name));

        // Crear la UI de todos los hábitos
        foreach (Habit habit in habits)
        {
            CreateHabitUI(habit);
        }
    }

    /// <summary>
    /// Función llamada al pulsar "Añadir" en la UI
    /// </summary>
    public void OnAddHabitButtonClicked()
    {
        string name = habitNameInput.text;
        string type = habitStatDropdown.options[habitStatDropdown.value].text;
        int xp = 0;

        if (!int.TryParse(habitXPInput.text, out xp))
        {
            Debug.LogWarning("XP inválida, usando 0");
        }

        if (string.IsNullOrEmpty(name))
        {
            Debug.LogWarning("Nombre del hábito vacío");
            return;
        }

        // Agregar hábito y crear UI
        AddHabit(name, type, xp);

        // Limpiar inputs
        ClearHabitInputs();
    }

    /// <summary>
    /// Función llamada al pulsar "Cancelar" en la UI
    /// </summary>
    public void OnCancelAddHabit()
    {
        ClearHabitInputs();
    }

    /// <summary>
    /// Limpia los campos de entrada de la UI
    /// </summary>
    private void ClearHabitInputs()
    {
        habitNameInput.text = "";
        habitXPInput.text = "";
        habitStatDropdown.value = 0;
    }

    /// <summary>
    /// Agrega un nuevo hábito a la lista y crea su UI
    /// </summary>
    public void AddHabit(string name, string type, int xpReward)
    {
        Habit newHabit = new Habit(name, type, xpReward);
        habits.Add(newHabit);

        // Crear UI solo para este hábito
        CreateHabitUI(newHabit);

        // Hacer scroll hacia el último hábito añadido
        ScrollToBottom();
    }

    /// <summary>
    /// Instancia el prefab del hábito y lo configura con HabitItemUI
    /// </summary>
    private void CreateHabitUI(Habit habit)
    {
        if (habitItemPrefab == null || habitsListContent == null)
        {
            Debug.LogError("Prefab o Content del Scroll View no asignado en HabitManager.");
            return;
        }

        GameObject item = Instantiate(habitItemPrefab, habitsListContent);

        HabitItemUI ui = item.GetComponent<HabitItemUI>();
        if (ui != null)
        {
            ui.Setup(habit, petStatsManager);
        }
        else
        {
            Debug.LogError("El prefab HabitItem no tiene el script HabitItemUI asignado");
        }

        // Reset del RectTransform para que el Vertical Layout Group lo gestione correctamente
        RectTransform rt = item.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.localScale = Vector3.one;
            rt.anchoredPosition = Vector2.zero;
        }
    }

    /// <summary>
    /// Mueve el ScrollRect al final para que se vea el último hábito
    /// </summary>
    private void ScrollToBottom()
    {
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases(); // asegura que el layout esté actualizado
            scrollRect.verticalNormalizedPosition = 0f; // 0 = abajo, 1 = arriba
        }
    }
}
