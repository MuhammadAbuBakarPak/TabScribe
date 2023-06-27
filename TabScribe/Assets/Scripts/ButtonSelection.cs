using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class ButtonSelection : MonoBehaviour
{
	public enum Keyname
	{
		KeyA, KeyB, KeyC, KeyD, KeyE, KeyF, KeyG, KeyH, KeyI, KeyJ, KeyK, KeyL, KeyM, KeyN
	}

	public TMP_InputField inputField;
	public TextMeshProUGUI textField;
	public Color selectedColor;
	public GameObject[] buttons;



	private const float defaultSelectionTime = 0.25f;

	//private float angle;
	//private TextMeshProUGUI buttonText;
	private float lastSelectionTime = defaultSelectionTime;
	float startTime;
	float endTime;
	int T;
	private Keyname selectedButton; 
	private Color originalColor;
	private int currentSentenceIndex = 0;
	private string[] sentences = {
		"a bad fig jam",
		"ben can hang a bag",
		"ann had a mad camel",
		"ben can bake a cake",
		"hank feeding an eagle"
	};



	private void Start()
	{
		selectedButton = Keyname.KeyA; 		
		textField.text = sentences[currentSentenceIndex];
		inputField.ActivateInputField();
	}


	public void Update()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");

			float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;
			if (angle < 0)
				angle += 360;

		if (lastSelectionTime <= 0.0f) 
		{
			if (selectedButton == Keyname.KeyA) {
				SelectionfromA (angle);
			} else if (selectedButton == Keyname.KeyB) {
				SelectionfromB (angle);
			} else if (selectedButton == Keyname.KeyC) {
				SelectionfromC (angle);
			} else if (selectedButton == Keyname.KeyD) {
				SelectionfromD (angle);
			} else if (selectedButton == Keyname.KeyE) {
				SelectionfromE (angle);
			} else if (selectedButton == Keyname.KeyF) {
				SelectionfromF (angle);
			} else if (selectedButton == Keyname.KeyG) {
				SelectionfromG (angle);
			} else if (selectedButton == Keyname.KeyH) {
				SelectionfromH (angle);
			} else if (selectedButton == Keyname.KeyI) {
				SelectionfromI (angle);
			} else if (selectedButton == Keyname.KeyJ) {
				SelectionfromJ (angle);
			} else if (selectedButton == Keyname.KeyK) {
				SelectionfromK (angle);
			} else if (selectedButton == Keyname.KeyL) {
				SelectionfromL (angle);
			} else if (selectedButton == Keyname.KeyM) {
				SelectionfromM (angle);
			} else if (selectedButton == Keyname.KeyN) {
				SelectionfromN (angle);
			}
		}
		

		// Change the color of the selected button
		ChangeButtonColor(selectedButton);

	}

	private void LateUpdate()
	{
		ProcessKeyPress();
		inputField.MoveToEndOfLine(false, false);
	}





	//Button Color Changing Mechanism
	private void ChangeButtonColor(Keyname button)
	{
		// Reset color of previously selected button
		foreach (Keyname btn in buttons)
		{
			if (btn != button)
			{
				SetButtonColor(btn, originalColor);
			}
		}

		// Change color of the selected button
		SetButtonColor(button, selectedColor);
	}

	private void SetButtonColor(Keyname button, Color color)
	{
		MeshRenderer[] renderers = button.GetComponents<MeshRenderer>();
		foreach (MeshRenderer renderer in renderers)
		{
			renderer.material.color = color;
		}
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






	private void ProcessKeyPress()
	{
		// Check if the user presses the first character of a sentence
		if (Input.anyKeyDown && T == 0)
		{
			// Start the timer for text entry
			 startTime = Time.time;
		}

		if (selectedButton != null && Input.GetKeyDown(KeyCode.F1))
		{
			TextMeshProUGUI buttonText = selectedButton.GetComponentInChildren<TextMeshProUGUI>();
			string character = buttonText.text;
			inputField.text += character.ToString();
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
	public void SelectionfromA(float angle)
	{
				if (angle > 20.0f && angle <= 90.0f) 
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime; 
				}
				else if (angle > 90.0f &&  angle <= 160.0f)
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 160.0f &&  angle <= 215.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 215.0f &&  angle <= 315.0f)
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 0.0f &&  angle <= 20.0f || angle > 315.0f &&  angle <= 360.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime;
				}
	}


	// Selection for neighbours of b
	public void SelectionfromB(float angle)
	{
				if (angle > 0.0f && angle <= 50.0f)
				{
					selectedButton = Keyname.KeyA;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 50.0f && angle <= 95.0f)
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				}  
				else if (angle > 95.0f && angle <= 142.0f)
				{
					selectedButton = Keyname.KeyJ;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 142.0f && angle <= 200.0f)
				{
					selectedButton = Keyname.KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 200.0f && angle <= 275.0f) 
				{
					selectedButton = Keyname.KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 275.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime;
				}
	}




	// Selection for neighbours of c
	public void SelectionfromC(float angle)
	{
				if (angle > 0.0f && angle <= 25.0f || angle > 340.0f && angle <= 360.0f) 
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 25.0f &&  angle <= 100.0f)
				{
					selectedButton = Keyname.KeyK;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 100.0f &&  angle <= 180)
				{
					selectedButton = Keyname.KeyJ;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180.0f &&  angle <= 270.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 270.0f &&  angle <= 340.0f)
				{
					selectedButton = Keyname.KeyA;
					lastSelectionTime = defaultSelectionTime;
				}
	}




	// Selection for neighbours of d
	public void SelectionfromD(float angle)
	{
				if (angle > 0.0f && angle <= 65.0f) 
				{
					selectedButton = Keyname.KeyL;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				}
				else if (angle > 65.0f &&  angle <= 135.0f)
				{
					selectedButton = Keyname.KeyK;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 135.0f &&  angle <= 205.0f )
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 205.0f  &&  angle <= 270.0f)
				{
					selectedButton = Keyname.KeyA;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 270.0f &&  angle <= 360.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime;
				}
	}




	// Selection for neighbours of E
	public void SelectionfromE(float angle)
	{
				if (angle > 0.0f && angle <= 40.0f ||  angle > 340.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyM;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 40.0f && angle <= 75.0f)
				{
					selectedButton = Keyname.KeyL;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 75.0f && angle <= 140.0f)
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 140.0f && angle <= 182.0f)
				{
					selectedButton = Keyname.KeyA;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 182.0f && angle <= 255.0f) 
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 255.0f && angle <= 340.0f)
				{
					selectedButton = Keyname.KeyN;
					lastSelectionTime = defaultSelectionTime;
				}
	}




	// Selection for neighbours of F
	public void SelectionfromF(float angle)
	{
				if (angle > 0.0f && angle <= 60.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 60.0f && angle <= 120.0f)
				{
					selectedButton = Keyname.KeyA;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 120.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 220.0f)
				{
					selectedButton = Keyname.KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 220.0f && angle <= 315.0f) 
				{
					selectedButton = Keyname.KeyG;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 315.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyN;
					lastSelectionTime = defaultSelectionTime;
				}
	}



	// Selection for neighbours of G
	public void SelectionfromG(float angle)
	{
				if (angle > 0.0f && angle <= 65.0f)
				{
					selectedButton = Keyname.KeyN;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 65.0f && angle <= 130.0f)
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 130.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyK;
					lastSelectionTime = defaultSelectionTime;
				} 
	}




	// Selection for neighbours of H
	public void SelectionfromH(float angle)
	{
				if (angle > 0.0f && angle <= 35.0f)
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 35.0f && angle <= 90.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 90.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 270.0f)
				{
					selectedButton = Keyname.KeyL;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 270.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyG;
					lastSelectionTime = defaultSelectionTime;
				} 
	}




	// Selection for neighbours of I
	public void SelectionfromI(float angle)
	{
				if (angle > 0.0f && angle <= 20.0f ||  angle > 340.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 20.0f && angle <= 45.0f)
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 45.0f && angle <= 110.0f)
				{
					selectedButton = Keyname.KeyJ;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 110.0f && angle <= 250.0f)
				{
					selectedButton = Keyname.KeyM;
					lastSelectionTime = defaultSelectionTime;
				} 
			else if (angle > 250.0f && angle <= 340.0f)
				{
					selectedButton = Keyname.KeyH;
					lastSelectionTime = defaultSelectionTime;
				} 
	}


	// Selection for neighbours of J
	public void SelectionfromJ(float angle)
	{

				if (angle > 0.0f && angle <= 70.0f)
				{
					selectedButton = Keyname.KeyK;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 70.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyN;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 180.0f && angle <= 240.0f)
				{
					selectedButton = Keyname.KeyI;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 240.0f && angle <= 300.0f)
				{
					selectedButton = Keyname.KeyB;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 300.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				} 
	}



	// Selection for neighbours of K
	public void SelectionfromK(float angle)
	{
				if (angle > 20.0f && angle <= 160.0f)
				{
					selectedButton = Keyname.KeyG;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 160.0f && angle <= 215.0f)
				{
					selectedButton = Keyname.KeyJ;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 215.0f && angle < 270.0f)
				{
					selectedButton = Keyname.KeyC;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 270.0f && angle <= 325.0f)
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 0.0f && angle <= 20.0f || angle > 325.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyL;
					lastSelectionTime = defaultSelectionTime;
				} 
	}



	// Selection for neighbours of L
	public void SelectionfromL(float angle)
	{
				if (angle > 0.0f && angle <= 90.0f)
				{
					selectedButton = Keyname.KeyH;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 90.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyK;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 180.0f && angle <= 230.0f)
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 230.0f && angle <= 280.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 280.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyM;
					lastSelectionTime = defaultSelectionTime;
				} 
	}





	// Selection for neighbours of M
	public void SelectionfromM(float angle)
	{
				if (angle > 0.0f && angle <= 65.0f || angle > 300.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyI;
					lastSelectionTime = defaultSelectionTime; 
				} 
				else if (angle > 65.0f && angle <= 145.0f)
				{
					selectedButton = Keyname.KeyL;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 145.0f && angle <= 175.0f)
				{
					selectedButton = Keyname.KeyD;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 175.0f && angle <= 210.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 210.0f && angle <= 300.0f)
				{
					selectedButton = Keyname.KeyN;
					lastSelectionTime = defaultSelectionTime;
				} 
	}


	// Selection for neighbours of N
	public void SelectionfromN(float angle)
	{
				if (angle > 0.0f && angle <= 90.0f)
				{
					selectedButton = Keyname.KeyM;
					lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown
				} 
				else if (angle > 90.0f && angle <= 150.0f)
				{
					selectedButton = Keyname.KeyE;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 150.0f && angle <= 180.0f)
				{
					selectedButton = Keyname.KeyF;
					lastSelectionTime = defaultSelectionTime;
				}
				else if (angle > 180.0f && angle <= 275.0f)
				{
					selectedButton = Keyname.KeyG;
					lastSelectionTime = defaultSelectionTime;
				} 
				else if (angle > 275.0f && angle <= 360.0f)
				{
					selectedButton = Keyname.KeyJ;
					lastSelectionTime = defaultSelectionTime;
				} 
	}




}






