using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField] 
    public float lerpSpeed = 10f;
    [SerializeField] 
    public float forwardSpeed = 5f; 

    private Vector3 targetPosition;
    private const float minX = -6f, maxX = 6f;
    private int controlType;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetPosition.x, Time.deltaTime * lerpSpeed),
            transform.position.y,
            transform.position.z + forwardSpeed * Time.deltaTime 
        );
    }

    public void MoveLeft()
    {
        targetPosition.x -= 2f;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
    }

    public void MoveRight()
    {
        targetPosition.x += 2f;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
    }

    private void OnEnable()
    {
        InputController.OnControlTypeChanged += HandleControlChange;
    }

    private void OnDisable()
    {
        InputController.OnControlTypeChanged -= HandleControlChange;
    }

    private void HandleControlChange(int type)
    {
        controlType = type;
    }
}
