using UnityEngine;

namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //Value Variables
        public float moveSpeed;
        public float walkSpeed, runSpeed, croundSpeed, jumpSpeed;
        private float _gravity = 20;
        //Struct Variable - Contains multiple variables (eg Transform... 3 floats)
        private Vector3 _moveDir;
        //Reference Variable
        private CharacterController _charC;

        private void Start()
        {
            _charC = GetComponent<CharacterController>();
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            //If we are alive move player
            if (!PlayerHandler.isDead)
            {

            }
            if (_charC.isGrounded)
            {
                //set speed
                if (Input.GetButton("Sprint"))
                {
                    moveSpeed = runSpeed;
                }
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = croundSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
               
                //calculates movements based on inputs
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            if (PlayerHandler.isDead)
            {
                _moveDir = Vector3.zero;
            }
            //Regardless if we are grounded or not
            //Apply Gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply Movement
            _charC.Move(_moveDir * Time.deltaTime);
        }
    }
}