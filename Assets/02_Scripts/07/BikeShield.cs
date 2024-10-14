using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pattern.Visitor;

namespace Pattern.Visitor
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health = 50.0f;

        public float Damage(float damage)
        {
            health -= damage;
            return health;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        void OnGUI()
        {
            
        }
    }
}
