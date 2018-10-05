using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class ScalePowerUp : PowerUp
    {

        public float Scale;

        private Vector3 _initialScale;

        
        public override void Activate()
        {
            Player.gameObject.transform.localScale = Player.gameObject.transform.localScale * Scale;
        }

        public override void Deactivate()
        {
            Player.gameObject.transform.localScale = Player.gameObject.transform.localScale / Scale;
        }
    }
}