public class ShootingSlider : MonoBehaviour
{
    // Force slider values
    public float minForce = 0.0f;
    public float maxForce = 10.0f;
    public float oscillationForce = 1.0f;

    // Position slider values
    public float minYPos = -0.4f;
    public float maxYPos = 0.4f;
    public float oscillationPos = 0.05f;

    // Slider objects
    public Slider slider_Force;
    public Slider slider_Position;

    // Reference to the GameObject you want to apply force to.
    public GameObject objectToApplyForce;

    private float currentForce;
    private bool isIncreasing_Force;
    private float scaleFactor_Force = 10;
    private bool isStopped_Force = false;

    private float currentValue; // Represents value along the Y-axis.
    private Vector3 posVec;
    private bool isIncreasing_Pos;
    private float scaleFactor_Pos = 10;
    private bool isStopped_Pos = false;

    private Rigidbody objectRigidbody;

    public GameObject winTextObject;

    private void Start()
    {
        currentForce = minForce;
        isIncreasing_Force = true;
        currentValue = minYPos; // Start at the minimum Y position.
        isIncreasing_Pos = true;

        // Get the Rigidbody component of the object.
        objectRigidbody = objectToApplyForce.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Toggle force oscillation on/off with the Space key.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStopped_Force = !isStopped_Force;
        }

        if (!isStopped_Force)
        {
            // Calculate force oscillation based on time and direction.
            float deltaForce = oscillationForce * Time.deltaTime;
            if (isIncreasing_Force)
            {
                currentForce += deltaForce;
                if (currentForce >= maxForce)
                {
                    currentForce = maxForce;
                    isIncreasing_Force = false;
                }
            }
            else
            {
                currentForce -= deltaForce;
                if (currentForce <= minForce)
                {
                    currentForce = minForce;
                    isIncreasing_Force = true;
                }
            }
            // Update the visual representation of the force on the slider.
            UpdateForceBarVisual(currentForce);
        }

        // Toggle position oscillation on/off with the Enter key.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStopped_Pos = !isStopped_Pos;
        }

        if (!isStopped_Pos)
        {
            // Calculate position oscillation based on time and direction.
            float deltaPos = oscillationPos * Time.deltaTime;
            if (isIncreasing_Pos)
            {
                currentValue += deltaPos;
                if (currentValue >= maxYPos)
                {
                    currentValue = maxYPos;
                    isIncreasing_Pos = false;
                }
            }
            else
            {
                currentValue -= deltaPos;
                if (currentValue <= minYPos)
                {
                    currentValue = minYPos;
                    isIncreasing_Pos = true;
                }
            }

            // Update the visual representation of the position on the slider.
            UpdatePositionBarVisual(currentValue);
        }

        // Apply force to the object when the 'A' key is pressed.
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Calculate the force vector.
            posVec = new Vector3(0.0f, 0.0f, currentForce);
            // Apply the force to the object's Rigidbody.
            objectRigidbody.AddForce(posVec);
        }

        // Reset the object's position to zero when the 'D' key is pressed.
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Reset the position of the objectToApplyForce.
            Transform objectTransform = objectToApplyForce.transform;
            objectTransform.position = Vector3.zero;
        }
    }

    // Update the visual representation of the force on the slider.
    private void UpdateForceBarVisual(float forceValue)
    {
        if (slider_Force != null)
        {
            // Set the slider's value based on the force value.
            slider_Force.value = forceValue / scaleFactor_Force;
        }
    }

    // Update the visual representation of the position on the slider.
    private void UpdatePositionBarVisual(float yPosValue)
    {
        if (slider_Position != null)
        {
            // Set the slider's value based on the Y position value.
            slider_Position.value = yPosValue;
        }
    }

    // Triggered when the object collides with a collectable object.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            // Deactivate the collectable object and display the win text.
            other.gameObject.SetActive(false);
            winTextObject.SetActive(true);
            // Pause the game by setting the time scale to zero.
            Time.timeScale = 0;
        }
    }
}