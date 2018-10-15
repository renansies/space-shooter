using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts
{
	public class BossPath : MonoBehaviour {


		#region Enums

		public enum PathTypes
		{
			Linear,
			Loop
		}
		#endregion
		
		#region Public Variables
		public PathTypes PathType;
		public int MovementDirection =1;
		public int MovingTo = 0;
		public Transform[] Path;
		#endregion

		// Use this for initialization
		private void Start ()
		{
			
		}

		private void OnDrawGizmos()
		{
			if (Path == null || Path.Length < 2) return;

			for (var i=1; i < Path.Length; i++)
			{
				Gizmos.DrawLine(Path[i-1].position, Path[i].position);
			}

			if (PathType == PathTypes.Loop)
			{
				Gizmos.DrawLine(Path[0].position, Path[Path.Length-1].position);
			}
		}
	
		// Update is called once per frame
		private void Update () {
			
		}
		
		public IEnumerator<Transform> GoToNextPoint()
		{
			if (Path == null || Path.Length < 1) yield break;

			while (true)
			{
				yield return Path[MovingTo];

				if (Path.Length == 1) continue;

				if (PathType == PathTypes.Linear)
				{
					if (MovingTo <= 0)
						MovementDirection = 1;
					else if (MovingTo >= Path.Length - 1)
						MovementDirection = -1;
				}

				MovingTo = MovingTo + MovementDirection;

				if (PathType == PathTypes.Loop)
				{
					if (MovingTo >= Path.Length)
						MovingTo = 0;
					if (MovingTo < 0)
						MovingTo = Path.Length - 1;
				}
				
			}
		}
	}
}
