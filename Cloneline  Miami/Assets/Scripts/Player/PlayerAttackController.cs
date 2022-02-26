using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private Transform _attackCollider;

    private AudioSource _audioSource;
    private PlayerWeaponManager _playerWeaponManager;
    private bool _canShoot = true;

    public bool IsAttacking { get; private set; }

    void Start()
    {
        _playerWeaponManager = GetComponent<PlayerWeaponManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _canShoot && _playerWeaponManager.RemainingAmmo > 0) //
            Attack();
    }

    private void Attack()
    {
        /*switch(_playerWeaponManager.PlayerCurrentWeapon)
        {
            case PlayerWeaponManager.CurrentWeapon.silencedPistol:
                //_playerWeaponManager.CurrentAmmo--;
                StartCoroutine(Shoot(_playerWeaponManager.AttackDelay));
                //_playerWeaponManager.CurrentPistolAmmo--;
                _playerWeaponManager.RemainingAmmo--;
                break;

            case PlayerWeaponManager.CurrentWeapon.M16:
                //_playerWeaponManager.CurrentAmmo--;
                StartCoroutine(Shoot(_playerWeaponManager.AttackDelay));
                //_playerWeaponManager.CurrentM16Ammo--;
                _playerWeaponManager.RemainingAmmo--;
                break;

            case PlayerWeaponManager.CurrentWeapon.Axe:
                Debug.Log("wow");
                break;
        }*/

        StartCoroutine(Shoot(_playerWeaponManager.AttackDelay));
        _playerWeaponManager.RemainingAmmo--;
    }

    IEnumerator Shoot(float delay)
    {
        Instantiate(Resources.Load("Prefabs/Weapons/" + _playerWeaponManager.BulletType + " Bullet"), _attackCollider.position, _attackCollider.rotation);
        _canShoot = false;
        IsAttacking = true;
        _audioSource.PlayOneShot(_playerWeaponManager.AttackSound);
        Debug.Log(_playerWeaponManager.BulletType.ToString() + " Bullet, " + _playerWeaponManager.RemainingAmmo); //
        yield return new WaitForSeconds(delay);
        _canShoot = true;
        IsAttacking = false;
    }

    public IEnumerator MeleeAttack(float delay)
    {
        _attackCollider.GetComponent<BoxCollider2D>().enabled = true;
        _audioSource.PlayOneShot(_playerWeaponManager.AttackSound);
        yield return new WaitForSeconds(delay);
        _attackCollider.GetComponent<BoxCollider2D>().enabled = false;
    }
}
