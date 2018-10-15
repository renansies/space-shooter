using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
	public class BossMover : MonoBehaviour {

		#region Enums

		public enum MovementType
		{
			MoveTowards,
			LerpTowards
		}
		#endregion

		#region Public Variables

		public MovementType Type = MovementType.MoveTowards;
		public BossPath Path;
		public float Speed = 1;
		public float MaxDistanceToGoal = .1f;

		#endregion

		private IEnumerator<Transform> PointInPath;

		private void Start()
		{
			if (Path == null)
			{
				Debug.LogError("Movement Path Cannot Be NUll, I must have a path to follow.", gameObject);
				return;
			}

			PointInPath = Path.GoToNextPoint();
			PointInPath.MoveNext();
			if (PointInPath.Current == null)
			{
				Debug.LogError("A path must have points in it to follow", gameObject);
				return;
				
			}

			transform.position = PointInPath.Current.position;
		}

		private void Update()
		{
			if (PointInPath == null || PointInPath.Current == null)
			{
				return;
			}

			if (Type == MovementType.MoveTowards)
			{
				transform.position = Vector3.MoveTowards(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
			}
			else if (Type == MovementType.LerpTowards)
			{
				transform.position = Vector3.Lerp(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
			}

			var distanceSquared = (transform.position - PointInPath.Current.position).sqrMagnitude;
			if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			{
				PointInPath.MoveNext();
			}
		}
	}
}
