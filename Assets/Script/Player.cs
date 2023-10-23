using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float runSpeed = 2f;
    [SerializeField] float mass = 1f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Animator animator;


    #region Variable untuk IK

/*    [SerializeField] Transform LeftFoot;
    [SerializeField] Transform RightFoot;

    public LayerMask layerMask; // Select all layers that foot placement applies to.
    [Range(0, 1f)]
    public float RaycastDistance;*/
    #endregion

    private float movementSpeed;
    private bool mutar;

    CharacterController controller;
    Vector3 velocity;
    Vector2 look;

/*    private void OnAnimatorIK(int layerIndex)
    {

        if (animator)
        { // Only carry out the following code if there is an Animator set.

            // Set the weights of left and right feet to the current value defined by the curve in our animations.
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));

            // Left Foot
            RaycastHit hit;
            // We cast our ray from above the foot in case the current terrain/floor is above the foot position.
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {

                // We're only concerned with objects that are tagged as "Walkable"
                if (hit.transform.tag == "Walkable")
                {

                    Vector3 footPosition = hit.point; // The target foot position is where the raycast hit a walkable object...
                    footPosition.y += DistanceToGround; // ... taking account the distance to the ground we added above.
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));

                }

            }

            // Right Foot
            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {

                if (hit.transform.tag == "Walkable")
                {

                    Vector3 footPosition = hit.point;
                    footPosition.y += DistanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));

                }

            }


        }

    }*/

    void Awake() // setiap kali set active true
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start() // hanya sekali pas start
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if ( Paused.Pause == false)
        {
            UpdateGravity();
            updateMovement();
            updateLook();
        }

    }
    private void LateUpdate()
    {
        if (Paused.Pause == false)
        {
            cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0); //buat liat atas bawah 
        }

        #region IK
/*        RaycastHit hit;
        // We cast our ray from above the foot in case the current terrain/floor is above the foot position.
        Ray ray = new Ray(LeftFoot.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, RaycastDistance, layerMask))
        {

            // We're only concerned with objects that are tagged as "Walkable"
            if (hit.transform.tag == "Walkable")
            {

            }

        }

        ray = new Ray(RightFoot.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, RaycastDistance, layerMask))
        {

            if (hit.transform.tag == "Walkable")
            {

            }

        }*/
        #endregion
    }

/*    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(LeftFoot.position, Vector3.down * RaycastDistance);
        Gizmos.DrawRay(RightFoot.position, Vector3.down * RaycastDistance);
    }*/

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1f : velocity.y + gravity.y;
    }

    void updateMovement()
    {
        #region Ketut
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;
            animator.speed = runSpeed / walkSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
            animator.speed = 1f;
        }

        //transform.Translate(input * movementSpeed * Time.deltaTime, Space.World);
        controller.Move((input * movementSpeed + velocity) * Time.deltaTime);
        #endregion

        this.animator.SetFloat("Vertical", y);
        this.animator.SetFloat("Horizontal", x);

        if (x == 0 && y == 0 && mutar == true)
        {
            animator.SetBool("StandMutar", true);
        }
        else
        {
            animator.SetBool("StandMutar", false);
        }

    }
    // Update is called once per frame
    void updateLook()
    {
        var x = Input.GetAxis("Mouse X");

        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        transform.localRotation = Quaternion.Euler(0, look.x, 0); // kiri kanan

        if (x < -0.2f || x > 0.2f)
        {
            mutar = true;
        }
        else
        {
            mutar = false;
        }
    }

}
