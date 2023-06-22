using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public Vector2 MovementVector => _inputMovementVector;

    PlayerInputAction playerInputAction;

    Vector2 _inputMovementVector;


    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();
    }
    private void Start()
    {
        playerInputAction.InputAction.Movement.started += OnPlayerMovement;
        playerInputAction.InputAction.Movement.performed += OnPlayerMovement;
        playerInputAction.InputAction.Movement.canceled += OnPlayerMovement;
    }




    private void OnPlayerMovement(InputAction.CallbackContext ctx)
    {
        _inputMovementVector = ctx.ReadValue<Vector2>();
    }


    private void OnEnable()
    {
        playerInputAction.InputAction.Enable();
    }
    private void OnDisable()
    {
        playerInputAction.InputAction.Disable();
    }
}
