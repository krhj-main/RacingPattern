using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PowerUp", fileName ="PowerUp", order = 0)]
public class PowerUp : ScriptableObject
{
    public string powerName;
    public int powerAmount;
}
