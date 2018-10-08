using UnityEngine;

namespace _Scripts
{
	public class BossWeaponController : MonoBehaviour {

		public GameObject Shot;
		public GameObject Missile;
		public Transform[] ShotSpawns;
		public Transform[] MissileSpawns;
		
		public float FireRate;
		public float DelayShot;
		
		public float MissileRate;
		public float DelayMissile;

		private AudioSource _audioSource;
		
		
		// Use this for initialization
		void Start ()
		{
			_audioSource = GetComponent<AudioSource>();
			InvokeRepeating("Fire", DelayShot, FireRate);
			InvokeRepeating("MissileFire", DelayMissile, MissileRate);
		}

		private void Fire()
		{
			foreach (var shotSpawn in ShotSpawns)
			{
				Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
			}	
			_audioSource.Play();
		}
		
		private void MissileFire()
		{
			var randomSpawn = Random.Range(0, MissileSpawns.Length);
			Instantiate(Missile, MissileSpawns[randomSpawn].position, MissileSpawns[randomSpawn].rotation);	
			_audioSource.Play();
		}
		
		
	}
}
