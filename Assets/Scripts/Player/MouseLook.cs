using UnityEngine;

namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Mouse Look")]
    public class MouseLook : MonoBehaviour
    {
        //Enum - allows developers to create variables (eg Races in WoW)
        public enum RotationalAxis
        {
            MouseX,
            MouseY
        }
        [Header("Rotation Variables")]
        //Allows the rotaion of the camera on the X-axis
        public RotationalAxis axis = RotationalAxis.MouseX;
        //changes the range of sensitivity for camera control
        [Range(0, 100)]
        public float sensitivity = 15;
        //Creates the Max and Min that the character can look on the Y-axis
        public float minY = -60, maxY = 60;
        private float _rotY;

        //Start - the very first frame the componate the object is active
        private void Start()
        {
            //If we want to use RigidBody Freezes all Rotational Control Actions
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //Allows the Camera to move along the Y-axis
            if (GetComponent<Camera>())
            {
                axis = RotationalAxis.MouseY;
            }
        }
        //Update - 
        private void Update()
        {
            //If we are alive Rotate Camera and Player
            if (!PlayerHandler.isDead)
            {
                //Allows the rotaion of the camera on the X-axis
                if (axis == RotationalAxis.MouseX)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
                }
                //Allows the Camera to move along the Y-axis
                else
                {
                    _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                    _rotY = Mathf.Clamp(_rotY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                }
            }

        }
    }
}