using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public TextMeshProUGUI munitionCount;
    public TextMeshProUGUI munitionLeftCount;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public ParticleSystem smoke;

    public float reloadTime;
    public float magazineSize;
    public float bulletForce;
    public float shootDelay;
    public float ammoRemaining;
    public float volume = 1f;

    private float _shootTimer;
    private float _reloadTimer;
    private float _remainingBullets;
    private float _bulletsToReload;
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

        if (_remainingBullets == 0 && !_isReloading && ammoRemaining > 0)
            StartReload();

        if (_isReloading)
        {
            _reloadTimer -= Time.deltaTime;
        }

        if (_isShooting)
            _shootTimer -= Time.deltaTime;

        //Reload has ended
        if (_reloadTimer < 0 && _isReloading)
        {
            _remainingBullets += _bulletsToReload;
            _isReloading = false;
            UpdateAmmoUI();
        }

        //Can Shoot again
        if (_shootTimer < 0 && _isShooting)
        {
            _isShooting = false;
            _shootTimer = shootDelay;
        }

        if (Input.GetKeyDown("r") && !_isReloading && _remainingBullets < 25)
        {
            StartReload();
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
        AudioSource.PlayClipAtPoint(shootSound, gameObject.transform.position, volume);
        smoke.Play();
    }

    private void StartReload()
    {
        if (ammoRemaining >= magazineSize - _remainingBullets)
        {
            _isReloading = true;
            _reloadTimer = reloadTime;
            ammoRemaining -= magazineSize - _remainingBullets;
            _bulletsToReload = magazineSize - _remainingBullets;
            AudioSource.PlayClipAtPoint(reloadSound, gameObject.transform.position, volume);
            UpdateRemainingAmmoUI();
        }
        else if (ammoRemaining != 0)
        {
            _isReloading = true;
            _reloadTimer = reloadTime;
            _bulletsToReload = ammoRemaining;
            ammoRemaining = 0;
            AudioSource.PlayClipAtPoint(reloadSound, gameObject.transform.position, volume);
            UpdateRemainingAmmoUI();

        }
    }

    public void AddAmmo()
    {
        ammoRemaining += 25;
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
