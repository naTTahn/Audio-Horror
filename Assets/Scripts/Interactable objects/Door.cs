using UnityEngine;

namespace Interactable_objects
{
    public class Door : Interactable
    {
        public MeshRenderer meshRenderer;
        //public MeshRenderer meshRenderer;
        public Material highlightMaterial;
        public Material transparentMaterial;
        private bool _doorOpen;
        public GameObject door;
        private static readonly int IsOpen = Animator.StringToHash("isOpen");

        // Start is called before the first frame update
        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        protected override void Interact()
        {
            base.Interact(); // No need to call this if the parent version of the func is useless which is empty in the case u stupid ass nigger.
            //Debug.Log("Interact with " + gameObject.name);
            var doorAnimator = door.GetComponent<Animator>();
            if (!doorAnimator)
            {
                Debug.Log("Door's animator is null");
                return;
            }
            _doorOpen = !doorAnimator.GetBool(IsOpen);
            Debug.Log("Door is " + _doorOpen);
            doorAnimator.SetBool(IsOpen, _doorOpen);
        }
        private void FixedUpdate()
        {
            HideHighlight();
        }
        protected override void OnHover()
        {
            base.OnHover();
            ShowHighlight();
        }
        void HideHighlight()
        {
            Material[] materials = meshRenderer.materials;
            materials[1] = transparentMaterial;
            meshRenderer.materials = materials;
        }
        void ShowHighlight()
        {
            Material[] materials = meshRenderer.materials;
            materials[1] = highlightMaterial;
            meshRenderer.materials = materials;
        }
    }
}
