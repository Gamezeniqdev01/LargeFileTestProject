using UnityEngine;
using System.Collections;
using System.Security.AccessControl;

public class CharacterAnimSelector : MonoBehaviour
{
		public bool run, walk, dead, idle, dancing, sitting, crouch, climbingRope, shoot, walkWithGun, psycoRun, slowRun, sitOnRoad, yelling, talkingOnPhone, girlTalking, tellingSecret, hanging, NormalWalk;
		public bool _changeState;
		[HideInInspector]
		public Animator _animator;
		public Renderer _renderer;


		void Start ()
		{
				_animator = this.GetComponent<Animator> ();
				_renderer	= this.GetComponent<Renderer> ();
		}

 
		void Update ()
		{

//				if (_renderer == null || _animator == null)
//						return;

//				if (!isAnimatorEnabled && _renderer.isVisible) {
//						print ("123  " );
//						isAnimatorEnabled	= true;
//						_animator.enabled	= true;
//				} else if (isAnimatorEnabled && !_renderer.isVisible) {
//						print ("234 " + gameObject.name);
//						_animator.enabled	= false;
//						isAnimatorEnabled	= false;
//				}
				if (_changeState) {
						ChangeState ();
						_changeState = false;
				}

		}

		public void ChangeState ()
		{
				_animator.SetBool ("WithGun", walkWithGun);
				_animator.SetBool ("ClimbingRope", climbingRope);
				_animator.SetBool ("Dancing", dancing);
				_animator.SetBool ("Sitting", sitting);
				_animator.SetBool ("PsycoRun", psycoRun);
				_animator.SetBool ("TalkingOnPhone", talkingOnPhone);
				_animator.SetBool ("GirlTalking", girlTalking);
				_animator.SetBool ("TellingSecret", tellingSecret);
				_animator.SetBool ("SittingOnRoad", sitOnRoad);
				_animator.SetBool ("Yelling", yelling);
				_animator.SetBool ("Hanging", hanging);
				_animator.SetBool ("Run", run);
				_animator.SetBool ("Walk", walk);
				_animator.SetBool ("Dead", dead);
				_animator.SetBool ("Idle", idle);
				_animator.SetBool ("Crouch", crouch);
				_animator.SetBool ("Shoot", shoot);
				_animator.SetBool ("SlowRun", slowRun);
				_animator.SetBool ("NormalWalk", NormalWalk);
		}

		public void SetAllStateFalse ()
		{
				run	= false;
				walk	= false;
				dead	= false;
				idle	= false;
				dancing	= false;
				sitting	= false;
				crouch	= false;
				walkWithGun	= false;
				climbingRope	= false;
				psycoRun	= false;
				talkingOnPhone	= false;
				girlTalking	= false;
				tellingSecret	= false;
				sitOnRoad	= false;
				yelling	= false;
				hanging	= false;
				shoot	= false;
				slowRun	= false;
				NormalWalk	= false;
		}

		bool isAnimatorEnabled = false;

		//		void OnBecameInvisible ()
		//		{
		//				print ("Visible False");
		//				_animator.enabled	= false;
		//		}
		//
		//		void OnBecameVisible ()
		//		{
		//				print ("Visivle true");
		//				_animator.enabled	= true;
		//		}
}
