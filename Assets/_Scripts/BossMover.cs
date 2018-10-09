using System.Collections;
using UnityEngine;

namespace _Scripts
{
	public class BossMover : MonoBehaviour {

		public float Speed;
		public GameObject Target;
		
		
		private void Start()
		{
			var distance = Vector3.Distance(transform.position, Target.transform.position);

			if (distance > 0)
			{
				transform.Translate(Speed * Time.deltaTime, 0, 0);
			}
		}
	}
}
