using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxMoveLeft = -17f;
    [SerializeField] private float _maxMoveRight = 11f;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        HandleMovement();
    }


    private void HandleMovement()
    {
        //value of x and y
        Vector2 inputVector = InputManager.Instance.MovementVector;
        if (inputVector == Vector2.zero) return;

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        ClampPosition(_maxMoveRight, _maxMoveLeft);
    }

    private void ClampPosition(float _right, float _left)
    {
        float XPosition = Mathf.Clamp(this.transform.position.x, _left, _right);
        this.transform.position = new Vector3(XPosition, this.transform.position.y, this.transform.position.z);
    }
}
