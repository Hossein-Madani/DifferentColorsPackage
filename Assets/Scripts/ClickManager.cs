using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] AudioSource breaksound;
    void Update()
    {
        // Check if left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast to detect objects
            if (Physics.Raycast(ray, out RaycastHit hit, 200, mask))
            {
                GameObject hitObject = hit.collider.gameObject;

                // Check if the object has the tag "Damageable"
                if (hitObject.CompareTag("Damageable"))
                {
                    breaksound.Play();
                    // Try to find a component with OnDamage method
                    var cube = hitObject.GetComponent<Cube>();
                    if (cube != null)
                    {
                        cube.OnDamage(hitObject);
                    }
                }
            }
        }
    }
}
