using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public TextMeshProUGUI munitionCount;
    public TextMeshProUGUI munitionLeftCount;
    public AudioSource shootSound;

    public float reloadTime;
    public float magazineSize;
    public float bulletForce;
    public float shootDelay;
    public float ammoRemaining;
    
    private float _shootTimer;
    private float _reloadTimer;
    private float _remainingBullets;
    private bool _isReloading;
    private bool _isShooting;
    
    private void Start()
    {
        _shootTimer = shootDelay;
        _reloadTimer = 0;
        _remainingBullets = magazineSize;
        UpdateRemainingAmmoUI();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot())
            Shoot();
        
        if(_remainingBullets == 0 && !_isReloading && ammoRemaining > 0)
            StartReload();

        if (_isReloading)
        {
            _reloadTimer -= Time.deltaTime;
            print("is reloading with {_reloadTimer}");
        }
        
        if(_isShooting)
            _shootTimer -= Time.deltaTime;

        //Reload has ended
        if (_reloadTimer < 0 && _isReloading)
        {
            _isReloading = false;
            _remainingBullets = magazineSize;
            UpdateAmmoUI();
        }

        //Can Shoot again
        if (_shootTimer < 0 && _isShooting)
        {
            _isShooting = false;
            _shootTimer = shootDelay;
        }
    }

    private bool CanShoot()
    {
        return !_isShooting && !_isReloading && _remainingBullets > 0;
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        _remainingBullets--;
        _shootTimer = shootDelay;
        _isShooting = true;
        UpdateAmmoUI();
        shootSound.Play();
    }

    private void StartReload()
    {
        _isReloading = true;
        _reloadTimer = reloadTime;
        ammoRemaining -= 25;
        UpdateRemainingAmmoUI();
    }

    private void UpdateAmmoUI()
    {
        munitionCount.text = $"{_remainingBullets}/{magazineSize}";
    }

    private void UpdateRemainingAmmoUI()
    {
        munitionLeftCount.text = $"{ammoRemaining}";
    }
}
