using UnityEngine;

namespace _Scripts
{
    public class ShieldPowerUp : PowerUp {

        
        public override void Activate()
        {
            var gameObjects = GameObject.FindGameObjectsWithTag("Shield");
            gameObjects[0].GetComponentInChildren<Collider>().enabled = true;
            gameObjects[0].GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        public override void Deactivate()
        {
            var gameObjects = GameObject.FindGameObjectsWithTag("Shield");
            gameObjects[0].GetComponentInChildren<Collider>().enabled = false;
            gameObjects[0].GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
