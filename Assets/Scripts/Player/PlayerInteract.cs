using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private Camera _cam;

        [FormerlySerializedAs("distance")] [SerializeField]
        private float interactionDistance = 3f;

        [FormerlySerializedAs("mask")] [SerializeField]
        private LayerMask interactionMask;

        private PlayerUI _playerUI;
        private InputManager _inputManager;

        // Start is called before the first frame update
        private void Awake()
        {
            _cam = GetComponent<PlayerLook>().cam;
            _playerUI = GetComponent<PlayerUI>();
            _inputManager = GetComponent<InputManager>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleInteraction();
        }

        private void HandleInteraction()
        {
            _playerUI.UpdateText(string.Empty);

            if (!TryGetInteractable(out Interactable interactable)) return; // Step tf out of this fukin function.

            interactable.OnRaycasted();
            _playerUI.UpdateText(interactable.promptMessage);

            if (_inputManager.OnFoot.Interact.triggered)
            {
                interactable.BaseInteract();
            }
        }

        private bool TryGetInteractable(out Interactable interactable)
        {
            Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionDistance, interactionMask))
            {
                interactable = hitInfo.collider.GetComponent<Interactable>();
                return interactable is not null;
            }

            interactable = null;
            return false;
        }
    }
}