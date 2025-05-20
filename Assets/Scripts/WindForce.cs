using UnityEngine;

public class WindForce : MonoBehaviour
{
    public float windStrength = 10f;
    public bool _isActive = true;
    public bool pushRight = true; // true = +X (right), false = -X (left)

    private void OnTriggerStay(Collider other)
    {
        if (!_isActive) return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 windDirection = pushRight ? Vector3.right : Vector3.left;
            rb.AddForce(windDirection * windStrength, ForceMode.Force);
        }
    }
}
