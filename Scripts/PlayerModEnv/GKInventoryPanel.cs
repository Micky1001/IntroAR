using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GKInventoryPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject defSphere;
    private RectTransform panelRectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 defaultPosition;

    private void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPosition = panelRectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Recognized Canvas click");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, null, out position);
        //if we want to follow the mouse we do this:
        transform.position = canvas.transform.TransformPoint(position);
        Debug.Log("cursor position:" + eventData.position);
        Debug.Log("panel position:" + position);

        
    }

    public void OnPointerUp(PointerEventData eventData) {
        // Spawn a sphere at the pointer position
        SpawnSphereAtPosition(transform.position);

        Debug.Log("Drag off");
        panelRectTransform.anchoredPosition = defaultPosition;
        
        Debug.Log(transform.position);
        canvasGroup.blocksRaycasts = true;
    }


    private void SpawnSphereAtPosition(Vector2 position)
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found in the scene!");
            return;
        }
        // Raycast to find the position in 3D space
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Activate");
            // Instantiate the sphere at the hit position
            GameObject sphere = Instantiate(defSphere, hit.point, Quaternion.identity);
            // Optionally, you can parent the sphere to a specific object or transform
            //sphere.transform.parent = transform.parent; // Change this line according to your needs
        }
    }
}
