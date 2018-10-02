using UnityEngine;

namespace _Scripts
{
	public class Mover : MonoBehaviour
	{

		public float Speed;
		
		private void Start()
		{
			GetComponent<Rigidbody>().velocity = transform.forward * Speed;
		}
	}
}
