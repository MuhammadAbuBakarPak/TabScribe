using UnityEngine;

public class MouseSelection : MonoBehaviour
{
	private GameObject selectedGameObject;

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		if (mouseX > 0)
		{
			// Move right
			SelectGameObjectOnRight();
			Vector3 cursorPosition = transform.position + new Vector3(mouseX, 0, 0);
			transform.position = cursorPosition;
			Debug.Log("Hello: " + gameObject.name);

		}
		else if (mouseX < 0)
		{
			// Move left
			SelectGameObjectOnLeft();
			Vector3 cursorPosition = transform.position + new Vector3(mouseX, 0, 0);
			transform.position = cursorPosition;
			Debug.Log("Hello: " + gameObject.name);
		}

		if (mouseY > 0)
		{
			// Move up
			SelectGameObjectAbove();
		}
		else if (mouseY < 0)
		{
			// Move down
			SelectGameObjectBelow();
		}
	}

	void SelectGameObjectOnRight()
	{
		GameObject rightObject = GetGameObjectInDirection(Vector3.right);
		if (rightObject != null)
		{
			SetSelectedGameObject(rightObject);
		}
	}

	void SelectGameObjectOnLeft()
	{
		GameObject leftObject = GetGameObjectInDirection(Vector3.left);
		if (leftObject != null)
		{
			SetSelectedGameObject(leftObject);
		}
	}

	void SelectGameObjectAbove()
	{
		GameObject aboveObject = GetGameObjectInDirection(Vector3.up);
		if (aboveObject != null)
		{
			SetSelectedGameObject(aboveObject);
		}
	}

	void SelectGameObjectBelow()
	{
		GameObject belowObject = GetGameObjectInDirection(Vector3.down);
		if (belowObject != null)
		{
			SetSelectedGameObject(belowObject);
		}
	}

	GameObject GetGameObjectInDirection(Vector3 direction)
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit))
		{
			return hit.collider.gameObject;
		}

		return null;
	}

	void SetSelectedGameObject(GameObject gameObject)
	{
		// Remove selection highlight from the previous selected game object, if any
		if (selectedGameObject != null)
		{
			// Implement your code to remove the selection highlight from the previous selected game object
		}

		// Set the new selected game object
		selectedGameObject = gameObject;

		// Add selection highlight to the newly selected game object
		// Implement your code to add a selection highlight to the selected game object
	}
}
