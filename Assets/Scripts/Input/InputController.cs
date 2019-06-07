using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    #region Singleton Patern
    private static InputController instance = null;
    private InputController() { }
    public static InputController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputController();
            }
            return instance;
        }
    }
    #endregion

    private Player player;

    public void Initialize(Player player)
    {
        this.player = player;
    }

    public void UpdatePosition(Vector2 dir, Player player)
    {
        player.UpdateMovement(dir);

    }

    public void UpdateActions(Vector2 dir, Player player)
    {
        player.useWeapon(dir);
        player.Interact();
    }

}
