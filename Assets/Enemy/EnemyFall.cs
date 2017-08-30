using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFall : StateMachineBehaviour {

	// This will be called once the animator has transitioned out of the state.
	override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<Enemy> ().OnFinishedFall ();
	}
}
