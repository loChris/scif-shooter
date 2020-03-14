using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hasCoin = false;
    private int _currentAmmo;
    private bool _isReloading = false;
    private CharacterController _controller;
    [SerializeField] private AudioSource _gunFireSound;
    [SerializeField] private GameObject _hitMarkerPrefab;
    [SerializeField] private GameObject _gunFire;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private int _maxAmmo = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        GetGameComponents();
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Shoot();
        ReloadWeapon();
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _isReloading == false)
        {
            _gunFire.SetActive(true);

                if (_gunFireSound.isPlaying == false) _gunFireSound.Play();

                _currentAmmo--;
                _uiManager.UpdateAmmo(_currentAmmo);
                Ray rayOrigin = Camera.main.ViewportPointToRay(
                    new Vector3(
                        0.5f,
                        0.5f,
                        0
                    )
                );
                RaycastHit hitInfo;
                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    Debug.Log("raycast hit" + hitInfo.transform.name);
                    GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point,
                        Quaternion.LookRotation(hitInfo.normal));
                    Destroy(hitMarker, .1f);
                }
        }
        else
        {
            _gunFire.SetActive(false);
            _gunFireSound.Stop();
        }
    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        
        _controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator ReloadWeaponCoroutine()
    {
        yield return new WaitForSeconds(_reloadTime);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
        _isReloading = false;
    }

    void ReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(ReloadWeaponCoroutine());
        }
    }

    public void EnableWeapon()
    {
        _weapon.SetActive(true);    
    }
    
    void GetGameComponents()
    {
        _controller = GetComponent<CharacterController>();
        _gunFireSound = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
}
