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
        inputPressed.leftMouseButtonPressed = Input.GetMouseButton(0);
        inputPressed.rightMouseButtonPressed = Input.GetMouseButton(1);
        inputPressed.middleMouseButtonPressed = Input.GetMouseButton(2);
        
        inputPressed.anyKeyPressed = Input.anyKeyDown;
        inputPressed.inventoryPressed = Input.GetButtonDown("Inventory");
        inputPressed.interactPressed = Input.GetButtonDown("Interaction");

        inputPressed.dirPressed.x = Input.GetAxis("Horizontal");
        inputPressed.dirPressed.y = Input.GetAxis("Vertical");
        inputPressed.jumpPressed = Input.GetButtonDown("Jump");
    }

    public void FixedUpdateManager()
    {
        //Mouse inputs:
        inputPressed.deltaMouse.x = Input.GetAxis("Mouse X");
        inputPressed.deltaMouse.y = Input.GetAxis("Mouse Y");
        inputPressed.mousePosToRay = inputPressed.MousePosToRay(Input.mousePosition);
        inputPressed.leftMouseButtonPressed = Input.GetMouseButton(0);
        inputPressed.rightMouseButtonPressed = Input.GetMouseButton(1);
        inputPressed.middleMouseButtonPressed = Input.GetMouseButton(2);
        
        inputPressed.anyKeyPressed = Input.anyKeyDown;
        inputPressed.inventoryPressed = Input.GetButtonDown("Inventory");
        inputPressed.interactPressed = Input.GetButtonDown("Interaction");

        fixedInputPressed.dirPressed.x = Input.GetAxis("Horizontal");
        fixedInputPressed.dirPressed.y = Input.GetAxis("Vertical");
        fixedInputPressed.jumpPressed = Input.GetButtonDown("Jump");
    }

    public void StopManager()
    {

    }

    public class InputPkg
    {
        public Vector2 dirPressed;   //side to side and foward and back
        public Vector2 deltaMouse;   //the delta change of mouse position
        public Ray mousePosToRay;
        public bool leftMouseButtonPressed;
        public bool rightMouseButtonPressed;
        public bool middleMouseButtonPressed;
        public bool jumpPressed;  //If jump was pressed this frame
        public bool anyKeyPressed;
        public bool inventoryPressed;
        public bool interactPressed;

        public override string ToString()
        {
            return string.Format("DirPressed[{0}],DeltaMouse[{1}],JumpPressed[{2}],InventoryPressed[{3}],InteractPressed[{4}] ", dirPressed, deltaMouse, jumpPressed, inventoryPressed, interactPressed);
        }

        public Ray MousePosToRay(Vector3 mousePos)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            return ray;
        }

    }

}
