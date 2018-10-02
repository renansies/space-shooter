using UnityEngine;

namespace _Scripts
{
	public class DestroyByContact : MonoBehaviour
	{

		public GameObject Explosion;
	
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Boundary")) return;
			Instantiate(Explosion, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
