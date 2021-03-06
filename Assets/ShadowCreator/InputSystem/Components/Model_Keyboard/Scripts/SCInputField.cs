﻿using UnityEngine;
using UnityEngine.UI;

namespace SC
{
	public class SCInputField :  MonoBehaviour{

		public SCKeyboard keyboard;
		public Text placeholderCompontent;
		public Text textCompontent;
		private string _text;

		public string text{
			set{ 
				_text = value;
				textCompontent.text = _text;
				placeholderCompontent.enabled = _text == string.Empty;
			} 
			get{
				return _text;
			}
		}


		void Start()
		{
			text = string.Empty;
		}

		public void onClick()
		{
			keyboard.show (this, _text);
		}
	}
}
