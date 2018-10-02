using System.Collections;
using UnityEngine;

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

		private void Start()
		{
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
		}
	}
}
