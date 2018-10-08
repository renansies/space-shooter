using System.Collections;
using UnityEngine;

namespace _Scripts
{
	public class BossMover : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}

		IEnumerator Move()
		{
			GetComponent<Rigidbody>().velocity = transform.forward * -10;
			yield return new WaitForSeconds(2);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		
	}
}
