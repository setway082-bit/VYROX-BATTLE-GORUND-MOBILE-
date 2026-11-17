using UnityEngine;
using System.Collections.Generic;

[System.Serializable] public class InventoryEntry { public ItemData item; public int amount; }
public class Inventory : MonoBehaviour
{
    public int maxSlots = 20; public List<InventoryEntry> entries = new List<InventoryEntry>();
    public bool Add(ItemData item, int amount = 1)
    {
        if (!item || amount <= 0) return false;
        InventoryEntry existing = entries.Find(e => e.item == item && e.amount < item.stackLimit);
        if (existing != null) { int add = Mathf.Min(amount, item.stackLimit - existing.amount); existing.amount += add; amount -= add; }
        while (amount > 0 && entries.Count < maxSlots) { int add = Mathf.Min(amount, Mathf.Max(1, item.stackLimit)); entries.Add(new InventoryEntry { item = item, amount = add }); amount -= add; }
        return amount == 0;
    }
}
