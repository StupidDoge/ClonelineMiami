using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private enum Triggers
    {
        punch,
        shootSilencedPistol,
        shootM16,
        attackAxe
    }

    private Animator _animator;
    private PlayerWeaponManager _playerWeaponManager;
    private PlayerAttackController _playerAttackController;

    private bool _canPlayAnimation = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerWeaponManager = GetComponentInParent<PlayerWeaponManager>();
        _playerAttackController = GetComponentInParent<PlayerAttackController>();
    }

    void Update()
    {
        if ((_playerWeaponManager.RemainingAmmo > 0 || _playerWeaponManager.IsMelee) && Input.GetMouseButton(0) && _canPlayAnimation) //
            PlayAttackAnimation();
        if (_playerWeaponManager.RemainingAmmo <= 0 || !Input.GetMouseButton(0)) // current m16
            _animator.SetBool("blockAnimation", false);
    }

    public void SetAnimation(int id)
    {
        _animator.SetInteger("weaponId", id);
    }

    private void PlayAttackAnimation()
    {
        StartCoroutine(SetAttackAnimation(_playerWeaponManager.AttackDelay, _playerWeaponManager.PlayerCurrentWeapon.ToString() + "Attack"));

        if (_playerWeaponManager.PlayerCurrentWeapon == PlayerWeaponManager.CurrentWeapon.M16)
            _animator.SetBool("blockAnimation", true);
    }

    IEnumerator SetAttackAnimation(float delay, string trigger)
    {
        _canPlayAnimation = false;
        _animator.SetTrigger(trigger.ToString());
        yield return new WaitForSeconds(delay);
        _canPlayAnimation = true;
    }

    private void ActivateMeleeTrigger()
    {
        StartCoroutine(_playerAttackController.MeleeAttack(_playerWeaponManager.AttackDelay));
    }
}
