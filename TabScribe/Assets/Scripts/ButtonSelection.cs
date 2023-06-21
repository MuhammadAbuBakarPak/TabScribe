using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
	public enum Keyname
	{
		KeyA,
		KeyB,
		KeyC,
		KeyD,
		KeyE,
		KeyF,
		KeyG,
		KeyH,
		KeyI,
		KeyJ,
		KeyK,
		KeyL,
		KeyM,
		KeyN
	}


	public TMP_InputField inputField;
	public TextMeshProUGUI textField;
	public Color selectedColor;
	public GameObject[] buttons;


	private const float defaultSelectionTime = 4.0f;

	private Dictionary<Keyname, GameObject> keyMap; 
	private int currentSentenceIndex = 0;
	private float startTime;
	private float endTime;
	private int T;
	private GameObject selectedButton; // Current selected button
	private Color originalColor;
	private float lastSelectionTime = defaultSelectionTime;
	private string[] sentences = {
		"a bad fig jam",
		"ben can hang a bag",
		"ann had a mad camel",
		"ben can bake a cake",
		"hank feeding an eagle"
	};



	private void Start()
	{
		keyMap = new Dictionary<Keyname, GameObject>();
		// Assign GameObjects to Keyname values in the dictionary
		keyMap.Add(Keyname.KeyA, buttons[0]);
		keyMap.Add(Keyname.KeyB, buttons[1]);
		keyMap.Add(Keyname.KeyC, buttons[2]);
		keyMap.Add(Keyname.KeyD, buttons[3]);
		keyMap.Add(Keyname.KeyE, buttons[4]);
		keyMap.Add(Keyname.KeyF, buttons[5]);
		keyMap.Add(Keyname.KeyG, buttons[6]);
		keyMap.Add(Keyname.KeyH, buttons[7]);
		keyMap.Add(Keyname.KeyI, buttons[8]);
		keyMap.Add(Keyname.KeyJ, buttons[9]);
		keyMap.Add(Keyname.KeyK, buttons[10]);
		keyMap.Add(Keyname.KeyL, buttons[11]);
		keyMap.Add(Keyname.KeyM, buttons[12]);
		keyMap.Add(Keyname.KeyN, buttons[13]);


		selectedButton = keyMap[Keyname.KeyA]; 		
		textField.text = sentences[currentSentenceIndex];

		// Get the original color of the button
		Renderer buttonRenderer = selectedButton.GetComponent<Renderer>();
		if (buttonRenderer != null)
		{
			originalColor = buttonRenderer.material.color;
		}
	}
		

	private void Update()
	{
		// Selections from different buttons
		SelectionfromA();
		SelectionfromB();
		SelectionfromC();
		SelectionfromD();
		SelectionfromE();
		SelectionfromF();
		SelectionfromG();
		SelectionfromH();
		SelectionfromI();
		SelectionfromJ();
		SelectionfromK();
		SelectionfromL();
		SelectionfromM();
		SelectionfromN();
		// Change the color of the selected button
		ChangeButtonColor(selectedButton);
	}

	private void LateUpdate()
	{
		ProcessKeyPress();
	}





	//Button Color Changing Mechanism
	private void ChangeButtonColor(GameObject button)
	{
		// Reset color of previously selected button
		foreach (GameObject btn in buttons)
		{
			if (btn != button)
			{
				SetButtonColor(btn, originalColor);
			}
		}

		// Change color of the selected button
		SetButtonColor(button, selectedColor);
	}

	private void SetButtonColor(GameObject button, Color color)
	{
		MeshRenderer[] renderers = button.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer renderer in renderers)
		{
			renderer.material.color = color;
		}
	}

	private Color GetButtonColor(GameObject button)
	{
		MeshRenderer[] renderers = button.GetComponentsInChildren<MeshRenderer>();
		if (renderers.Length > 0)
		{
			return renderers[0].material.color;
		}
		return Color.white;
	}

	// Write character into input field
	private void WriteCharacterToInputField(char character)
	{
		if (inputField != null)
		{
			inputField.text += character.ToString();
			T = inputField.text.Length; // Update the length of the transcribed string
		}
	}




	// ProcessKeyPress method checks the selected button and the pressed key to determine which character to write using the WriteCharacterToInputField method.
	private void ProcessKeyPress()
	{
		// Check if the user presses the first character of a sentence
		if (Input.anyKeyDown && T == 0)
		{
			// Start the timer for text entry
			startTime = Time.time;
		}

		if (selectedButton == keyMap[Keyname.KeyA] &&  Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('a');
		}
		else if (selectedButton == keyMap[Keyname.KeyB] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('b');
		}
		else if (selectedButton == keyMap[Keyname.KeyC] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('c');
		}
		else if (selectedButton == keyMap[Keyname.KeyD] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('d');
		}
		else if (selectedButton == keyMap[Keyname.KeyE] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('e');
		}
		else if (selectedButton == keyMap[Keyname.KeyF] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('f');
		}
		else if (selectedButton == keyMap[Keyname.KeyG] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('g');
		}
		else if (selectedButton == keyMap[Keyname.KeyH] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('h');
		}
		else if (selectedButton == keyMap[Keyname.KeyI] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('i');
		}

		else if (selectedButton == keyMap[Keyname.KeyJ] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('j');
		}
		else if (selectedButton == keyMap[Keyname.KeyK] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('k');
		}
		else if (selectedButton == keyMap[Keyname.KeyL] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('l');
		}
		else if (selectedButton == keyMap[Keyname.KeyM] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('m');
		}
		else if (selectedButton == keyMap[Keyname.KeyN] && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('n');
		}

		// Handle backspace key
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			if (inputField != null && inputField.text.Length > 0)
			{
				inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
			}
		}

		// Handle space key
		if (Input.GetKeyDown(KeyCode.Space))
		{
			WriteCharacterToInputField(' ');
		}

		// Handle the "Enter" key press
		if (Input.GetKeyDown(KeyCode.Return))
		{
			EnterKeyFunctionality();

			//WPM Calculation
			// Stop the timer for text entry
			endTime = Time.time;
			// Calculate the text entry speed for the current sentence
			float S = endTime - startTime;
			float wordsPerMinute = (T - 1) / S * 60f * 0.2f;
			Debug.LogFormat("Text Entry Speed (Sentence {0}): {1} WPM", currentSentenceIndex, wordsPerMinute);
		}

	}

	//Perform Enter Key Functionality
	private void EnterKeyFunctionality()
	{
		if (textField != null)
		{

			currentSentenceIndex++;
			// Update the text field with the next sentence
			if (currentSentenceIndex  < sentences.Length)
			{
				textField.text = sentences[currentSentenceIndex];

				// Clear the input field
				inputField.text = string.Empty;
			}
			else
			{
				// Reset sentence index and display a message
				currentSentenceIndex = 0;
				textField.text = "Done";
			}
		}
	}







	// Selection for neighbours of a
	public void SelectionfromA()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == keyMap[Keyname.KeyA])
			{
				// here we are using the "angle==0" to maintain the current selection. because when we start the application angle is exactly zero.
				//Such that if we make the "angle>=0" it will automatically change the selection from current selected button.
				if (angle > 0.0f && angle <= 90.0f) 
				{
					selectedButton = keyMap[Keyname.KeyD];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 90.0f &&  angle <= 155.0f)
				{
					selectedButton = keyMap[Keyname.KeyC];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 155.0f &&  angle <= 215.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 215.0f &&  angle <= 310.0f)
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 310.0f &&  angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyE];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}


	// Selection for neighbours of b
	public void SelectionfromB()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyB])
			{
				if (angle > 0.0f && angle <= 40.0f)
				{
					selectedButton = keyMap[Keyname.KeyA];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40.0f && angle <= 90.0f)
				{
					selectedButton = keyMap[Keyname.KeyC];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90.0f && angle <= 140.0f)
				{
					selectedButton = keyMap[Keyname.KeyJ];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 140.0f && angle <= 200.0f)
				{
					selectedButton = keyMap[Keyname.KeyI];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 200.0f && angle <= 280.0f) 
				{
					selectedButton = keyMap[Keyname.KeyH];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 280.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of c
	public void SelectionfromC()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == keyMap[Keyname.KeyC])
			{
				if (angle > 0.0f && angle <= 50.0f) 
				{
					selectedButton = keyMap[Keyname.KeyD];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 50.0f &&  angle <= 110.0f)
				{
					selectedButton = keyMap[Keyname.KeyK];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 110.0f &&  angle <= 180)
				{
					selectedButton = keyMap[Keyname.KeyJ];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180.0f &&  angle <= 270.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 270.0f &&  angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyA];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of d
	public void SelectionfromD()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == keyMap[Keyname.KeyD])
			{
				if (angle > 0.0f && angle <= 65.0f) 
				{
					selectedButton = keyMap[Keyname.KeyL];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 65.0f &&  angle <= 140.0f)
				{
					selectedButton = keyMap[Keyname.KeyK];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 140.0f &&  angle <= 200.0f )
				{
					selectedButton = keyMap[Keyname.KeyC];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 200.0f  &&  angle <= 260.0f)
				{
					selectedButton = keyMap[Keyname.KeyA];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 260.0f &&  angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyE];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of E
	public void SelectionfromE()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyE])
			{
				if (angle > 0.0f && angle <= 40.0f)
				{
					selectedButton = keyMap[Keyname.KeyM];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40.0f && angle <= 80.0f)
				{
					selectedButton = keyMap[Keyname.KeyL];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 80.0f && angle <= 120.0f)
				{
					selectedButton = keyMap[Keyname.KeyD];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 120.0f && angle <= 180.0f)
				{
					selectedButton = keyMap[Keyname.KeyA];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 270.0f) 
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyN];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}




	// Selection for neighbours of F
	public void SelectionfromF()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyF])
			{
				if (angle > 0.0f && angle <= 50.0f)
				{
					selectedButton = keyMap[Keyname.KeyE];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 50.0f && angle <= 125.0f)
				{
					selectedButton = keyMap[Keyname.KeyA];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 125.0f && angle <= 180.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 230.0f)
				{
					selectedButton = keyMap[Keyname.KeyH];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 230.0f && angle <= 310.0f) 
				{
					selectedButton = keyMap[Keyname.KeyG];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 310.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyN];
					lastSelectionTime = defaultSelectionTime;
				}
			}
		}
	}



	// Selection for neighbours of G
	public void SelectionfromG()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyG])
			{
				if (angle > 0.0f && angle <= 50.0f)
				{
					selectedButton = keyMap[Keyname.KeyN];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 50.0f && angle <= 130.0f)
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 130.0f && angle <= 270.0f)
				{
					selectedButton = keyMap[Keyname.KeyH];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}




	// Selection for neighbours of H
	public void SelectionfromH()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyH])
			{
				if (angle > 0.0f && angle <= 40.0f)
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40.0f && angle <= 90.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90.0f && angle <= 180.0f)
				{
					selectedButton = keyMap[Keyname.KeyI];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyG];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}




	// Selection for neighbours of I
	public void SelectionfromI()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyI])
			{
				if (angle > 0.0f && angle <= 45.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 45.0f && angle <= 90.0f)
				{
					selectedButton = keyMap[Keyname.KeyJ];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyH];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}


	// Selection for neighbours of J
	public void SelectionfromJ()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyJ])
			{
				if (angle > 0.0f && angle <= 40.0f)
				{
					selectedButton = keyMap[Keyname.KeyC];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40.0f && angle <= 90.0f)
				{
					selectedButton = keyMap[Keyname.KeyK];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90.0f && angle <= 270.0f)
				{
					selectedButton = keyMap[Keyname.KeyI];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyB];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}



	// Selection for neighbours of K
	public void SelectionfromK()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyK])
			{
				if (angle > 160.0f && angle <= 225.0f)
				{
					selectedButton = keyMap[Keyname.KeyJ];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 225.0f && angle < 270.0f)
				{
					selectedButton = keyMap[Keyname.KeyC];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270.0f && angle <= 315.0f)
				{
					selectedButton = keyMap[Keyname.KeyD];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 315.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyL];
					lastSelectionTime = defaultSelectionTime;
				} 

			}
		}
	}



	// Selection for neighbours of L
	public void SelectionfromL()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyL])
			{
				if (angle > 90.0f && angle <= 170.0f)
				{
					selectedButton = keyMap[Keyname.KeyK];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 170.0f && angle <= 270.0f)
				{
					selectedButton = keyMap[Keyname.KeyD];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyM];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}





	// Selection for neighbours of M
	public void SelectionfromM()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyM])
			{
				if (angle > 0.0f && angle <= 150.0f)
				{
					selectedButton = keyMap[Keyname.KeyL];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 150.0f && angle <= 210.0f)
				{
					selectedButton = keyMap[Keyname.KeyE];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 210.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyN];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}


	// Selection for neighbours of N
	public void SelectionfromN()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		// Check if enough time has passed since the last selection change
		if (lastSelectionTime <= 0.0f) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == keyMap[Keyname.KeyN])
			{
				if (angle > 0.0f && angle <= 90.0f)
				{
					selectedButton = keyMap[Keyname.KeyM];
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 90.0f && angle <= 145.0f)
				{
					selectedButton = keyMap[Keyname.KeyE];
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 145.0f && angle <= 180.0f)
				{
					selectedButton = keyMap[Keyname.KeyF];
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180.0f && angle <= 360.0f)
				{
					selectedButton = keyMap[Keyname.KeyG];
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}




}






