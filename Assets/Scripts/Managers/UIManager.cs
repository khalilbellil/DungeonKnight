using UnityEngine;

public class UIManager
{
    #region Singleton Pattern
    private static UIManager instance = null;
    private UIManager() { }
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    #endregion

    #region Variables
    [Header("UI Prafabs links:")]
    public GameObject inventoryUI;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    #endregion

    // // // 

    public void Initialize()
    {
        AddListenerToButtons();
    }

    public void UpdateManager()
    {
        OpenCloseInventory();
    }

    public void FixedUpdateManager()
    {

    }

    public void StopManager()
    {

    }

    // // // 

    void AddListenerToButtons()
    {//Adding listeners to the buttons

    }

    void OpenCloseInventory()
    {//Set the inventory UI to active when the inventory input is pressed

    }

    void ActivateMouseForUI()
    {//Desactivate Inputs for player movement and camera movement, activate mouse for UI
        
    }

    void DesactivateMouseForUI()
    {

    }


    //GameOver UI:
    void BackToMainMenuButton()
    {//Go back to Menu
        MainEntry.sceneNb = 1; //Switch to Menu Scene and Menu Flow.
    }
    void TryAgainButton()
    {//Restart GameFlow
        MainEntry.sceneNb = 1; //Switch to Menu
        MainEntry.sceneNb = 2; //Switch to Game
    }

}
