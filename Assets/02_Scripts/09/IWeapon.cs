using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Chapter.Decorator
{
    public interface IWeapon
    {
        float Rate {get;}
        float Range {get;}
        float Strength {get;}
        float Cooldown {get;}
    }
}
