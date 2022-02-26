using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public enum CurrentWeapon
    {
        unarmed = 0,
        silencedPistol = 1,
        M16 = 2,
        Axe = 3
    }

    [SerializeField] private CurrentWeapon _currentWeapon;
    [SerializeField] private bool _inTrigger;
    [Header("Remaining ammo")]
    /*[SerializeField] private int _remainingPistolAmmo;
    [SerializeField] private int _remainingM16Ammo;*/
    [SerializeField] private int _remainingAmmo;
    [Space]
    [SerializeField] private BoxCollider2D _attackCollider;
    [Space]
    [SerializeField] private AudioClip _defaultAttackSound;

    private PlayerAnimationController _animationController;
    private BoxCollider2D _boxCollider;
    private List<Vector2> _defaultCollidersValues = new List<Vector2>
    {
        new Vector2(1f, 1.5f),
        new Vector2(0, 0),
        new Vector2(1.5f, 0.7f),
        new Vector2(0, 0),
        new Vector2(0.6f, 0),
    };

    public CurrentWeapon PlayerCurrentWeapon => _currentWeapon;

    /*public int CurrentPistolAmmo { get { return _remainingPistolAmmo; } set { _remainingPistolAmmo = value; } }
    public int CurrentM16Ammo { get { return _remainingM16Ammo; } set { _remainingM16Ammo = value; } }*/
    public int RemainingAmmo { get { return _remainingAmmo; } set { _remainingAmmo = value; } }
    public float AttackDelay { get; private set; } = 0.3f;
    public GunData.BulletType BulletType { get; private set; }
    //public int CurrentAmmo { get; set; }
    public bool IsMelee { get; private set; } = true;
    public AudioClip AttackSound { get; private set; }

    public int MaxAmmo { get; private set; }

    private void Start()
    {
        _animationController = GetComponentInChildren<PlayerAnimationController>();
        _boxCollider = GetComponent<BoxCollider2D>();
        AttackSound = _defaultAttackSound;
        SetPlayerColliders(_defaultCollidersValues);
    }

    private void Update()
    {
        if (!_inTrigger && Input.GetMouseButtonDown(1))
            StartCoroutine(DropWeapon(_currentWeapon));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Gun gun))
        {
            _inTrigger = true;
            if (Input.GetMouseButtonUp(1) && _currentWeapon == CurrentWeapon.unarmed)
                PickUpWeapon(gun);
        }
        if (collision.TryGetComponent(out Melee melee))
        {
            _inTrigger = true;
            if (Input.GetMouseButtonUp(1) && _currentWeapon == CurrentWeapon.unarmed)
                PickUpWeapon(melee);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon"))
            _inTrigger = false;
    }

    private void PickUpWeapon(Gun gun)
    {
        _currentWeapon = (CurrentWeapon)gun.WeaponType;
        _animationController.SetAnimation(gun.WeaponType);
        AttackDelay = gun.AttackSpeed;
        BulletType = gun.BulletType;
        MaxAmmo = gun.MaxAmmo;
        //CurrentAmmo = gun.CurrentAmmo;
        AttackSound = gun.AttackSound;
        SetPlayerColliders(gun.CollidersValues);
        IsMelee = false;

        /*switch (_currentWeapon)
        {
            case CurrentWeapon.silencedPistol:
                _remainingPistolAmmo = gun.CurrentAmmo;
                break;

            case CurrentWeapon.M16:
                _remainingM16Ammo = gun.CurrentAmmo;
                break;
        }*/
        _remainingAmmo = gun.CurrentAmmo;

        Destroy(gun.gameObject);
    }

    private void PickUpWeapon(Melee melee)
    {
        _currentWeapon = (CurrentWeapon)melee.WeaponType;
        _animationController.SetAnimation(melee.WeaponType);
        AttackSound = melee.AttackSound;
        SetPlayerColliders(melee.CollidersValues);
        IsMelee = true;
        Destroy(melee.gameObject);
    }

    private IEnumerator DropWeapon(CurrentWeapon currentWeapon)
    {
        yield return new WaitForSeconds(0.1f);
        if (_currentWeapon != CurrentWeapon.unarmed)
        {
            _animationController.SetAnimation(0);
            SetPlayerColliders(_defaultCollidersValues);
            GameObject thrownWeapon = Instantiate(Resources.Load("Prefabs/Weapons/" + currentWeapon), transform.position, Quaternion.identity) as GameObject;
            if (thrownWeapon.TryGetComponent(out Gun gun))
            {
                /*if (gun.WeaponType == (int)CurrentWeapon.silencedPistol)
                {
                    gun.CurrentAmmo = _remainingPistolAmmo;
                    _remainingPistolAmmo = 0;
                }
                if (gun.WeaponType == (int)CurrentWeapon.M16)
                {
                    gun.CurrentAmmo = _remainingM16Ammo;
                    _remainingM16Ammo = 0;
                }*/

                gun.CurrentAmmo = _remainingAmmo;

            }
            _currentWeapon = CurrentWeapon.unarmed;
            //CurrentAmmo = 0;
            _remainingAmmo = 0;
            MaxAmmo = 0;
            AttackDelay = 0.3f;
            AttackSound = _defaultAttackSound;
            IsMelee = true;
        }
    }

    private void SetPlayerColliders(List<Vector2> values)
    {
        _boxCollider.size = values[0];
        _boxCollider.offset = values[1];
        _attackCollider.size = values[2];
        _attackCollider.offset = values[3];
        _attackCollider.transform.localPosition = values[4];
    }
}
