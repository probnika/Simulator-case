using UnityEngine;
using UnityEngine.SceneManagement; // ќб€зательно дл€ загрузки сцен

public class MenuManager : MonoBehaviour
{
    [Header("ѕанели меню")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    // 1.  нопка "»грать" Ч загружает игровую сцену
    public void PlayGame()
    {
        // "Game" Ч это точное название вашей второй сцены с самой игрой
        SceneManager.LoadScene("Game");
    }

    // 2.  нопка "Ќастройки" Ч включает настройки, выключает главное меню
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // 3.  нопка "Ќазад" в настройках Ч возвращает всЄ обратно
    public void CloseSettings()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // 4.  нопка "¬ыйти" Ч закрывает игру
    public void ExitGame()
    {
        Debug.Log("»грок вышел из игры!"); // ѕоказывает в консоли Unity, что кнопка работает
        Application.Quit(); // —работает только в скомпилированной игре (.apk или .exe)
    }
}