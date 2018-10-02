using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
	public class GameController : MonoBehaviour
	{

		public GameObject Hazard;
		public Vector3 SpawnValues;
		public int HazardCount;
		public float SpawnWait;
		public float StartWait;
		public float WaveWait;
		
		//GUI Components
		public Text ScoreText;
		private int _score;

		private void Start()
		{
			_score = 0;
			UpdateScore();
			StartCoroutine(SpawnWaves());
		}

		private IEnumerator SpawnWaves()
		{
			yield return new WaitForSeconds(StartWait);
			while (true)
			{
				for (var i = 0; i < HazardCount; i++)
				{
					var spawnPosition = new Vector3(Random.Range(-SpawnValues.x, +SpawnValues.x), SpawnValues.y,
						SpawnValues.z);
					var spawnRotation = Quaternion.identity;
					Instantiate(Hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds(SpawnWait);
				}
				yield return new WaitForSeconds(WaveWait);
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
	}
}
