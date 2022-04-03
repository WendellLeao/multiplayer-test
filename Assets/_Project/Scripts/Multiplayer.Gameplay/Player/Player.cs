using Multiplayer.Events;
using ServiceLocator;
using UnityEngine;
using Mirror;
using Multiplayer.Gameplay.Events;

namespace Multiplayer.Gameplay.Playing
{
    public sealed class Player : NetworkEntity
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _localPlayerMaterial;
        [SerializeField] private Material _otherPlayerMaterial;
        [SerializeField] private Material[] _randomMaterials;

        private void Start()
        {
            if (isLocalPlayer)
            {
                SetMaterial(_localPlayerMaterial);

                return;
            }
            
            SetMaterial(_otherPlayerMaterial);
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

            float speed = 5f;
            
            transform.position += direction * Time.deltaTime * speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdSetUltimateMaterial();
            }
        }

        [Command]
        private void CmdSetUltimateMaterial()
        {
            int randomIndex = Random.Range(0, _randomMaterials.Length);
            
            RpcSetUltimateMaterial(randomIndex);
        }
        
        [ClientRpc]
        private void RpcSetUltimateMaterial(int randomIndex)
        {
            SetRandomMaterial(randomIndex);
        }

        private void SetRandomMaterial(int randomIndex)
        {
            Material randomMaterial = _randomMaterials[randomIndex];
            
            SetMaterial(randomMaterial);
        }
        
        private void SetMaterial(Material material)
        {
            _meshRenderer.material = material;

            IEventService eventService = GameServices.GetService<IEventService>();

            MaterialChangedEvent materialChangedEvent = new MaterialChangedEvent(material);
            
            eventService.DispatchEvent(materialChangedEvent);
        }
    }
}
