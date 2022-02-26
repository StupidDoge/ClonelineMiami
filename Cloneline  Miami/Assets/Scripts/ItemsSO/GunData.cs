using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Weapons/Gun", order = 1)]
public class GunData : ItemData
{
    public enum BulletType
    {
        Standard,
        Shotgun
    }

    [Header("Bullets info")]
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private BulletType _bulletType;

    public int MaxAmmo => _maxAmmo;
    public int CurrentAmmo { get { return _currentAmmo; } set { _currentAmmo = value; } }
    public BulletType bulletType => _bulletType;

}
