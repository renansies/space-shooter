using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
	public class DestroyByContact : MonoBehaviour
	{

		public GameObject[] PowerUps;
		
		public GameObject Explosion;
		public GameObject PlayerExplosion;
		public GameController GameController;
		public int ScoreValue;

		private float _powerUpSpawn;
		private void Start()
		{
			_powerUpSpawn = Random.Range(0f, 1f);
			var gameControllerObject = GameObject.FindWithTag("GameController");
			try
			{
				GameController = gameControllerObject.GetComponent<GameController>();
			}
			catch (NullReferenceException except)
			{
				Debug.LogError("Cannot find 'Game Controller' script");
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp") || other.CompareTag("Shield")) return;

			if (Explosion != null)
			{
				Instantiate(Explosion, transform.position, transform.rotation);
			}

			if (other.CompareTag("Player"))
			{
				Instantiate(PlayerExplosion, transform.position, transform.rotation);
				GameController.GameOver();
			}

			if (_powerUpSpawn < 0.1 && PowerUps.Length > 0)
			{
				var index = Random.Range(0, PowerUps.Length);
				Instantiate(PowerUps[index], this.transform.position, this.transform.rotation);
			}
			
			GameController.AddScore(ScoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}