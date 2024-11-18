using UnityEngine;
using System.Collections;
//
//[AddComponentMenu("UnityFS/Dynamics/Control Surface")]
//[RequireComponent (typeof(Wing))]

public class ControlSurface : AircraftAttachment 
{
	public bool Is_Vertical;
	public bool Is_Horizontal;
	public bool Is_Daigonal;
	public GameObject PlaneModel = null;

	public float MaxDeflectionDegrees = 0f;
	public float RootHingeDistanceFromTrailingEdge = 0.25f;
	public float TipHingeDistanceFromTrailingEdge = 0.25f;
	public bool[] AffectedSections;
	public GameObject Model = null;
	public Vector3 ModelRotationAxis = Vector3.left;

	public AnimationCurve InputCurve = null;
	
	[HideInInspector]
	public InputController Controller = new InputController();
	
	private Vector3 WingRootAileronHingePos = Vector3.zero;
	private Vector3 WingTipAileronHingePos = Vector3.zero;
	private Quaternion InitialModelRotation = Quaternion.identity;
	private float CurrentDeflection = 0.0f;
	private float TempCurrentDeflection = 0.0f;



	public void Start () 
	{
		ModelRotationAxis.Normalize();
		
		if ( null != Model )
		{
			InitialModelRotation = Model.transform.localRotation;
		}
	}
	public float input;

	public void FixedUpdate()
	{
		PlaneModel.transform.rotation = new Quaternion ((Mathf.Clamp(PlaneModel.transform.rotation.x,-0.25f, 0.25f)),
		                                                PlaneModel.transform.rotation.y,
		                                                (Mathf.Clamp(PlaneModel.transform.rotation.z, -0.33f, 0.35f)),
		                                                PlaneModel.transform.rotation.w);
	}

	public void Update () 
	{
//		print("Plane Rotaion : Z : "+PlaneModel.transform.rotation.z);


		if (Is_Vertical==true) 
		{
			if(Application.platform==RuntimePlatform.Android)
			{
				input = Controller.GetAxisInput_Y ();
			}
			else
			{
				input = Controller.GetAxisInput ();
			}
		}
		else
		if(Is_Horizontal==true)
		{
			if(Application.platform==RuntimePlatform.Android)
			{
				input = Controller.GetAxisInput();
			}
			else
			{
				input = Controller.GetAxisInput ();
			}
		}
		else
			if(Is_Daigonal==true)
		{
			if(Application.platform==RuntimePlatform.Android)
			{
				input = Controller.GetAxisInput_Z ();
			}
			else
			{
				input = Controller.GetAxisInput ();
			}
		}

		//Only move if control is enabled..
		if ( Controllable )
		{
			float curveValue = InputCurve.Evaluate( Mathf.Abs(input) );
			curveValue *= Mathf.Sign( input);
			CurrentDeflection = curveValue * MaxDeflectionDegrees;

		}
		
		//Apply rotation to model.	
		if ( null != Model )
		{
			Model.transform.localRotation = InitialModelRotation;
			Model.transform.Rotate( ModelRotationAxis, CurrentDeflection );
		}
	}
	
	public void ModifyWingGeometry( int SectionIndex, ref Vector3 PointA, ref Vector3 PointB, ref Vector3 PointC, ref Vector3 PointD)
	{
		if ( SectionIndex < AffectedSections.Length )
		{
			if ( AffectedSections[SectionIndex]==true)
			{
				//return;
				//R A-----------------B (Leading edge)
				//O |                 |  
				//O |                 |
				//T D-----------------C (Trailing edge

				//First step is to work out the aileron position and offset on the wing.
//				if(PlaneModel.transform.rotation.x>=-0.21 && PlaneModel.transform.rotation.x<=0.26)
				{
					WingRootAileronHingePos = PointD + ( ( PointA - PointD ) * RootHingeDistanceFromTrailingEdge );
					WingTipAileronHingePos = PointC + ( ( PointB - PointC ) * TipHingeDistanceFromTrailingEdge );
					Vector3 aileronHinge = WingTipAileronHingePos - WingRootAileronHingePos;
							
					Vector3 rootAileronAngle = PointD - WingRootAileronHingePos;
					Vector3 tipAileronAngle = PointC - WingTipAileronHingePos;
					
					//Deflect ailerons.
					Quaternion hingeRotation = Quaternion.AngleAxis( CurrentDeflection, aileronHinge.normalized);
				
					rootAileronAngle = hingeRotation * rootAileronAngle;
					tipAileronAngle = hingeRotation * tipAileronAngle;

					//Once we know the deflection of the aileron and where are new trailing edge is, we can use this to tweak the
					//wing chord line.
					PointD = WingRootAileronHingePos + rootAileronAngle;
					PointC = WingTipAileronHingePos + tipAileronAngle;
				}
			}
		}
	}
	
	public void OnDrawGizmos() 
	{
		ClampEditorValues();
    }
	
	
	private void ClampEditorValues()
	{
		MaxDeflectionDegrees = Mathf.Clamp( MaxDeflectionDegrees, 0.0f, 90.0f );
		RootHingeDistanceFromTrailingEdge = Mathf.Clamp( RootHingeDistanceFromTrailingEdge, 0.0f, 1.0f );
		TipHingeDistanceFromTrailingEdge = Mathf.Clamp( TipHingeDistanceFromTrailingEdge, 0.0f, 1.0f );
		
		Wing wing = gameObject.GetComponent<Wing>();
		if (null!= wing )
		{
			if ( (null==AffectedSections) || (wing.SectionCount != AffectedSections.Length) )
			{
				AffectedSections = new bool[wing.SectionCount];
			}
		}
	}

	public void OnGUI()
	{
//		GUI.Label (new Rect (10, 10, 500, 500), "" + input);
	}
}
