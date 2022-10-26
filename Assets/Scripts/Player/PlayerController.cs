using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Health")]
    public float health = 100f;
    [SerializeField] Slider healthBar;
    [Header("Wtf")]
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
    bool CanShoot = true;
    GunShootManager shootManager;
    [SerializeField] float shootInterval = 0.1f;
    [SerializeField] Animator gunAnim;
    float shootTime;
    [SerializeField] float camZoomSpeed = 0.4f;
    [SerializeField] float gunZoomSpeed = 0.4f;
    [SerializeField] Transform gun, gunIdlePos, gunZoomPos;

    [Header("Wtf")]

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
        shootManager = FindObjectOfType<GunShootManager>();
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
        if (!lockLook)
            UpdateMouseLook();
        UpdateMovement();
        UpdateJump();
        UpdateZoom();
        UpdateShoot();
        UpdateHealth();
        // Usually we lock movement here but we need gravity to apply so we don't do that and instead call it in UpdateMovement()
    }

    void UpdateHealth()
    {
        healthBar.value = health / 100;
        if (health <= 0)
        {
            health = 100;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        lockMovement = true;
        lockLook = true;
        gun.gameObject.SetActive(false);
        WaveSystem.CanSpawn = false;
        foreach (Zombie zombie in FindObjectsOfType<Zombie>()) Destroy(zombie.gameObject);

        LerpSolution.StopCoroutines();
    
        LerpSolution.lerpPosition(playerCamera, GameObject.Find("Cam Die Pos").transform.position, 1);
        LerpSolution.lerpRotation(playerCamera, GameObject.Find("Cam Die Pos").transform.rotation, 1);

        yield return new WaitForSeconds(3f);

        WaveSystem.CanSpawn = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                LerpSolution.lerpCamFov(cam, 80, camZoomSpeed);
            }
            LerpSolution.lerpPosition(gun, gunIdlePos.position, gunZoomSpeed, true);
        }
    }

    private void UpdateShoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && CanShoot && GunAmmoManager.CurrentAmmo > 0)
        {
            if (shootTime <= 0)
            {
                shootManager.Shoot(40, Mathf.Infinity);
                GunAmmoManager.CurrentAmmo--;
                gunAnim.SetTrigger("Shoot");
                Debug.Log("SHOOT");
                shootTime = shootInterval;
            }

        }
        shootTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && CanShoot)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        CanShoot = false;
        gunAnim.SetTrigger("Reload");
        yield return new WaitForSeconds(2f);
        GunAmmoManager.CurrentAmmo = GunAmmoManager.MaxAmmo;
        CanShoot = true;
    }

}
