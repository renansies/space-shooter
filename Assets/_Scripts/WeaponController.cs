using UnityEngine;
using UnityEngine.Audio;

namespace _Scripts
{
	public class WeaponController : MonoBehaviour
	{
		public GameObject Shot;
		public Transform[] ShotSpawns;
		public float FireRate;
		public float Delay;

		private AudioSource _audioSource;
		
		
		// Use this for initialization
		void Start ()
		{
			_audioSource = GetComponent<AudioSource>();
			InvokeRepeating("Fire", Delay, FireRate);
		}

		private void Fire()
		{
			foreach (var shotSpawn in ShotSpawns)
			{
				Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
			}
			
			_audioSource.Play();
		}
	}
}
