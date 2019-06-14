using UnityEngine;
using TMPro;
using UnityEngine.UI;



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
	UILinks uiLinks;

	public void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();
		uiLinks = GameObject.FindObjectOfType<UILinks>();
		AddListenerToButtons();
    }

    public void UpdateManager()
    {
		//uiLinks.coinText.text = PlayerManager.Instance.player.coins.ToString();
		// still have to do the arrow incrementation

		// ------------ for the Demo Friday ------------//
		
        //uiLinks.healthBar.fillAmount = PlayerManager.Instance.player.health / PlayerManager.Instance.player.maxHealth;
		
		// --------------------------------------------//


		//uiLinks.currentWeapon = 
		//uiLinks.active= 

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
