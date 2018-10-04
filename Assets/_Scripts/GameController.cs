using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
	public class GameController : MonoBehaviour
	{

		public GameObject[] Hazards;
		public Vector3 SpawnValues;
		public int HazardCount;
		public float SpawnWait;
		public float StartWait;
		public float WaveWait;
		
		//GUI Components
		public Text ScoreText;
		private int _score;
		public Text RestartText;
		public Text GameoverText;

		private bool _gameover;
		private bool _restart;
		
		private void Start()
		{
			_gameover = false;
			_restart = false;
			RestartText.text = "";
			GameoverText.text = "";
			_score = 0;
			UpdateScore();
			StartCoroutine(SpawnWaves());
		}

		private void Update()
		{
			if (_restart)
			{
				if (Input.GetKeyDown(KeyCode.R))
				{
					SceneManager.LoadScene("Main");
				}
			}
		}

		private IEnumerator SpawnWaves()
		{
			yield return new WaitForSeconds(StartWait);
			while (true)
			{
				for (var i = 0; i < HazardCount; i++)
				{
					var hazard = Hazards[Random.Range(0, Hazards.Length)];
					var spawnPosition = new Vector3(Random.Range(-SpawnValues.x, +SpawnValues.x), SpawnValues.y,
						SpawnValues.z);
					var spawnRotation = Quaternion.identity;
					Instantiate(hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(SpawnWait);
				}
				yield return new WaitForSeconds(WaveWait);

				if (_gameover)
				{
					RestartText.text = "Press 'R' for restart!";
					_restart = true;
					break;
				}
			}
			// ReSharper disable once IteratorNeverReturns
		}

		public void AddScore(int newScoreValue)
		{
			_score += newScoreValue;
			UpdateScore();
		}
		
		private void UpdateScore()
		{
			ScoreText.text = "Score: " + _score;
		}

		public void GameOver()
		{
			GameoverText.text = "Game Over!";
			_gameover = true;
		}
	}
}
