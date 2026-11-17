using UnityEngine;

public class SafeZoneDamage : MonoBehaviour
{
    public SafeZoneController zone; public PlayerHealth health; public float damagePerSecond = 3f;
    void Update() { if (zone && health && !zone.IsInside(transform.position)) health.TakeDamage(damagePerSecond * Time.deltaTime); }
}
