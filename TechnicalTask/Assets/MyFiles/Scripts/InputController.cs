using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour // IPointer не стал использовать так как с 3д моделями он у меня не стал работать
{
    private static InputController instance;
    private PlayerMovement player;
    private int controlType; 
    private Vector2 startTouchPosition;
    private bool isDragging = false;
    public static event Action<int> OnControlTypeChanged;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerMovement>();

        controlType = PlayerPrefs.GetInt("ControlType", 0);
    }
    


    private void Update()
    {
        if (controlType == 0) HandleKeyboard();
        if (controlType == 1) HandleSwipe();
        if (controlType == 2) HandleDrag();
    }

    private void HandleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            player.MoveLeft();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            player.MoveRight();
    }

    private void HandleSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float deltaX = Input.mousePosition.x - startTouchPosition.x;

            if (deltaX > 50) player.MoveRight();
            else if (deltaX < -50) player.MoveLeft();
        }
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                float clampedX = Mathf.Clamp(hit.point.x, -6f, 6f);
                player.transform.position = new Vector3(clampedX, player.transform.position.y, player.transform.position.z);
            }
        }
    }

    public static void ChangeControlType(int type)
    {
        instance.controlType = type;
        PlayerPrefs.SetInt("ControlType", type);
        PlayerPrefs.Save();
    }
    private void OnDestroy()
    {
        OnControlTypeChanged = null; 
    }
}
