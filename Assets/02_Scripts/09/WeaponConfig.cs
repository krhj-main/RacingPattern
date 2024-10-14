using System.Collections;
using System.Collections.Generic;
using Chapter.Decorator;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponConfig", menuName ="Weapon/Config", order = 1)]
public class WeaponConfig : ScriptableObject,IWeapon
{
    [Range(0,60)]
    [Tooltip("Rate of firing per second")]
    [SerializeField] private float rate;

    [Range(0,50)]
    [Tooltip("Weapon Range")]
    [SerializeField] private float range;

    [Range(0,100)]
    [Tooltip("Weapon Strength")]
    [SerializeField] private float strength;

    [Range(0,5)]
    [Tooltip("Cooldown duration")]
    [SerializeField] private float cooldown;

    public string weaponName;
    public GameObject weaponPrefab;
    public string weaponDescription;


    public float Rate => rate;

    public float Range => range;

    public float Strength => strength;

    public float Cooldown => cooldown;
}
