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
    [Header("other links:")]
    MainEntry mainEntry;
    #endregion

    // // // 

    public void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();
        AddListenerToButtons();
    }

    public void UpdateManager()
    {
        OpenCloseInventory();

        if (InputManager.Instance.inputPressed.interactPressed)//test
        {
            TryAgainButton();
        }
    }

    public void FixedUpdateManager()
    {

    }

    public void StopManager()
    {
        instance = null;
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
        mainEntry.GoToNextFlow(CurrentState.Game); //Switch to Menu Scene/Flow.
    }
    void TryAgainButton()
    {//Restart GameFlow
        mainEntry.GoToNextFlow(CurrentState.Menu);//Restart the current Scene/Flow.
    }

}
