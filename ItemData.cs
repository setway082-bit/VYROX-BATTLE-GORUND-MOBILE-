using UnityEngine;

[CreateAssetMenu(menuName = "Elite Battleground/Item")]
public class ItemData : ScriptableObject
{
    public string itemId; public string displayName; public ItemType type; public int stackLimit = 1;
    public enum ItemType { Ammo, Medkit, Weapon, Armor, Cosmetic }
}
