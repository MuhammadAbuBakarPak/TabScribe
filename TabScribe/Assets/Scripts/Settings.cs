namespace VRTyping
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Settings : Singleton<Settings> {

		[Header("TypingData")]
		public string fileName;
		public int studentID;
		public int toolID;

	}
}
