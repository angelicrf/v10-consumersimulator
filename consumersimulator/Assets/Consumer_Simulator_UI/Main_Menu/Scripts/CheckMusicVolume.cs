using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu{

	public class CheckMusicVolume : MonoBehaviour {
		public FloatData musicVolume;
		
		public void  Start (){
			if (GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().volume = musicVolume.RuntimeValue;
			}
		}

		public void UpdateVolume (){
			if (GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().volume = musicVolume.RuntimeValue;
			}
		}
	}
}