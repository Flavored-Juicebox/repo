using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Bullet")]

public class bullet_scriptable : ScriptableObject
{
    [Header("Name")]
    public string name_;

    [Space]

    [Header("Stats")]
    public float force, weight, damage;

    [Space]

    [Header("Objects")]
    public GameObject bullet_Object;
}
