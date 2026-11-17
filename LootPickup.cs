using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LootPickup : MonoBehaviour
{
    public ItemData item; public int amount = 1;
    void Reset() { GetComponent<Collider>().isTrigger = true; }
    void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponentInParent<Inventory>();
        if (inventory && inventory.Add(item, amount)) Destroy(gameObject);
    }
}
