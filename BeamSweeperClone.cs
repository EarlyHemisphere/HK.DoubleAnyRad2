using HutongGames.PlayMaker.Actions;
using ModCommon.Util;
using UnityEngine;

namespace DoubleAnyRad2 {
	internal class BeamSweeperClone : MonoBehaviour
	{
		private PlayMakerFSM _control;

		private void Awake() {
			DoubleAnyRad2.Instance.Log("Added BeamSweeperClone MonoBehaviour");
			_control = gameObject.LocateMyFSM("Control");
			_control.GetAction<GetOwner>("Init", 0).storeGameObject = gameObject;
		}

		private void Start() {
			_control.ChangeTransition("Idle", "BEAM SWEEP L", "Beam Sweep R"); // Cross the wires
			_control.ChangeTransition("Idle", "BEAM SWEEP R", "Beam Sweep L");
			_control.ChangeTransition("Idle", "BEAM SWEEP L 2", "Beam Sweep R 2");
			_control.ChangeTransition("Idle", "BEAM SWEEP R 2", "Beam Sweep L 2");

			_control.RemoveAction("Beam Sweep L", 0); // Ignore forced direction switches, to prevent accidental overlap
			_control.RemoveAction("Beam Sweep R", 0);
			_control.RemoveAction("Beam Sweep L 2", 0);
			_control.RemoveAction("Beam Sweep R 2", 2);
		}
	}
}