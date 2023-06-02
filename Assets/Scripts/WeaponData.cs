using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Custom/Weapon")]
public class WeaponData : ScriptableObject
{
    public string name;
    public Image icon;
    public GameObject prefab;
    public EStat temporaryEstat;
    public float value;
    //public Dictionary<EStat, float> statsAffected;
    //TODO find a way to use dictionnary OR stat class in unity editor
    
}
