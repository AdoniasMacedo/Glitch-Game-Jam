using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blessing", menuName = "Blessing")]
public class Blessing : ScriptableObject
{
    public new string name;
    public string description;
    public List<Consequence> effects;
}
