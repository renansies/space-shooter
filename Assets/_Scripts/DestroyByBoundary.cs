using UnityEngine;

namespace _Scripts
{
	public class DestroyByBoundary : MonoBehaviour 
	{
		private void OnTriggerExit(Collider other)
		{
			Destroy(other.gameObject);
		}
	}
}
