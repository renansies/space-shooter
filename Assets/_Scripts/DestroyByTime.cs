using UnityEngine;

namespace _Scripts
{
	public class DestroyByTime : MonoBehaviour
	{

		public float Lifetime;

		private void Start()
		{
			Destroy(gameObject, Lifetime);
		}
	}
}
