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
        FillInputPackage(inputPressed);
    }

    public void FixedUpdateManager()
    {
        FillInputPackage(fixedInputPressed);
    }

    public void FillInputPackage(InputPkg toFill)
    {
        toFill.deltaMouse.x = Input.GetAxis("Mouse X");
        toFill.deltaMouse.y = Input.GetAxis("Mouse Y");
        toFill.mousePosToRay = toFill.MousePosToRay(Input.mousePosition);
        if (PlayerManager.Instance.player)
            toFill.aimingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - PlayerManager.Instance.player.transform.position).normalized;
        //Debug.Log(string.Format("AimDir:{0},WP:{1},MP:{2}", toFill.aimingDirection.normalized, Camera.main.ScreenToWorldPoint(Input.mousePosition), Input.mousePosition));
        toFill.leftMouseButtonPressed = Input.GetMouseButtonDown(0);
        toFill.leftMouseButtonReleased = Input.GetMouseButtonUp(0);
        toFill.leftMouseButtonHeld = Input.GetMouseButton(0);
        toFill.rightMouseButtonPressed = Input.GetMouseButtonDown(1);
        toFill.middleMouseButtonPressed = Input.GetMouseButtonDown(2);

        toFill.anyKeyPressed = Input.anyKeyDown;
        toFill.inventoryPressed = Input.GetButtonDown("Inventory");
        toFill.interactPressed = Input.GetButtonDown("Interaction");
        toFill.dirPressed.x = Input.GetAxis("Horizontal");
        toFill.dirPressed.y = Input.GetAxis("Vertical");
        toFill.dirPressed.Normalize();
        toFill.jumpPressed = Input.GetButtonDown("Jump");
        toFill.switchWeaponPressed = Input.GetButtonDown("Switch Weapon");
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
