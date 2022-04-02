using UnityEngine;
using Mirror;

namespace Multiplayer.Gameplay
{
    public sealed class SunManager : NetworkBehaviour
    {
        [SerializeField] private Transform _directionalLightTransform;

        private bool _shouldUpdate;
        
        private void Update()
        {
            if (!_shouldUpdate)
            {
                return;
            }

            CmdUpdateRotation();
        }

        [Command]
        private void CmdUpdateRotation()
        {
            Quaternion directionalLightRotation = _directionalLightTransform.rotation;
            
            float yRotation = directionalLightRotation.y;
            float zRotation = directionalLightRotation.z; 
            float xRotation = Time.deltaTime * 10f;
            
            RpcUpdateRotation(xRotation, yRotation, zRotation);
        }
        
        [ClientRpc]
        private void RpcUpdateRotation(float xRotation, float yRotation, float zRotation)
        {
            _directionalLightTransform.Rotate(xRotation, yRotation, zRotation);
        }
    }
}