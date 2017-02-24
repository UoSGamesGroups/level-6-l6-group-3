using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	[SerializeField] BoxCollider _col;

	public void ActivateCollider(int a)
	{
		if(a == 0)
			_col.enabled = false;
		else if(a == 1)
			_col.enabled = true;		
	}
}
