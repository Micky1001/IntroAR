using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GKInventoryPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject defObject;		// The GameObject you want to Instantiate upon release of the panel. This game object should have an associated script/properties already defined to perform the desired functionatliy after release.
    private RectTransform panelRectTransform;	// A transformation representing panel position
    private Canvas canvas;			// Parent canvas
    private CanvasGroup canvasGroup;		// Current Canvas Group
    private Vector2 defaultPosition;		// Initial position of the inventory panel, used to reset panel position after release

    private void Start()
    {
	// Initialize Components of the panel, as well as default position
        panelRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPosition = panelRectTransform.anchoredPosition;
    }

    // Detect a touch screen initial touch.
    public void OnPointerDown(PointerEventData eventData)
    {
	// Optional: Ensure that the current CanvasGroup that the panel is in does not prevent raycasts from hitting the panel itself
	// Not necessary if CanvasGroup is not being used for anything else.
        canvasGroup.blocksRaycasts = false;
	// Print Log information for debugging
        Debug.Log("Recognized Canvas click");
    }

    // Detect continuous movement along the touch screen
    public void OnDrag(PointerEventData eventData)
    {
	// Generate an approximation of the position of the cursor in screen coordinates in Canvas coordinates
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, null, out position);

	// Set the location of the panel's transform to the location of the cursor (in Canvas coordinates)
        transform.position = canvas.transform.TransformPoint(position);
        
    }

    // Upon release from the touch screen, instantiate the defObject object at the current touch location
    public void OnPointerUp(PointerEventData eventData) {
        // Spawn a defObject at the pointer position
	// Note that transform.position is continuously updated onDrag and thus is already pointing to the correct cursor location
        SpawnObjectAtPosition(transform.position);

	// Print Log information for debugging
        Debug.Log("Drag off");

	// Reset inventory panel position to the default position
        panelRectTransform.anchoredPosition = defaultPosition;
        
	// Optional: Re-enable the current canvasGroup's ability to block Raycasts
        canvasGroup.blocksRaycasts = true;
    }

    // Instantiate the specified default Object (defObject) at a given position
    private void SpawnObjectAtPosition(Vector2 position)
    {
        // Raycast to find the position in 3D space
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

	// Validate that the ray will hit a specific plane
	// Note: this is OPTIONAL. our demo specifically only allows for spawning of objects on a specific plane/marker
        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the object at the hit position
            GameObject obj = Instantiate(defObject, hit.point, Quaternion.identity);
            // Optionally, you can parent the sphere to a specific object or transform. This will be useful for further combinations with dynamic Visualization
            //sphere.transform.parent = transform.parent;
        }
    }
}
