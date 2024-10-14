using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chapter.Decorator;
using System.Reflection.Emit;

namespace Chapter.Decorator
{
    public class BikeWeapon : MonoBehaviour
    {
        public WeaponConfig weaponConfig;
        public WeaponAttachment mainAttachment;
        public WeaponAttachment secondaryAttachment;

        private bool _isFiring;
        private IWeapon _weapon;
        private bool _isDecorated;

        void Start()
        {
            _weapon = new Weapon(weaponConfig);
        }

        void OnGUI()
        {
            GUI.color = Color.green;

            GUI.Label(new Rect(5,50,150,100), "Range : "+_weapon.Range);
            GUI.Label(new Rect(5,110,150,100),"Firing Rate : "+ _weapon.Rate);
            GUI.Label(new Rect(5,130,150,100),"Weapon Firing : " + _weapon.Strength);
        }

        public void ToggleFire()
        {
            _isFiring = !_isFiring;

            if(_isFiring)
            {
                StartCoroutine(FireWeapon());
            }
        }

        IEnumerator FireWeapon()
        {
            float firingRate = 1.0f / _weapon.Rate;

            while(_isFiring)
            {
                yield return new WaitForSeconds(firingRate);
                Debug.Log("Fire");
            }
        }

        public void Reset()
        {
            _weapon = new Weapon(weaponConfig);
            _isDecorated = !_isDecorated;
        }

        public void Decorate()
        {
            if(mainAttachment && !secondaryAttachment)
            {
                _weapon = new WeaponDecorator(_weapon, mainAttachment);
            }

            if(mainAttachment && secondaryAttachment)
            {
                _weapon = new WeaponDecorator(new WeaponDecorator(_weapon,mainAttachment), secondaryAttachment);
            }

            _isDecorated = !_isDecorated;
        }
    }
}
