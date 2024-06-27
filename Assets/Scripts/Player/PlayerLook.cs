using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        public Camera cam;
        private float _xRotation; // Initializing field by default value is redundant u stupid ass nigger.

        public float xSens = 30f;
        public float ySens = 30f;

        public void ProcessLook (Vector2 input)
        {
            float mouseX = input.x;
            float mouseY = input.y;

            _xRotation -= (mouseY * Time.deltaTime) * xSens;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

            cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSens));
        }
    }
}
