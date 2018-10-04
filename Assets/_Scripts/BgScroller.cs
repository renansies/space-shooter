using UnityEngine;
using UnityEngine.Networking;

namespace _Scripts
{
	public class BgScroller : MonoBehaviour
	{

		public float ScrollSpeed;
		public float TileSizeZ;

		private Vector3 _startPosition;

		// Use this for initialization
		void Start ()
		{
			_startPosition = transform.position;
		}
	
		// Update is called once per frame
		private void Update ()
		{
			var newPosition = Mathf.Repeat(Time.time * ScrollSpeed, TileSizeZ);
			transform.position = _startPosition + Vector3.forward * newPosition;
		}
	}
}
