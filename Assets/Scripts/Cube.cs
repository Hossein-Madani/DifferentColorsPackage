using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject _brokenCubes;

    public void OnDamage(GameObject parent)
    {
        // Instantiate broken cube
        GameObject brokenInstance = Instantiate(_brokenCubes);
        brokenInstance.transform.localPosition = transform.position;
       
        // Find "Objects" child inside the instantiated broken cubes
        Transform objectsRoot = brokenInstance.transform.Find("Objects");
        if (objectsRoot == null)
        {
            Debug.LogWarning("No 'Objects' child found in broken cubes prefab.");
            return;
        }

        // Get the material from the parent
        Renderer parentRenderer = parent.GetComponent<Renderer>();
        if (parentRenderer == null)
        {
            Debug.LogWarning("Parent has no Renderer component.");
            return;
        }

        Material originalMaterial = parentRenderer.sharedMaterial;

        // Loop through each child of "Objects" and assign a new material copy
        foreach (Transform child in objectsRoot)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                // Create a new material instance (copy)
                Material newMat = new Material(originalMaterial);
                childRenderer.material = newMat;
            }
        }

        // Optionally destroy the prefab reference if needed (but not the instance)
        // Destroy(_brokenCubes); // Don't destroy the prefab reference!
        Destroy(gameObject);
    }
}
