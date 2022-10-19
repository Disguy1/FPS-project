using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    public bool invertMouse;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float sprintMulitplier = 2.0f;
    public float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    public bool lockCursor = true, showCursor = false;
    public bool lockMovement;
    public bool lockGravity;
    public bool lockLook;
    [SerializeField] bool useDeltaTime = true;

    [SerializeField] float jumpHeight;
    bool groundedPlayer;

    [Header("Gun")]
    [SerializeField] float camZoomSpeed = 0.4f;
    [SerializeField] float gunZoomSpeed = 0.4f;
    [SerializeField] Transform gun, gunIdlePos, gunZoomPos;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    [HideInInspector] public CharacterController controller = null;

    [HideInInspector] public Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    float currentSpeed;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    float yVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        updateCursorState(lockCursor, showCursor);
        
    }

    public void updateCursorState(bool shouldLockCursor, bool shouldShowCursor)
    {
        if (shouldLockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(shouldLockCursor)
        {
            Cursor.visible = false;
        }
    }

    void Update()
    {
        if(!lockLook)
            UpdateMouseLook();
        UpdateMovement();
        UpdateJump();
        UpdateZoom();
        // Usually we lock movement here but we need gravity to apply so we don't do that and instead call it in UpdateMovement()
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2();
        if(!invertMouse) targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if(invertMouse) targetMouseDelta = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2();
        if(!lockMovement)
        {
            targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                targetDir = new Vector2(0, 1);
            }
        }
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);


        if (controller.isGrounded)
            velocityY = 0.0f;

        float gravityToUse = gravity;
        if (lockGravity) gravityToUse = 0;

        if(useDeltaTime)
            velocityY += gravityToUse * Time.deltaTime;
        else
            velocityY += gravityToUse;

        if(Input.GetKey(KeyCode.LeftShift))
            currentSpeed = walkSpeed * sprintMulitplier;
        else
            currentSpeed = walkSpeed;

        #region jumping

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * (gravity));
        }
        yVelocity += gravity * Time.deltaTime;

        velocityY = yVelocity;

        #endregion


        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * currentSpeed + Vector3.up * velocityY;
        if (useDeltaTime && controller.enabled)
            controller.Move(velocity * Time.deltaTime);
        else if(!useDeltaTime && controller.enabled)
            controller.Move(velocity);
    }

    void UpdateJump()
    {
        
    }

    void UpdateZoom()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            foreach (Camera cam in FindObjectsOfType<Camera>(useDeltaTime))
            {
                LerpSolution.lerpCamFov(cam, 40, camZoomSpeed);
            }
            LerpSolution.lerpPosition(gun, gunZoomPos.position, gunZoomSpeed, true);
        }
        else
        {
            foreach (Camera cam in FindObjectsOfType<Camera>(useDeltaTime))
            {
                LerpSolution.lerpCamFov(cam, 60, camZoomSpeed);
            }
            LerpSolution.lerpPosition(gun, gunIdlePos.position, gunZoomSpeed, true);
        }
    }
}