using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text _ammoCount;
    [SerializeField] private Text _centerText;
    [SerializeField] private Text _deathText;

    private static PlayerWeaponManager _playerWeaponManager;

    void Start()
    {
        _playerWeaponManager = FindObjectOfType<PlayerWeaponManager>();
    }

    void Update()
    {
        ChangeAmmoCounter();
    }

    public void ChangeAmmoCounter()
    {
        if (!_playerWeaponManager.IsMelee)
            _ammoCount.text = "AMMO: " + _playerWeaponManager.RemainingAmmo + "/" + _playerWeaponManager.MaxAmmo;
        else
            _ammoCount.text = "";
    }
}
