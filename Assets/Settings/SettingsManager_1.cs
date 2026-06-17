using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Tabs & Panels")]
    [SerializeField] private List<Button> tabButtons;
    [SerializeField] private List<GameObject> contentPanels;
    
    [Header("Settings Elements: General")]
    [SerializeField] private TMP_Dropdown languageDropdown;
    
    [Header("Settings Elements: Appearance")]
    [SerializeField] private Toggle themeToggle; // Вкл = Темная, Выкл = Светлая
    
    [Header("Settings Elements: Projects")]
    [SerializeField] private TMP_InputField projectPathInputField;

    private void Start()
    {
        InitTabs();
        LoadSettings();
    }

    #region Tab Management Logic

    private void InitTabs()
    {
        // Назначаем листенеры для кнопок динамически
        for (int i = 0; i < tabButtons.Count; i++)
        {
            int index = i; // Локальная копия для замыкания
            tabButtons[i].onClick.AddListener(() => SelectTab(index));
        }

        // Открываем первую вкладку по умолчанию
        SelectTab(0);
    }

    public void SelectTab(int tabIndex)
    {
        for (int i = 0; i < contentPanels.Count; i++)
        {
            // Активируем только ту панель, чей индекс совпадает с нажатой кнопкой
            contentPanels[i].SetActive(i == tabIndex);
            
            // Визуально подсвечиваем активную кнопку (опционально)
            ColorBlock cb = tabButtons[i].colors;
            cb.normalColor = (i == tabIndex) ? Color.gray : Color.white;
            tabButtons[i].colors = cb;
        }
    }

    #endregion

    #region Save & Load Logic

    // Вызывается при нажатии кнопки "Save" или автоматически при изменении
    public void SaveSettings()
    {
        // 1. Сохраняем язык (индекс дропдауна)
        PlayerPrefs.SetInt("LanguageIndex", languageDropdown.value);

        // 2. Сохраняем тему (0 = Светлая, 1 = Темная)
        PlayerPrefs.SetInt("DarkTheme", themeToggle.isOn ? 1 : 0);

        // 3. Сохраняем путь к проектам
        PlayerPrefs.SetString("ProjectPath", projectPathInputField.text);

        PlayerPrefs.Save();
        Debug.Log("Настройки успешно сохранены!");
    }

    private void LoadSettings()
    {
        // Загружаем язык (если данных нет, ставим 0 - по умолчанию)
        languageDropdown.value = PlayerPrefs.GetInt("LanguageIndex", 0);

        // Загружаем тему (по умолчанию 1 = темная, мы же в Unity)
        themeToggle.isOn = PlayerPrefs.GetInt("DarkTheme", 1) == 1;

        // Загружаем путь к проектам
        projectPathInputField.text = PlayerPrefs.GetString("ProjectPath", "C:/UnityProjects");
        
        // Применяем изменения (например, тему) сразу при загрузке
        ApplyTheme(themeToggle.isOn);
    }

    #endregion

    #region Interactive Actions

    // Метод для живого переключения темы (вешается на Event OnValueChanged тогла)
    public void ApplyTheme(bool isDark)
    {
        if (isDark)
        {
            Camera.main.backgroundColor = new Color(0.12f, 0.12f, 0.12f); // Темный пресет
            Debug.Log("Включена темная тема");
        }
        else
        {
            Camera.main.backgroundColor = new Color(0.85f, 0.85f, 0.85f); // Светлый пресет
            Debug.Log("Включена светлая тема");
        }
    }

    #endregion
}