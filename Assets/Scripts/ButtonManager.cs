using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] AudioSource fanSound;
    [SerializeField] AudioSource switchsound;
    [SerializeField] WindForce windForce;


    [SerializeField] GameObject TurnOnButton;
    [SerializeField] GameObject TurnOffButton;

    [SerializeField] GameObject PushRightButton;
    [SerializeField] GameObject PushLeftButton;

    public void TurnOff() {
        switchsound.Play();
        fanSound.Stop();
        TurnOnButton.transform.position =  new Vector3 (-0.75f, -0.75f, -2.175f);
        TurnOffButton.transform.position = new Vector3 (0.75f, -0.75f, -2f);
        windForce._isActive = false;
    }



    public void TurnOn() {
        switchsound.Play();
        fanSound.Play();
        TurnOnButton.transform.position = new Vector3(-0.75f, -0.75f, -2f);
        TurnOffButton.transform.position = new Vector3(0.75f, -0.75f, -2.175f);
        windForce._isActive = true;
    }

    public void PushRight()
    {
        switchsound.Play();
        windForce.pushRight = true;

        PushRightButton.transform.position = new Vector3(-12.25f, -0.75f, -2f);
        PushLeftButton.transform.position = new Vector3(12.25f, -0.75f, -2.175f);


    }
    public void PushLeft()
    {
        switchsound.Play();
        windForce.pushRight = false;

        PushRightButton.transform.position = new Vector3(-12.25f, -0.75f, -2.175f);
        PushLeftButton.transform.position = new Vector3(12.25f, -0.75f, -2f);
    }

    [SerializeField] LayerMask mask;
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
                if (hitObject.CompareTag("On"))
                {
                   TurnOn();
                }
                if (hitObject.CompareTag("Off"))
                {
                    TurnOff();
                }
                if (hitObject.CompareTag("right"))
                {
                    PushRight();
                }
                if (hitObject.CompareTag("left"))
                {
                    PushLeft();
                }
            }
        }
    }
}
