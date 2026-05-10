using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler<int> OnInteract1Action;
    public event EventHandler<int> OnInteract2Action;
    public event EventHandler<int> OnRightArrowAction;
    public event EventHandler<int> OnLeftArrowAction;
    public static GameInput Instance {  get; private set; }
    private GameInputActions p1Actions;
    private GameInputActions p2Actions;
    private void Awake()
    {
        Instance = this;
        p1Actions = new GameInputActions();
        p1Actions.bindingMask = InputBinding.MaskByGroup("Player1"); // Editördeki Scheme adý
        p1Actions.Player.Enable();

        // Player 2 Instance
        p2Actions = new GameInputActions();
        p2Actions.bindingMask = InputBinding.MaskByGroup("Player2");
        p2Actions.Player.Enable();

        p1Actions.Player.Interact1.performed += _ => OnInteract1Action?.Invoke(this,0);
        p2Actions.Player.Interact1.performed += _ => OnInteract1Action?.Invoke(this,1);

        p1Actions.Player.Interact2.performed += _ => OnInteract2Action?.Invoke(this, 0);
        p2Actions.Player.Interact2.performed += _ => OnInteract2Action?.Invoke(this, 1);

        p1Actions.Player.Right.performed += _ => OnRightArrowAction?.Invoke(this, 0);
        p2Actions.Player.Right.performed += _ => OnRightArrowAction?.Invoke(this, 1);

        p1Actions.Player.Left.performed += _ => OnLeftArrowAction?.Invoke(this, 0);
        p2Actions.Player.Left.performed += _ => OnLeftArrowAction?.Invoke(this, 1);
    }
    public Vector2 GetMovementVectorNormalized(int playerID)
    {
        if (playerID == 0)
            return p1Actions.Player.Movement.ReadValue<Vector2>().normalized;
        else
            return p2Actions.Player.Movement.ReadValue<Vector2>().normalized;
    }
}
