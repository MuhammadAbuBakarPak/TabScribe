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
	public GameObject[] buttons;

	private const float moveThreshold = 1.0e-10f;
	private const float defaultSelectionTime = 0.25f;
	private float lastSelectionTime = defaultSelectionTime;

	private Color originalColor;	
	private Color selectedColor = new Color(0.055f, 0.561f, 0.243f);
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







	// Selection for neighbours of a
	public void SelectionfromA(float angle)
	{
		if (angle > 20.0f && angle <= 90.0f) 
		{
			selectedButton = Keyname.KeyD;
		}
		else if (angle > 90.0f &&  angle <= 160.0f)
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 160.0f &&  angle <= 215.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 215.0f &&  angle <= 315.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else //if ((angle > 0.0f &&  angle <= 20.0f) || (angle > 315.0f &&  angle <= 360.0f))
		{
			selectedButton = Keyname.KeyE;

		}

		lastSelectionTime = defaultSelectionTime; 

		SetButtonColor(buttons[(int)Keyname.KeyA], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}

	// Selection for neighbours of b
	public void SelectionfromB(float angle)
	{
		if (angle > 0.0f && angle <= 50.0f)
		{
			selectedButton = Keyname.KeyA;
		} 
		else if (angle > 50.0f && angle <= 95.0f)
		{
			selectedButton = Keyname.KeyC;
		}  
		else if (angle > 95.0f && angle <= 142.0f)
		{
			selectedButton = Keyname.KeyJ;
		} 
		else if (angle > 142.0f && angle <= 200.0f)
		{
			selectedButton = Keyname.KeyI;
		} 
		else if (angle > 200.0f && angle <= 275.0f) 
		{
			selectedButton = Keyname.KeyH;
		} 
		else// if (angle > 275.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyF;
		}

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyB], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of c
	public void SelectionfromC(float angle)
	{
		//		if ((angle > 0.0f && angle <= 25.0f) || (angle > 340.0f && angle <= 360.0f)) 
		//		{
		//			selectedButton = Keyname.KeyD;
		//		}
		/*else*/ if (angle > 25.0f &&  angle <= 100.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 100.0f &&  angle <= 180)
		{
			selectedButton = Keyname.KeyJ;
		}
		else if (angle > 180.0f &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyB;
		}
		else if (angle > 270.0f &&  angle <= 340.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else//if ((angle > 0.0f && angle <= 25.0f) || (angle > 340.0f && angle <= 360.0f)) 
		{
			selectedButton = Keyname.KeyD;
		}

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyC], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of d
	public void SelectionfromD(float angle)
	{
		if (angle > 0.0f && angle <= 65.0f) 
		{
			selectedButton = Keyname.KeyL;
		}
		else if (angle > 65.0f &&  angle <= 135.0f)
		{
			selectedButton = Keyname.KeyK;
		}
		else if (angle > 135.0f &&  angle <= 205.0f )
		{
			selectedButton = Keyname.KeyC;
		}
		else if (angle > 205.0f  &&  angle <= 270.0f)
		{
			selectedButton = Keyname.KeyA;
		}
		else if (angle > 270.0f &&  angle <= 330.0f)
		{
			selectedButton = Keyname.KeyE;
		}
		else// if (angle > 330.0f &&  angle <= 360.0f)
		{
			selectedButton = Keyname.KeyM;
		}

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyD], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of E
	public void SelectionfromE(float angle)
	{
		//		if ((angle > 0.0f && angle <= 40.0f) ||  (angle > 340.0f && angle <= 360.0f))
		//		{
		//			selectedButton = Keyname.KeyM;
		//		} 
		/*else*/ if (angle > 40.0f && angle <= 75.0f)
		{
			selectedButton = Keyname.KeyL;
		} 
		else if (angle > 75.0f && angle <= 140.0f)
		{
			selectedButton = Keyname.KeyD;
		} 
		else if (angle > 140.0f && angle <= 182.0f)
		{
			selectedButton = Keyname.KeyA;
		} 
		else if (angle > 182.0f && angle <= 255.0f) 
		{
			selectedButton = Keyname.KeyF;
			lastSelectionTime = defaultSelectionTime;
		} 
		else if (angle > 255.0f && angle <= 340.0f)
		{
			selectedButton = Keyname.KeyN;
		}
		else//if ((angle > 0.0f && angle <= 40.0f) ||  (angle > 340.0f && angle <= 360.0f))
		{
			selectedButton = Keyname.KeyM;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyE], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of F
	public void SelectionfromF(float angle)
	{
		if (angle > 0.0f && angle <= 60.0f)
		{
			selectedButton = Keyname.KeyE;
		} 
		else if (angle > 60.0f && angle <= 120.0f)
		{
			selectedButton = Keyname.KeyA;
		} 
		else if (angle > 120.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyB;
		} 
		else if (angle > 180.0f && angle <= 220.0f)
		{
			selectedButton = Keyname.KeyH;
		} 
		else if (angle > 220.0f && angle <= 315.0f) 
		{
			selectedButton = Keyname.KeyG;
		} 
		else// if (angle > 315.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyN;
		}

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyF], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}



	// Selection for neighbours of G
	public void SelectionfromG(float angle)
	{
		if (angle > 0.0f && angle <= 65.0f)
		{
			selectedButton = Keyname.KeyN;
		} 
		else if (angle > 65.0f && angle <= 130.0f)
		{
			selectedButton = Keyname.KeyF;
		} 
		else if (angle > 130.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyH;
		} 
		else// if (angle > 180.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyK;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyG], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of H
	public void SelectionfromH(float angle)
	{
		if (angle > 0.0f && angle <= 35.0f)
		{
			selectedButton = Keyname.KeyF;
		} 
		else if (angle > 35.0f && angle <= 90.0f)
		{
			selectedButton = Keyname.KeyB;
		} 
		else if (angle > 90.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyI;
		} 
		else if (angle > 180.0f && angle <= 270.0f)
		{
			selectedButton = Keyname.KeyL;
		}
		else// if (angle > 270.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyG;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyH], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




	// Selection for neighbours of I
	public void SelectionfromI(float angle)
	{
		if ((angle > 0.0f && angle <= 20.0f) || (angle > 340.0f && angle <= 360.0f))
		{
			selectedButton = Keyname.KeyB;
		} 
		else if (angle > 20.0f && angle <= 45.0f)
		{
			selectedButton = Keyname.KeyC;
		} 
		else if (angle > 45.0f && angle <= 110.0f)
		{
			selectedButton = Keyname.KeyJ;
		} 
		else if (angle > 110.0f && angle <= 250.0f)
		{
			selectedButton = Keyname.KeyM;
		} 
		else// if (angle > 250.0f && angle <= 340.0f)
		{
			selectedButton = Keyname.KeyH;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyI], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of J
	public void SelectionfromJ(float angle)
	{

		if (angle > 0.0f && angle <= 70.0f)
		{
			selectedButton = Keyname.KeyK;
		} 
		else if (angle > 70.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyN;
		} 
		else if (angle > 180.0f && angle <= 240.0f)
		{
			selectedButton = Keyname.KeyI;
		} 
		else if (angle > 240.0f && angle <= 300.0f)
		{
			selectedButton = Keyname.KeyB;
		} 
		else// if (angle > 300.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyC;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyJ], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}



	// Selection for neighbours of K
	public void SelectionfromK(float angle)
	{
		if (angle > 20.0f && angle <= 130.0f)
		{
			selectedButton = Keyname.KeyG;
		} 
		else if (angle > 130.0f && angle <= 215.0f)
		{
			selectedButton = Keyname.KeyJ;
		} 
		else if (angle > 215.0f && angle < 270.0f)
		{
			selectedButton = Keyname.KeyC;
		} 
		else if (angle > 270.0f && angle <= 325.0f)
		{
			selectedButton = Keyname.KeyD;
		} 
		else// if ((angle > 0.0f && angle <= 20.0f) || (angle > 325.0f && angle <= 360.0f))
		{
			selectedButton = Keyname.KeyL;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyK], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}



	// Selection for neighbours of L
	public void SelectionfromL(float angle)
	{
		if (angle > 0.0f && angle <= 90.0f)
		{
			selectedButton = Keyname.KeyH;
		} 
		else if (angle > 90.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyK;
		} 
		else if (angle > 180.0f && angle <= 230.0f)
		{
			selectedButton = Keyname.KeyD;
		} 
		else if (angle > 230.0f && angle <= 280.0f)
		{
			selectedButton = Keyname.KeyE;
		} 
		else// if (angle > 280.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyM;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyL], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}





	// Selection for neighbours of M
	public void SelectionfromM(float angle)
	{
		//		if ((angle > 0.0f && angle <= 50.0f) || (angle > 310.0f && angle <= 360.0f))
		//		{
		//			selectedButton = Keyname.KeyI;
		//		} 
		/*else*/ if (angle > 50.0f && angle <= 145.0f)
		{
			selectedButton = Keyname.KeyL;
		} 
		else if (angle > 145.0f && angle <= 175.0f)
		{
			selectedButton = Keyname.KeyD;
		} 
		else if (angle > 175.0f && angle <= 210.0f)
		{
			selectedButton = Keyname.KeyE;
		} 
		else if (angle > 210.0f && angle <= 310.0f)
		{
			selectedButton = Keyname.KeyN;
		} 
		else//if ((angle > 0.0f && angle <= 50.0f) || (angle > 310.0f && angle <= 360.0f))
		{
			selectedButton = Keyname.KeyI;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyM], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}


	// Selection for neighbours of N
	public void SelectionfromN(float angle)
	{
		if (angle > 0.0f && angle <= 90.0f)
		{
			selectedButton = Keyname.KeyM;
		} 
		else if (angle > 90.0f && angle <= 150.0f)
		{
			selectedButton = Keyname.KeyE;
		} 
		else if (angle > 150.0f && angle <= 180.0f)
		{
			selectedButton = Keyname.KeyF;
		}
		else if (angle > 180.0f && angle <= 275.0f)
		{
			selectedButton = Keyname.KeyG;
		} 
		else// if (angle > 275.0f && angle <= 360.0f)
		{
			selectedButton = Keyname.KeyJ;
		} 

		lastSelectionTime = defaultSelectionTime; // Reset the selection cooldown

		SetButtonColor(buttons[(int)Keyname.KeyN], originalColor); 
		SetButtonColor(buttons[(int)selectedButton], selectedColor);
	}




}





