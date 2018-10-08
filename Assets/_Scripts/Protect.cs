using UnityEngine;

namespace _Scripts
{
	public class Protect : MonoBehaviour {
		
		
		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Enemy"))
				Destroy(other.gameObject);
		}
	}
}