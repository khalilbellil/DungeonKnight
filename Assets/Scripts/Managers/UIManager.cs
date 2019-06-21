using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
	GameObject UI;
	UILinks uiLinks;
	Image bowImage;
	Image swordImage;
	Renderer render;

	public void Initialize()
	{
		//render = UI.GetComponent<Renderer>();


		//------------Initializes the win screen------------//
		//winScreen = GameObject.FindObjectOfType<WinScreen>();
		//winScreen.Initialize(this);
		//-------------------------------------------------//
        
		CreateUI();
		mainEntry = GameObject.FindObjectOfType<MainEntry>();
		uiLinks = GameObject.FindObjectOfType<UILinks>();
		//fix this Image prefab not loading properly
		bowImage = Resources.Load(PrefabsDir.bowDir) as Image;
		swordImage = Resources.Load(PrefabsDir.swordDir) as Image;
		AddListenerToButtons();
	}

	public void UpdateManager()
	{
		uiLinks.timer.text = Timer.Instance.minutes + ":" + Timer.Instance.seconds; //timer for the game 

		uiLinks.coinText.text = PlayerManager.Instance.player.coins.ToString();
		if (Input.GetKeyDown(KeyCode.C))
		{
			PlayerManager.Instance.player.TakeDamage(10);
			Debug.Log("new hp amount: " + PlayerManager.Instance.player.health);
		}
		float a = (float)PlayerManager.Instance.player.health / PlayerManager.Instance.player.maxHealth;



		switch (PlayerManager.Instance.player.activeWeaponIndex)
		{
			case 0:
				uiLinks.currentWeapon = bowImage;
				break;
			case 1:
				uiLinks.currentWeapon = bowImage;
				break;
		}




		//Debug.Log("a: " + a);

		//changes the health bar color from green to red
		Color lerpColor = Color.Lerp(Color.red, Color.green, a);
		uiLinks.healthBar.fillAmount = a;
		uiLinks.healthBar.color = lerpColor;

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

	//Call the win screen when you win the game//
	public void CallWinScreen() {
        UI = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.uiVictDir));
    }

	public void CallDeathScreen()
	{
		UI = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.uiDeathDir));
	}

	//GameOver UI:
	public void BackToMainMenuButton()
	{//Go back to Menu
		mainEntry.GoToNextFlow(CurrentState.Game); //Switch to Menu Scene/Flow.
	}
	public void TryAgainButton()
	{//Restart GameFlow

		mainEntry.GoToNextFlow(CurrentState.Menu); //Switch to Menu Scene/Flow.
	}

	void CreateUI()
	{
		//Instantiate the Player(s)
		UI = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.uiDir));
		//player.enabled = true;
	}

    public void SetPassiveUI(PassiveType passiveType)
    {
        switch (passiveType)
        {
            case PassiveType.Healer:
                uiLinks.passive.sprite = Resources.Load<Sprite>(PrefabsDir.healerPDir);
                break;
            case PassiveType.SpeedBoost:
                uiLinks.passive.sprite = Resources.Load<Sprite>(PrefabsDir.speedBoosterPDir);
                break;
            default:
                break;
        }
    }
}
