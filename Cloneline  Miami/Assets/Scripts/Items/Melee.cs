using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private MeleeWeaponData _meleeWeaponData;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private AudioClip _attackSound;

    private SpriteRenderer _spriteRenderer;
    
    public AudioClip AttackSound => _attackSound;

    public override void SetWeaponData(MeleeWeaponData meleeData)
    {
        base.SetWeaponData(meleeData);
        meleeData = _meleeWeaponData;
        _sprite = meleeData.WeaponSprite;
        _attackSpeed = meleeData.AttackSpeed;
        _attackSound = meleeData.AttackSound;
    }

    private void Awake()
    {
        SetWeaponData(_meleeWeaponData);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite;
    }
}
