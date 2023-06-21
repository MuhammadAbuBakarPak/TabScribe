using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{

	private const float defaultSelectionTime = 4.0f;

    // Current sentence index
    private int currentSentenceIndex = 0;
    private float startTime;
    private float endTime;
    private int T;
    private GameObject[] buttons;
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

    public TMP_InputField inputField;
	public TextMeshProUGUI textField;
	public Color selectedColor;
	public GameObject KeyA;
	public GameObject KeyB;
	public GameObject KeyC;
	public GameObject KeyD;
	public GameObject KeyE;
	public GameObject KeyF;
	public GameObject KeyG;
	public GameObject KeyH;
	public GameObject KeyI;
	public GameObject KeyJ;
	public GameObject KeyK;
	public GameObject KeyL;
	public GameObject KeyM;
	public GameObject KeyN;

	private void Start()
	{
		selectedButton = KeyA; 		// Initialize the starting selected button from sentences
		textField.text = sentences[currentSentenceIndex];

		// Get the original color of the button
		Renderer buttonRenderer = selectedButton.GetComponent<Renderer>();
		if (buttonRenderer != null)
		{
			originalColor = buttonRenderer.material.color;
		}
	}


	private void Awake()
	{
		buttons = new GameObject[14];
		buttons[0] = KeyA;
		buttons[1] = KeyB;
		buttons[2] = KeyC;
		buttons[3] = KeyD;
		buttons[4] = KeyE;
		buttons[5] = KeyF;
		buttons[6] = KeyG;
		buttons[7] = KeyH;
		buttons[8] = KeyI;
		buttons[9] = KeyJ;
		buttons[10] = KeyK;
		buttons[11] = KeyL;
		buttons[12] = KeyM;
		buttons[13] = KeyN;
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

		if (selectedButton == KeyA &&  Input.GetKeyDown(KeyCode.I))
		{
				WriteCharacterToInputField('a');
		}
		else if (selectedButton == KeyB && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('b');
		}
		else if (selectedButton == KeyC && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('c');
		}
		else if (selectedButton == KeyD && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('d');
		}
		else if (selectedButton == KeyE && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('e');
		}
		else if (selectedButton == KeyF && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('f');
		}
		else if (selectedButton == KeyG && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('g');
		}
		else if (selectedButton == KeyH && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('h');
		}
		else if (selectedButton == KeyI && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('i');
		}

		else if (selectedButton == KeyJ && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('j');
		}
		else if (selectedButton == KeyK && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('k');
		}
		else if (selectedButton == KeyL && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('l');
		}
		else if (selectedButton == KeyM && Input.GetKeyDown(KeyCode.I))
		{
			WriteCharacterToInputField('m');
		}
		else if (selectedButton == KeyN && Input.GetKeyDown(KeyCode.I))
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
		if (lastSelectionTime <= 0)
		{
			
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == KeyA)
		{
				// here we are using the "angle==0" to maintain the current selection. because when we start the application angle is exactly zero.
				//Such that if we make the "angle>=0" it will automatically change the selection from current selected button.
			if (angle > 0 && angle <= 90) 
			{
				selectedButton = KeyD;
				lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
			}
			else if (angle >= 91 &&  angle <= 155)
			{
				selectedButton = KeyC;
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle >= 156 &&  angle <= 215)
			{
				selectedButton = KeyB;
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle >= 216 &&  angle <= 310)
			{
				selectedButton = KeyF;
				lastSelectionTime = defaultSelectionTime;
			}
			else if (angle >= 311 &&  angle <= 360)
			{
				selectedButton = KeyE;
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
		if (lastSelectionTime <= 0) {
			
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyB)
			{
				if (angle > 0 && angle <= 40)
				{
					selectedButton = KeyA;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 41 && angle <= 90)
				{
					selectedButton = KeyC;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 91 && angle <= 140)
				{
					selectedButton = KeyJ;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 141 && angle <= 200)
				{
					selectedButton = KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 201 && angle <= 280) 
				{
					selectedButton = KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 281 && angle <= 360)
				{
					selectedButton = KeyF;
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
		if (lastSelectionTime <= 0)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == KeyC)
			{
				if (angle > 0 && angle <= 50) 
				{
					selectedButton = KeyD;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle >= 51 &&  angle <= 110)
				{
					selectedButton = KeyK;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 111 &&  angle <= 180)
				{
					selectedButton = KeyJ;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 181 &&  angle <= 270)
				{
					selectedButton = KeyB;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 271 &&  angle <= 360)
				{
					selectedButton = KeyA;
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
		if (lastSelectionTime <= 0)
		{

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

			if (selectedButton == KeyD)
			{
				if (angle > 0 && angle <= 65) 
				{
					selectedButton = KeyL;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle >= 66 &&  angle <= 140)
				{
					selectedButton = KeyK;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 141 &&  angle <= 200 )
				{
					selectedButton = KeyC;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 201  &&  angle <= 260)
				{
					selectedButton = KeyA;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 261 &&  angle <= 360)
				{
					selectedButton = KeyE;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyE)
			{
				if (angle > 0 && angle <= 40)
				{
					selectedButton = KeyM;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 41 && angle <= 80)
				{
					selectedButton = KeyL;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 81 && angle <= 120)
				{
					selectedButton = KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 121 && angle <= 180)
				{
					selectedButton = KeyA;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 181 && angle <= 270) 
				{
					selectedButton = KeyF;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 271 && angle <= 360)
				{
					selectedButton = KeyN;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyF)
			{
				if (angle > 0 && angle <= 50)
				{
					selectedButton = KeyE;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 51 && angle <= 125)
				{
					selectedButton = KeyA;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 126 && angle <= 180)
				{
					selectedButton = KeyB;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 181 && angle <= 230)
				{
					selectedButton = KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 231 && angle <= 310) 
				{
					selectedButton = KeyG;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 311 && angle <= 360)
				{
					selectedButton = KeyN;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyG)
			{
				if (angle > 0 && angle <= 50)
				{
					selectedButton = KeyN;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 51 && angle <= 130)
				{
					selectedButton = KeyF;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 131 && angle <= 270)
				{
					selectedButton = KeyH;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyH)
			{
				if (angle > 0 && angle <= 40)
				{
					selectedButton = KeyF;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 41 && angle <= 90)
				{
					selectedButton = KeyB;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 91 && angle <= 180)
				{
					selectedButton = KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 181 && angle <= 360)
				{
					selectedButton = KeyG;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyI)
			{
				if (angle > 0 && angle <= 45)
				{
					selectedButton = KeyB;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 46 && angle <= 90)
				{
					selectedButton = KeyJ;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 181 && angle <= 360)
				{
					selectedButton = KeyH;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyJ)
			{
				if (angle > 0 && angle <= 40)
				{
					selectedButton = KeyC;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 41 && angle <= 90)
				{
					selectedButton = KeyK;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 91 && angle <= 270)
				{
					selectedButton = KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 271 && angle <= 360)
				{
					selectedButton = KeyB;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyK)
			{
				if (angle >= 160 && angle <= 225)
				{
					selectedButton = KeyJ;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 226 && angle < 270)
				{
					selectedButton = KeyC;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 271 && angle <= 315)
				{
					selectedButton = KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 316 && angle <= 360)
				{
					selectedButton = KeyL;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyL)
			{
				if (angle >= 90 && angle <= 170)
				{
					selectedButton = KeyK;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 171 && angle <= 270)
				{
					selectedButton = KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 271 && angle <= 360)
				{
					selectedButton = KeyM;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyM)
			{
				if (angle > 0 && angle <= 150)
				{
					selectedButton = KeyL;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 151 && angle <= 210)
				{
					selectedButton = KeyE;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 211 && angle <= 360)
				{
					selectedButton = KeyN;
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
		if (lastSelectionTime <= 0) {

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			// Calculate the angle of the trackball input
			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;

			if (angle < 0)
				angle += 360;


			if (selectedButton == KeyN)
			{
				if (angle > 0 && angle <= 90)
				{
					selectedButton = KeyM;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle >= 91 && angle <= 145)
				{
					selectedButton = KeyE;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle >= 146 && angle <= 180)
				{
					selectedButton = KeyF;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle >= 181 && angle <= 360)
				{
					selectedButton = KeyG;
					lastSelectionTime = defaultSelectionTime;
				} 


			}
		}
	}




	}
	





