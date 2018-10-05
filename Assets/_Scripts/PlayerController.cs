using System.Collections;
using UnityEngine;

namespace _Scripts
{

	[System.Serializable]
	public class Boundary
	{
		public float XMin, XMax, ZMin, ZMax; 
	}
	public class PlayerController : MonoBehaviour
	{

		public float Speed;
		public float Tilt;
		public Boundary Boundary;

		public GameObject Shot;
		public Transform[] ShotSpawns;

		public PowerUp ActivePowerUp;
		private int _powerUpDuration;

		public float FireRate;
		private float _nextFire;

		void Update()
		{
			if (Input.GetButton("Fire1") && Time.time > _nextFire)
			{
				_nextFire = Time.time + FireRate;
				foreach (var shotSpawn in ShotSpawns)
				{
					Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
				}
				
			}
		}
		

		private void FixedUpdate()
		{
			var moveHorizontal = Input.GetAxis("Horizontal");
			var moveVertical = Input.GetAxis("Vertical");

			var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
			var body = GetComponent<Rigidbody>();
			body.velocity = movement * Speed;
		
			body.position = new Vector3
			(
				Mathf.Clamp(body.position.x, Boundary.XMin, Boundary.XMax), 
				0.0f, 
				Mathf.Clamp(body.position.z, Boundary.ZMin, Boundary.ZMax)
			);
			
			body.rotation = Quaternion.Euler(0.0f, 0.0f, body.velocity.x * -Tilt);
		}

		private void ActivatePowerUp()
		{
			ActivePowerUp.Activate();
			StartCoroutine(DeactivatePowerUp(ActivePowerUp.Duration));
		}

		private IEnumerator DeactivatePowerUp(int seconds)
		{
			yield return new WaitForSeconds(seconds);
			ActivePowerUp.Deactivate();
			ActivePowerUp = null;
		}

		public void SetPowerUp(PowerUp powerUp)
		{
			if (ActivePowerUp != null)
			{
				Debug.Log("Deactivate");
				StopAllCoroutines();
				ActivePowerUp.Deactivate();
			}

			ActivePowerUp = powerUp;
			ActivatePowerUp();
			
		}
	}
}
