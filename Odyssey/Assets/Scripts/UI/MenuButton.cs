using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	public int thisIndex;


	
    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			
			animator.SetBool ("selected", true);
			if (Input.GetButtonDown("Submit"))
			{
				animator.SetBool("pressed", true);
			}
			else if (animator.GetBool("pressed"))
			{
				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}
		else
		{ 
			animator.SetBool ("selected", false);
		}
    }
}
