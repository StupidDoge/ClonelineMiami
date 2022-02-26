using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private GunData _gunData;
    [SerializeField] private int _gunType;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private GunData.BulletType _bulletType;

    public int MaxAmmo => _maxAmmo;
    public int CurrentAmmo { get { return _currentAmmo; } set { _currentAmmo = value; } }
    public float AttackSpeed => _attackSpeed;
    public AudioClip AttackSound => _attackSound;
    public GunData.BulletType BulletType => _bulletType;

    private SpriteRenderer _spriteRenderer;

    public override void SetWeaponData(GunData gunData)
    {
        base.SetWeaponData(gunData);
        gunData = _gunData;
        _gunType = gunData.Type;
        _sprite = gunData.WeaponSprite;
        _maxAmmo = gunData.MaxAmmo;
        _currentAmmo = gunData.CurrentAmmo;
        _attackSpeed = gunData.AttackSpeed;
        _attackSound = gunData.AttackSound;
        _bulletType = gunData.bulletType;
    }

    public override void SetWeaponData(GunData gunData, int remainingAmmo)
    {
        base.SetWeaponData(gunData);
        gunData = _gunData;
        _sprite = gunData.WeaponSprite;
        _maxAmmo = gunData.MaxAmmo;
        _currentAmmo = remainingAmmo;
        _attackSpeed = gunData.AttackSpeed;
        _attackSound = gunData.AttackSound;
        _bulletType = gunData.bulletType;
    }

    private void Awake()
    {
        SetWeaponData(_gunData);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
    }
}
