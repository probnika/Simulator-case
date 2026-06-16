using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [Header("Боковое меню")]
    public GameObject sideMenuPanel;

    void Start()
    {
        // При старте сцены меню должно быть закрыто
        sideMenuPanel.SetActive(false);
    }

    // Открыть меню
    public void OpenSideMenu()
    {
        sideMenuPanel.SetActive(true);
    }

    // Закрыть меню
    public void CloseSideMenu()
    {
        sideMenuPanel.SetActive(false);
    }

    // Сюда потом допишете методы для перехода в инвентарь или контракты
    public void OpenInventory()
    {
        Debug.Log("Открываем Инвентарь");
    }
}