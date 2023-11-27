using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoState<PlayerController>
{


    [SerializeField] 
    private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    [Header("Aim")]
    [SerializeField]
    Transform aim;

    [Header("Combat")]
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform[] firePoints;

    [SerializeField]
    [Range(0.1F, 1.0F)]
    float fireRate = 0.3F;

    Camera CAMERA;

    Vector2 _mousePosition;

    float _fireTimer;

    protected override void Awake()
    {
        base.Awake();
        CAMERA = Camera.main;
        playerRb = GetComponent<Rigidbody2D>();     
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        _mousePosition = CAMERA.ScreenToWorldPoint(Input.mousePosition);
        HandleAimRotation();

        _fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _fireTimer <= 0.0F)
        {
            Shoot();
            _fireTimer = fireRate;
        }

    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);



    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void HandleAimRotation()
    {
        float angle = Mathf.Atan2(_mousePosition.y - aim.position.y,
            _mousePosition.x - aim.position.x) * Mathf.Rad2Deg - 90.0F;
        aim.rotation = Quaternion.Euler(new Vector3(0.0F, 0.0F, angle));
    }

}
