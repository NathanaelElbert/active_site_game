using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {


    [SerializeField] Transform rotateParent = null;


    // PUBLIC
    public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public Transform headTrans;
	public float speedMovements = 5f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 10000f;
    public static bool go;

	// PRIVATE
	private Rigidbody _rigidbody;
	[SerializeField] bool continuousRightController = true;

    Transform objectToRotate;

    void Awake()
	{

        go.Equals(false);

        objectToRotate = (rotateParent == null) ? transform : rotateParent;
        _rigidbody = GetComponent<Rigidbody>();
		rightController.TouchEvent += RightController_TouchEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			UpdateAim(value);
		}
	}

	void Update()
	{


        // move

        _rigidbody.MovePosition(transform.position + (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
			(transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements) );

		if(continuousRightController)
		{
			UpdateAim(rightController.GetTouchPosition);
		}
	}

	void UpdateAim(Vector2 value)
	{
		if(headTrans != null)
		{
            objectToRotate.rotation = Quaternion.Euler(0f,
				transform.localEulerAngles.y - value.x * Time.deltaTime * -speedProgressiveLook,
				0f);


            objectToRotate.rotation = Quaternion.Euler(transform.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				0f,
				0f);


            go.Equals(true);
            
        }
		else
		{

			objectToRotate.rotation = Quaternion.Euler(transform.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				transform.localEulerAngles.y + value.x * Time.deltaTime * speedProgressiveLook,
				0f);

			
		}
	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
	}

}
