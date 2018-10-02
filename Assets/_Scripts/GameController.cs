using UnityEngine;

namespace _Scripts
{
	public class GameController : MonoBehaviour
	{

		public GameObject Hazard;
		public Vector3 SpawnValues;

		private void Start()
		{
			SpawnWaves();
		}

		void SpawnWaves()
		{
			var spawnPosition = new Vector3(Random.Range(-SpawnValues.x, +SpawnValues.x), SpawnValues.y, SpawnValues.z);
			var spawnRotation = Quaternion.identity;
			Instantiate(Hazard, spawnPosition, spawnRotation);
		}
	}
}
