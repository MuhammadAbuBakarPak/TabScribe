using UnityEngine;

public class PolygonSelector : MonoBehaviour
{
	public LayerMask polygonLayer;
	public float raycastDistance = 100f;

	public GameObject currentSelection;

	public Camera cam;

	private void Update()
	{
		// Get the mouse movement
		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		if (mouseMovement.x < 0f)
		{
			// Move the selection to the left
			SelectAdjacentPolygon(Vector3.left);
		}
		else if (mouseMovement.x > 0f)
		{
			// Move the selection to the right
			SelectAdjacentPolygon(Vector3.right);
		}

		if (mouseMovement.y > 0f)
		{
			// Move the selection upward
			SelectAdjacentPolygon(Vector3.up);
		}
		else if (mouseMovement.y < 0f)
		{
			// Move the selection downward
			SelectAdjacentPolygon(Vector3.down);
		}
	}

	private void SelectAdjacentPolygon(Vector3 direction)
	{
		if (currentSelection == null)
		{
			// Find the nearest polygon to the mouse position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, raycastDistance, polygonLayer))
			{
				currentSelection = hit.collider.gameObject;
				Renderer renderer = currentSelection.GetComponent<Renderer>();
				if (renderer != null)
				{
					renderer.material.color = Color.red;
				}
			}
		}
		else
		{
			// Cast a ray from the current selection in the given direction
			RaycastHit hit;
			if (Physics.Raycast(currentSelection.transform.position, direction, out hit, raycastDistance, polygonLayer))
			{
				// Deselect the current polygon
				Renderer renderer = currentSelection.GetComponent<Renderer>();
				if (renderer != null)
				{
					renderer.material.color = Color.white;
				}

				// Select the new polygon
				currentSelection = hit.collider.gameObject;
				Renderer newRenderer = currentSelection.GetComponent<Renderer>();
				if (newRenderer != null)
				{
					newRenderer.material.color = Color.red;
				}
			}
		}
	}
}
