using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    public Vector3 center; public float startRadius = 500f, endRadius = 20f;
    public float shrinkDuration = 900f, waitBeforeShrink = 60f;
    public float CurrentRadius { get; private set; }
    float elapsed;
    void Start() { CurrentRadius = startRadius; }
    void Update()
    {
        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01((elapsed - waitBeforeShrink) / Mathf.Max(1, shrinkDuration));
        CurrentRadius = Mathf.Lerp(startRadius, endRadius, t);
    }
    public bool IsInside(Vector3 position) { Vector2 a = new Vector2(position.x, position.z), b = new Vector2(center.x, center.z); return Vector2.Distance(a, b) <= CurrentRadius; }
    void OnDrawGizmosSelected() { Gizmos.color = Color.cyan; Gizmos.DrawWireSphere(center, Application.isPlaying ? CurrentRadius : startRadius); }
}
