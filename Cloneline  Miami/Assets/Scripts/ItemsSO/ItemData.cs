using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        silencedPistol = 1,
        M16 = 2,
        Axe = 3
    }

    [Header("Weapon stats")]
    [SerializeField] private ItemType _itemType;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private AudioClip _attackSound;
    [Header("Colliders values")]
    [SerializeField] private Vector2 _colliderSize;
    [SerializeField] private Vector2 _colliderOffset;
    [SerializeField] private Vector2 _attackColliderSize;
    [SerializeField] private Vector2 _attackColliderOffset;
    [SerializeField] private Vector2 _attackColliderPosition;

    public readonly List<Vector2> CollidersValues = new List<Vector2>();

    public void AddColliderValuesToList()
    {
        CollidersValues.Add(_colliderSize);
        CollidersValues.Add(_colliderOffset);
        CollidersValues.Add(_attackColliderSize);
        CollidersValues.Add(_attackColliderOffset);
        CollidersValues.Add(_attackColliderPosition);
    }

    public int Type => (int)_itemType;
    public string Name => _name;
    public Sprite WeaponSprite => _sprite;
    public float AttackSpeed => _attackSpeed;
    public AudioClip AttackSound => _attackSound;

}
