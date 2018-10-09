using UnityEngine;

namespace _Scripts
{
    public class TripleShotPowerUp : PowerUp
    {
        public override void Activate()
        {
            var player = GameObject.FindGameObjectsWithTag("Player");
            player[0].GetComponent<PlayerController>().CanTripleShot = true;
        }

        public override void Deactivate()
        {
            var player = GameObject.FindGameObjectsWithTag("Player");
            player[0].GetComponent<PlayerController>().CanTripleShot = false;
        }
    }
}