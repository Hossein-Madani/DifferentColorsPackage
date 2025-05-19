using UnityEngine;

public class BrokenCubes : MonoBehaviour
{
    void Start()
    {
        Destroy(transform.Find("Explosive").gameObject, 1);
    }

}
