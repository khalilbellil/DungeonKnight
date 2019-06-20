using UnityEngine;

public class InputManager
{
    #region Singleton Pattern
    private static InputManager instance = null;
    private InputManager() { }
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }
            return instance;
        }
    }
    #endregion

    public InputPkg fixedInputPressed; //Every fixed update we fill this
    public InputPkg inputPressed;      //Every update we fill this

    // // //

    public void Initialize()
    {
        fixedInputPressed = new InputPkg();
        inputPressed = new InputPkg();
    }

    public void UpdateManager()
    {
        //Mouse inputs:
        inputPressed.deltaMouse.x = Input.GetAxis("Mouse X");
        inputPressed.deltaMouse.y = Input.GetAxis("Mouse Y");
        inputPressed.mousePosToRay = inputPressed.MousePosToRay(Input.mousePosition);
        inputPressed.leftMouseButtonPressed = Input.GetMouseButtonDown(0);
        inputPressed.leftMouseButtonReleased = Input.GetMouseButtonUp(0);
        inputPressed.leftMouseButtonHeld = Input.GetMouseButton(0);
        inputPressed.rightMouseButtonPressed = Input.GetMouseButtonDown(1);
        inputPressed.middleMouseButtonPressed = Input.GetMouseButtonDown(2);
        
        inputPressed.anyKeyPressed = Input.anyKeyDown;
        inputPressed.inventoryPressed = Input.GetButtonDown("Inventory");
        inputPressed.interactPressed = Input.GetButtonDown("Interaction");

        inputPressed.dirPressed.x = Input.GetAxis("Horizontal");
        inputPressed.dirPressed.y = Input.GetAxis("Vertical");
        inputPressed.dirPressed.Normalize();
        inputPressed.jumpPressed = Input.GetButtonDown("Jump");
        inputPressed.switchWeaponPressed = Input.GetButtonDown("Switch Weapon");
    }

    public void FixedUpdateManager()
    {
        //Mouse inputs:
        inputPressed.deltaMouse.x = Input.GetAxis("Mouse X");
        inputPressed.deltaMouse.y = Input.GetAxis("Mouse Y");
        inputPressed.mousePosToRay = inputPressed.MousePosToRay(Input.mousePosition);
        if (PlayerManager.Instance.player)
        {
            inputPressed.aimingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerManager.Instance.player.transform.position).normalized;
        }
        //Debug.Log(string.Format("AimDir:{0},WP:{1},MP:{2}", inputPressed.aimingDirection.normalized, Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mousePosition));
        inputPressed.leftMouseButtonPressed = Input.GetMouseButtonDown(0);
        inputPressed.leftMouseButtonReleased = Input.GetMouseButtonUp(0);
        inputPressed.leftMouseButtonHeld = Input.GetMouseButton(0);
        inputPressed.rightMouseButtonPressed = Input.GetMouseButtonDown(1);
        inputPressed.middleMouseButtonPressed = Input.GetMouseButtonDown(2);
        
        inputPressed.anyKeyPressed = Input.anyKeyDown;
        inputPressed.inventoryPressed = Input.GetButtonDown("Inventory");
        inputPressed.interactPressed = Input.GetButtonDown("Interaction");
        fixedInputPressed.dirPressed.x = Input.GetAxis("Horizontal");
        fixedInputPressed.dirPressed.y = Input.GetAxis("Vertical");
        inputPressed.dirPressed.Normalize();
        fixedInputPressed.jumpPressed = Input.GetButtonDown("Jump");
        inputPressed.switchWeaponPressed = Input.GetButtonDown("Switch Weapon");
    }

    public void StopManager()
    {
        instance = null;
    }

    // // //

    public class InputPkg
    {
        public Vector2 dirPressed;   //side to side and foward and back
        public Vector2 deltaMouse;   //the delta change of mouse position
        public Vector2 aimingDirection;
        public Ray mousePosToRay;
        public bool leftMouseButtonPressed;
        public bool leftMouseButtonReleased;
        public bool leftMouseButtonHeld;
        public bool rightMouseButtonPressed;
        public bool middleMouseButtonPressed;
        public bool jumpPressed;  //If jump was pressed this frame
        public bool anyKeyPressed;
        public bool inventoryPressed;
        public bool interactPressed;
        public bool switchWeaponPressed;

        public override string ToString()
        {
            return string.Format("DirPressed[{0}],DeltaMouse[{1}],JumpPressed[{2}],InventoryPressed[{3}],InteractPressed[{4}], SwitchWeaponPressed[{5}] ", dirPressed, deltaMouse, jumpPressed, inventoryPressed, interactPressed, switchWeaponPressed);
        }

        public Ray MousePosToRay(Vector3 mousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            return ray;
        }

    }

}
