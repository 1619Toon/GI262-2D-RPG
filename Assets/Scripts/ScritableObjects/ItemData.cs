using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item Data", order = 50)] //เก็บของ
public class ItemData : ScriptableObject
{
    public string itemName = "itemName";
    public Sprite icon = null;
}
