using System;
using UnityEngine;

namespace _Scripts
{
	public class DestroyByContact : MonoBehaviour
	{

		public GameObject Explosion;
		public GameController GameController;
		public int ScoreValue;

		private void Start()
		{
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
			if (other.CompareTag("Boundary")) return;

			if (this.CompareTag("Player"))
			{
				GameController.GameOver();
			}
			Instantiate(Explosion, transform.position, transform.rotation);
			GameController.AddScore(ScoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
