using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound){
		if(!disableOnce)
		{
			//I think this needs to be in audiomanager otherwise it will not work
			menuButtonController.audioSource.PlayOneShot (whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}
}	
