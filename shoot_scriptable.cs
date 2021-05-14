using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Shootable")]
public class shoot_scriptable : ScriptableObject
{
    [Header("Name")]
    public string name_;

    [Space]

    [Header("Stats")]
    public float maximum_ammunition, maximum_range, fire_rate, fire_amount, recoil_drag, recoil_angular;
    public Vector2 spread_bounds;
}
