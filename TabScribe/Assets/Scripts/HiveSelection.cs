using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class HiveSelection : MonoBehaviour
{
	public enum Keyname
	{
		KeyA, KeyB, KeyC, KeyD, KeyE, KeyF, KeyG, KeyH, KeyI, KeyJ, KeyK, KeyL, KeyM, KeyN, KeyO, KeyP, KeyQ, KeyR, KeyS
	}

	public TMP_InputField inputField;
	public TextMeshProUGUI textField;
	public GameObject[] buttons;

	private const float moveThreshold = 1.0e-10f;
	private const float defaultSelectionTime = 0.25f;
	private float lastSelectionTime = defaultSelectionTime;

	private Color selectedColor = new Color(0.055f, 0.561f, 0.243f);
	private Color originalColor;
	private Keyname selectedButton;

	private float startTime = 0.0f;

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
		SetButtonColor(buttons[(int)Keyname.KeyA], selectedColor);
		textField.text = sentences[currentSentenceIndex];
		//inputField.ActivateInputField();

	}


	public void Update()
	{
		// Update the selection cooldown
		lastSelectionTime -= Time.deltaTime;

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		float sqrLength = mouseX * mouseX + mouseY * mouseY;

		float angle = Mathf.Atan2 (mouseY, mouseX) * Mathf.Rad2Deg;
		if (angle < 0)
			angle += 360;




		if (lastSelectionTime <= 0.0f && sqrLength > moveThreshold) 
		{
			switch (selectedButton)
			{
			case Keyname.KeyA:
				SelectionfromA(angle);
				break;
			case Keyname.KeyB:
				SelectionfromB(angle);
				break;
			case Keyname.KeyC:
				SelectionfromC(angle);
				break;
			case Keyname.KeyD:
				SelectionfromD(angle);
				break;
			case Keyname.KeyE:
				SelectionfromE(angle);
				break;
			case Keyname.KeyF:
				SelectionfromF(angle);
				break;
			case Keyname.KeyG:
				SelectionfromG(angle);
				break;
			case Keyname.KeyH:
				SelectionfromH(angle);
				break;
			case Keyname.KeyI:
				SelectionfromI(angle);
				break;
			case Keyname.KeyJ:
				SelectionfromJ(angle);
				break;
			case Keyname.KeyK:
				SelectionfromK(angle);
				break;
			case Keyname.KeyL:
				SelectionfromL(angle);
				break;
			case Keyname.KeyM:
				SelectionfromM(angle);
				break;
			case Keyname.KeyN:
				SelectionfromN(angle);
				break;
			case Keyname.KeyO:
				SelectionfromO(angle);
				break;
			case Keyname.KeyP:
				SelectionfromP(angle);
				break;
			case Keyname.KeyQ:
				SelectionfromQ(angle);
				break;
			case Keyname.KeyR:
				SelectionfromR(angle);
				break;
			case Keyname.KeyS:
				SelectionfromS(angle);
				break;
			}


		}

	}


	private void LateUpdate()
	{
		ProcessKeyPress();
		//inputField.MoveToEndOfLine(false, false);
	}



	private void SetButtonColor(GameObject button, Color color)
	{
		MeshRenderer[] renderers = button.GetComponents<MeshRenderer>();
		foreach (MeshRenderer renderer in renderers)
		{
			renderer.material.color = color;
		}
	}




	private void ProcessKeyPress()
	{
		if (Input.anyKeyDown && inputField.text.Length == 0 && startTime == 0.0f)
		{
			// Start the timer for text entry
			startTime = Time.time;
		}

		if (selectedButton != null && Input.GetKeyDown(KeyCode.F1))
		{
			TextMeshProUGUI buttonText = buttons[(int)selectedButton].GetComponentInChildren<TextMeshProUGUI>();
			string character = buttonText.text;
			inputField.text += character.ToString();
		}

		// Handle backspace key
		if (Input.GetKeyDown(KeyCode.F2))
		{
			if (inputField != null && inputField.text.Length > 0)
			{
				inputField.text = inputField.text.Remove(inputField.text.Length - 1);
			}
		}

		// Handle space key
		if (Input.GetKeyDown(KeyCode.F3))
		{
			inputField.text += ' ';
		}

		// Handle the "Enter" key press
		if (Input.GetKeyDown(KeyCode.F4))
		{
			EnterKeyFunctionality();

			//WPM Calculation
			//float endTime = Time.time;
			// Calculate the text entry speed for the current sentence
			float elapsedTime = Time.time - startTime;
			float wordsPerMinute = (inputField.text.Length - 1) / elapsedTime * 60.0f * 0.2f;
			Debug.LogFormat("Text Entry Speed (Sentence {0}): {1} WPM", currentSentenceIndex, wordsPerMinute);

			// Reset start time
			startTime = 0.0f;
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







	// Selection for neighbours of A
	public void SelectionfromA(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyD;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyG;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyE;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyA], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of B
	public void SelectionfromB(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyJ;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyI;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyH;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyG;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyA;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyB], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of C
	public void SelectionfromC(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyL;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyJ;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyD;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyC], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of D
	public void SelectionfromD(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyM;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyL;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyE;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyN;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyD], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of E
	public void SelectionfromE(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyN;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyD;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyP;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyO;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyE], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of F
	public void SelectionfromF(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyE;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyG;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyR;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyQ;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyP;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyF], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of G
	public void SelectionfromG(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyA;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyH;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyS;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyR;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyF;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyG], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of H
	public void SelectionfromH(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyI;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyP;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyL;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyS;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyG;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyH], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of I
	public void SelectionfromI(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyJ;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyS;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyO;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyH;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyB;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyI], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of J
	public void SelectionfromJ(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyR;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyN;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyI;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyC;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyJ], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of K
	public void SelectionfromK(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyI;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyQ;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyM;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyJ;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyC;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyL;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyK], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of L
	public void SelectionfromL(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyH;
		}
		else if (angle > 90.0f &&  angle <= 150.0f)
		{
			selectedButton = Keyname.KeyP;
		}
		else if (angle > 150.0f &&  angle <= 210.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 210.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyD;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyM;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyL], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of M
	public void SelectionfromM(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyS;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyO;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyL;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyD;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyN;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyK;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyM], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of N
	public void SelectionfromN(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyR;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyM;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyD;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyE;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyO;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyJ;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyN], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of O
	public void SelectionfromO(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyQ;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyN;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyE;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyP;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyM;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyI;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyO], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of P
	public void SelectionfromP(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyO;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyE;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyQ;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyL;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyH;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyP], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of Q
	public void SelectionfromQ(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyP;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyR;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyO;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyS;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyQ], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of R
	public void SelectionfromR(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyF;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyG;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyS;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyN;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyJ;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyQ;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyR], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of S
	public void SelectionfromS(float angle)
	{
		if (angle > 30.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyG;
		}
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyH;
		}
		else if (angle > 150.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyQ;
		}
		else if (angle > 210.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyM;
		}
		else if (angle > 270.0f && angle <= 330.0f)
		{
			selectedButton = Keyname.KeyI;
		}
		else //if ((angle > 0.0f &&  angle <= 30.0f) || (angle > 330.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyR;
		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyS], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}
		

}






