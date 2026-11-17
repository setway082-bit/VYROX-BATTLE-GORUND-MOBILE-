using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public Camera aimCamera; public Transform muzzle; public LayerMask hitMask = ~0;
    public float damage = 25f, range = 180f, roundsPerMinute = 600f, reloadSeconds = 1.8f;
    public int magazineSize = 30, reserveAmmo = 120; public int AmmoInMagazine { get; private set; }
    bool reloading; float nextShot;
    void Awake() { AmmoInMagazine = magazineSize; }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(Reload());
        if (Input.GetMouseButton(0) && Time.time >= nextShot && !reloading) Fire();
    }
    void Fire()
    {
        if (AmmoInMagazine <= 0) { if (reserveAmmo > 0) StartCoroutine(Reload()); return; }
        nextShot = Time.time + 60f / Mathf.Max(1, roundsPerMinute); AmmoInMagazine--;
        if (!aimCamera) return;
        Ray ray = aimCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, range, hitMask, QueryTriggerInteraction.Ignore))
        {
            PlayerHealth health = hit.collider.GetComponentInParent<PlayerHealth>();
            if (health) health.TakeDamage(damage);
        }
    }
    IEnumerator Reload()
    {
        if (reloading || AmmoInMagazine == magazineSize || reserveAmmo <= 0) yield break;
        reloading = true; yield return new WaitForSeconds(reloadSeconds);
        int needed = magazineSize - AmmoInMagazine, loaded = Mathf.Min(needed, reserveAmmo);
        AmmoInMagazine += loaded; reserveAmmo -= loaded; reloading = false;
    }
}
