using UnityEngine;

namespace _Scripts
{
	public class RandomRotate : MonoBehaviour
	{

		public float Tumble;

		private void Start()
		{
			GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Tumble;
		}
	}
}
