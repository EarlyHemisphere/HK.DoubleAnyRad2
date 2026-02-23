using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ModCommon.Util;
using Modding;
using UnityEngine;

namespace DoubleAnyRad2 {
	internal class DoubleAnyRadControl : MonoBehaviour {
		private GameObject abs;
		private GameObject abs2;
		private GameObject _spikeMaster;
		private GameObject _spikeTemplate;
		private GameObject _spikeClone;
		private GameObject _spikeClone2;
		private GameObject _spikeClone3;
		private GameObject _spikeClone4;
		private GameObject _spikeClone5;
		private List<GameObject> _spikeGroup0 = new List<GameObject>();
		private List<GameObject> _spikeGroup1 = new List<GameObject>();
		private List<GameObject> _spikeGroup2 = new List<GameObject>();
		private List<GameObject> _spikeGroup3 = new List<GameObject>();
		private List<GameObject> _spikeGroup4 = new List<GameObject>();
		private List<GameObject> _spikeGroup5 = new List<GameObject>();
		private List<GameObject> _spikeGroup6 = new List<GameObject>();
		private List<GameObject> _spikeGroup7 = new List<GameObject>();
		private List<GameObject> _spikeGroup8 = new List<GameObject>();
		private List<GameObject> _spikeGroup9 = new List<GameObject>();
		private List<GameObject> _spikeGroup10 = new List<GameObject>();
		private List<GameObject> _spikeGroup11 = new List<GameObject>();
		private List<GameObject> _spikeGroup12 = new List<GameObject>();
		private List<GameObject> _spikeGroup13 = new List<GameObject>();
		private List<GameObject> _spikeGroup14 = new List<GameObject>();
		private List<GameObject> _spikeGroup15 = new List<GameObject>();
		private List<GameObject> _spikeGroup16 = new List<GameObject>();
		private List<GameObject> _spikeGroup17 = new List<GameObject>();
		private List<GameObject> _spikeGroup18 = new List<GameObject>();
		private List<GameObject> _spikeGroup19 = new List<GameObject>();
		private List<GameObject> _spikeGroup20 = new List<GameObject>();
		private List<GameObject> _spikeGroup21 = new List<GameObject>();
		private List<GameObject> _spikeGroup22 = new List<GameObject>();
		private List<GameObject> _spikeGroup23 = new List<GameObject>();
		public GameObject _beamsweeper;
		public GameObject _beamsweeper2;
		public GameObject _beamsweeper3;
		public GameObject _beamsweeper4;
		private PlayMakerFSM _attackChoices;
		private PlayMakerFSM _attackChoices2;
		private PlayMakerFSM _attackCommands;
		private PlayMakerFSM _attackCommands2;
		private PlayMakerFSM _control;
		private PlayMakerFSM _control2;
		private PlayMakerFSM _phaseControl;
		private PlayMakerFSM _phaseControl2;
		private PlayMakerFSM _spikeMasterControl;
		private PlayMakerFSM _beamsweepercontrol;
		private PlayMakerFSM _beamsweeper2control;
		private PlayMakerFSM _beamsweeper3control;
		private PlayMakerFSM _beamsweeper4control;
		private int CWRepeats = 0;
		private int CWRepeats2 = 0;
		private bool fullSpikesSet = false;
		private bool arena2Set = false;
		private bool onePlatSet = false;
		private int damageDealt = 0;
		private bool flagP2 = false;
		private bool flagP3 = false;
		private bool flagP4 = false;
		private bool flagP5 = false;
		private bool flagDie = false;
		private bool flag2 = false;
		private bool endFlag = false;

		private void Start() {
			abs = GameObject.Find("Absolute Radiance");
			abs2 = Instantiate(abs);

			_attackChoices = abs.LocateMyFSM("Attack Choices");
			_attackChoices2 = abs2.LocateMyFSM("Attack Choices");
			_attackCommands = abs.LocateMyFSM("Attack Commands");
			_attackCommands2 = abs2.LocateMyFSM("Attack Commands");
			_control = abs.LocateMyFSM("Control");
			_control2 = abs2.LocateMyFSM("Control");
			_phaseControl = abs.LocateMyFSM("Phase Control");
			_phaseControl2 = abs2.LocateMyFSM("Phase Control");
			_spikeMaster = GameObject.Find("Spike Control");
			_spikeMasterControl = _spikeMaster.LocateMyFSM("Control");
			_spikeTemplate = GameObject.Find("Radiant Spike");
			_beamsweeper = GameObject.Find("Beam Sweeper");
			_beamsweeper2 = UnityEngine.Object.Instantiate(_beamsweeper);
			_beamsweeper2.AddComponent<BeamSweeperClone>();
			_beamsweepercontrol = _beamsweeper.LocateMyFSM("Control");
			_beamsweeper2control = _beamsweeper2.LocateMyFSM("Control");
			_beamsweeper3 = UnityEngine.Object.Instantiate(_beamsweeper);
			_beamsweeper3.AddComponent<BeamSweeperClone>();
			_beamsweeper3control = _beamsweeper3.LocateMyFSM("Control");
			_beamsweeper4 = UnityEngine.Object.Instantiate(_beamsweeper);
			_beamsweeper4.AddComponent<BeamSweeperClone>();
			_beamsweeper4control = _beamsweeper4.LocateMyFSM("Control");
			_control.GetAction<SetHP>("Scream", 7).hp = 20000;
			_control2.GetAction<SetHP>("Scream", 7).hp = 20000;

			Log("Changing fight variables...");
			Material[] materials = abs.GetComponent<tk2dSprite>().Collection.materials;
			int num = 0;
			Material[] array = materials;
			foreach (Material material in array)
			{
				try
				{
					material.mainTexture = global::DoubleAnyRad2.DoubleAnyRad2.Sprites[num].texture;
					num++;
				}
				catch (Exception)
				{
				}
			}
			_spikeClone = UnityEngine.Object.Instantiate(_spikeTemplate);
			_spikeClone.transform.SetPositionX(58f);
			_spikeClone.transform.SetPositionY(153.8f);
			_spikeClone.GetComponent<DamageHero>().damageDealt = 2;
			_spikeClone.GetComponent<DamageHero>().hazardType = 0;
			_spikeClone2 = UnityEngine.Object.Instantiate(_spikeTemplate);
			_spikeClone2.transform.SetPositionX(57.5f);
			_spikeClone2.transform.SetPositionY(153.8f);
			_spikeClone.GetComponent<DamageHero>().damageDealt = 2;
			_spikeClone.GetComponent<DamageHero>().hazardType = 0;
			_spikeClone3 = UnityEngine.Object.Instantiate(_spikeTemplate);
			_spikeClone3.transform.SetPositionX(57f);
			_spikeClone3.transform.SetPositionY(153.8f);
			_spikeClone.GetComponent<DamageHero>().damageDealt = 2;
			_spikeClone.GetComponent<DamageHero>().hazardType = 0;
			_spikeClone4 = UnityEngine.Object.Instantiate(_spikeTemplate);
			_spikeClone4.transform.SetPositionX(58.5f);
			_spikeClone4.transform.SetPositionY(153.8f);
			_spikeClone.GetComponent<DamageHero>().damageDealt = 2;
			_spikeClone.GetComponent<DamageHero>().hazardType = 0;
			_spikeClone5 = UnityEngine.Object.Instantiate(_spikeTemplate);
			_spikeClone5.transform.SetPositionX(59f);
			_spikeClone5.transform.SetPositionY(153.8f);
			_spikeClone.GetComponent<DamageHero>().damageDealt = 2;
			_spikeClone.GetComponent<DamageHero>().hazardType = 0;
			foreach (Transform item in _spikeMaster.transform)
			{
				GameObject gameObject = item.gameObject;
				Log("Child Name: " + gameObject.name);
				try
				{
					foreach (Transform item2 in gameObject.transform)
					{
						GameObject gameObject2 = item2.gameObject;
						Log("Grandchild name: " + gameObject2.name);
						gameObject2.GetComponent<DamageHero>().damageDealt = 2;
						gameObject2.GetComponent<DamageHero>().hazardType = 0;
					}
				}
				catch (Exception)
				{
				}
			}
			for (float num2 = 58.5f; num2 <= 62.5f; num2 += 1f)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num2, 34.7f), Quaternion.identity);
				gameObject3.GetComponent<DamageHero>().damageDealt = 2;
				gameObject3.GetComponent<DamageHero>().hazardType = 0;
				gameObject3.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup0.Add(gameObject3);
			}
			for (float num3 = 49.7f; num3 <= 53.7f; num3 += 1f)
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num3, 37.6f), Quaternion.identity);
				gameObject4.GetComponent<DamageHero>().damageDealt = 2;
				gameObject4.GetComponent<DamageHero>().hazardType = 0;
				gameObject4.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup1.Add(gameObject4);
			}
			for (float num4 = 41.4f; num4 <= 43.4f; num4 += 1f)
			{
				GameObject gameObject5 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num4, 36.7f), Quaternion.identity);
				gameObject5.GetComponent<DamageHero>().damageDealt = 2;
				gameObject5.GetComponent<DamageHero>().hazardType = 0;
				gameObject5.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup2.Add(gameObject5);
			}
			for (float num5 = 46.2f; num5 <= 48.2f; num5 += 1f)
			{
				GameObject gameObject6 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num5, 43.7f), Quaternion.identity);
				gameObject6.GetComponent<DamageHero>().damageDealt = 2;
				gameObject6.GetComponent<DamageHero>().hazardType = 0;
				gameObject6.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup3.Add(gameObject6);
			}
			for (float num6 = 57.6f; num6 <= 61.6f; num6 += 1f)
			{
				GameObject gameObject7 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num6, 45.9f), Quaternion.identity);
				gameObject7.GetComponent<DamageHero>().damageDealt = 2;
				gameObject7.GetComponent<DamageHero>().hazardType = 0;
				gameObject7.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup4.Add(gameObject7);
			}
			for (float num7 = 66.8f; num7 <= 68.8f; num7 += 1f)
			{
				GameObject gameObject8 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num7, 39.1f), Quaternion.identity);
				gameObject8.GetComponent<DamageHero>().damageDealt = 2;
				gameObject8.GetComponent<DamageHero>().hazardType = 0;
				gameObject8.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup5.Add(gameObject8);
			}
			for (float num8 = 71.7f; (double)num8 <= 73.7; num8 += 1f)
			{
				GameObject gameObject9 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num8, 45.1f), Quaternion.identity);
				gameObject9.GetComponent<DamageHero>().damageDealt = 2;
				gameObject9.GetComponent<DamageHero>().hazardType = 0;
				gameObject9.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup6.Add(gameObject9);
			}
			for (float num9 = 57.5f; num9 <= 61.5f; num9 += 1f)
			{
				GameObject gameObject10 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num9, 45.9f), Quaternion.identity);
				gameObject10.GetComponent<DamageHero>().damageDealt = 2;
				gameObject10.GetComponent<DamageHero>().hazardType = 0;
				gameObject10.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup7.Add(gameObject10);
			}
			for (float num10 = 61.6f; num10 <= 65.6f; num10 += 1f)
			{
				GameObject gameObject11 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num10, 51.8f), Quaternion.identity);
				gameObject11.GetComponent<DamageHero>().damageDealt = 2;
				gameObject11.GetComponent<DamageHero>().hazardType = 0;
				gameObject11.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup8.Add(gameObject11);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(63.3f, 49.6f), Quaternion.identity).SetActive(value: true);
			for (int j = 57; j <= 59; j++)
			{
				GameObject gameObject12 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(j, 58.2f), Quaternion.identity);
				gameObject12.GetComponent<DamageHero>().damageDealt = 2;
				gameObject12.GetComponent<DamageHero>().hazardType = 0;
				gameObject12.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup9.Add(gameObject12);
			}
			for (float num11 = 63.2f; num11 <= 65.2f; num11 += 1f)
			{
				GameObject gameObject13 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num11, 64.1f), Quaternion.identity);
				gameObject13.GetComponent<DamageHero>().damageDealt = 2;
				gameObject13.GetComponent<DamageHero>().hazardType = 0;
				gameObject13.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup10.Add(gameObject13);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(64.24f, 61.46f), Quaternion.identity).SetActive(value: true);
			for (float num12 = 64.7f; num12 <= 66.7f; num12 += 1f)
			{
				GameObject gameObject14 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num12, 70.8f), Quaternion.identity);
				gameObject14.GetComponent<DamageHero>().damageDealt = 2;
				gameObject14.GetComponent<DamageHero>().hazardType = 0;
				gameObject14.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup11.Add(gameObject14);
			}
			for (float num13 = 57.2f; num13 <= 61.2f; num13 += 1f)
			{
				GameObject gameObject15 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num13, 77.2f), Quaternion.identity);
				gameObject15.GetComponent<DamageHero>().damageDealt = 2;
				gameObject15.GetComponent<DamageHero>().hazardType = 0;
				gameObject15.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup12.Add(gameObject15);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(58.93f, 75.07f), Quaternion.identity).SetActive(value: true);
			for (float num14 = 55.4f; num14 <= 57.4f; num14 += 1f)
			{
				GameObject gameObject16 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num14, 84.7f), Quaternion.identity);
				gameObject16.GetComponent<DamageHero>().damageDealt = 2;
				gameObject16.GetComponent<DamageHero>().hazardType = 0;
				gameObject16.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup13.Add(gameObject16);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(56.32f, 82.04f), Quaternion.identity).SetActive(value: true);
			for (float num15 = 58.9f; num15 <= 60.9f; num15 += 1f)
			{
				GameObject gameObject17 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num15, 89.2f), Quaternion.identity);
				gameObject17.GetComponent<DamageHero>().damageDealt = 2;
				gameObject17.GetComponent<DamageHero>().hazardType = 0;
				gameObject17.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup14.Add(gameObject17);
			}
			_spikeGroup14.Add(GameObject.Find("Ascend Set/Radiant Plat Small (6)"));
			for (float num16 = 61.1f; num16 <= 65.1f; num16 += 1f)
			{
				GameObject gameObject18 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num16, 94.4f), Quaternion.identity);
				gameObject18.GetComponent<DamageHero>().damageDealt = 2;
				gameObject18.GetComponent<DamageHero>().hazardType = 0;
				gameObject18.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup15.Add(gameObject18);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(63.14f, 92.8f), Quaternion.identity).SetActive(value: true);
			for (float num17 = 57.2f; num17 <= 59.2f; num17 += 1f)
			{
				GameObject gameObject19 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num17, 101.1f), Quaternion.identity);
				gameObject19.GetComponent<DamageHero>().damageDealt = 2;
				gameObject19.GetComponent<DamageHero>().hazardType = 0;
				gameObject19.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup16.Add(gameObject19);
			}
			for (float num18 = 63.3f; num18 <= 65.3f; num18 += 1f)
			{
				GameObject gameObject20 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num18, 107.4f), Quaternion.identity);
				gameObject20.GetComponent<DamageHero>().damageDealt = 2;
				gameObject20.GetComponent<DamageHero>().hazardType = 0;
				gameObject20.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup17.Add(gameObject20);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(64.24f, 104.7f), Quaternion.identity).SetActive(value: true);
			for (float num19 = 64.6f; num19 <= 66.6f; num19 += 1f)
			{
				GameObject gameObject21 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num19, 113.7f), Quaternion.identity);
				gameObject21.GetComponent<DamageHero>().damageDealt = 2;
				gameObject21.GetComponent<DamageHero>().hazardType = 0;
				gameObject21.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup18.Add(gameObject21);
			}
			for (float num20 = 57.2f; num20 <= 61.2f; num20 += 1f)
			{
				GameObject gameObject22 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num20, 120.5f), Quaternion.identity);
				gameObject22.GetComponent<DamageHero>().damageDealt = 2;
				gameObject22.GetComponent<DamageHero>().hazardType = 0;
				gameObject22.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup19.Add(gameObject22);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(58.93f, 118.3f), Quaternion.identity).SetActive(value: true);
			for (float num21 = 55.3f; num21 <= 57.3f; num21 += 1f)
			{
				GameObject gameObject23 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num21, 128.4f), Quaternion.identity);
				gameObject23.GetComponent<DamageHero>().damageDealt = 2;
				gameObject23.GetComponent<DamageHero>().hazardType = 0;
				gameObject23.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup20.Add(gameObject23);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(56.32f, 125.74f), Quaternion.identity).SetActive(value: true);
			for (int k = 59; k <= 61; k++)
			{
				GameObject gameObject24 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(k, 133.4f), Quaternion.identity);
				gameObject24.GetComponent<DamageHero>().damageDealt = 2;
				gameObject24.GetComponent<DamageHero>().hazardType = 0;
				gameObject24.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup21.Add(gameObject24);
			}
			for (float num22 = 61.3f; num22 <= 65.3f; num22 += 1f)
			{
				GameObject gameObject25 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num22, 139.2f), Quaternion.identity);
				gameObject25.GetComponent<DamageHero>().damageDealt = 2;
				gameObject25.GetComponent<DamageHero>().hazardType = 0;
				gameObject25.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup22.Add(gameObject25);
			}
			UnityEngine.Object.Instantiate(GameObject.Find("Ascend Set/Radiant Plat Small (4)"), new Vector2(63.14f, 137.03f), Quaternion.identity).SetActive(value: true);
			for (float num23 = 61.8f; num23 <= 63.8f; num23 += 1f)
			{
				GameObject gameObject26 = UnityEngine.Object.Instantiate(_spikeTemplate, new Vector2(num23, 146.5f), Quaternion.identity);
				gameObject26.GetComponent<DamageHero>().damageDealt = 2;
				gameObject26.GetComponent<DamageHero>().hazardType = 0;
				gameObject26.LocateMyFSM("Control").SendEvent("DOWN");
				_spikeGroup23.Add(gameObject26);
			}
			Log("Modifying Orbs");
			_attackCommands.GetAction<SetIntValue>("Orb Antic", 1).intValue = 10;
			_attackCommands.GetAction<RandomInt>("Orb Antic", 2).min = 8;
			_attackCommands.GetAction<RandomInt>("Orb Antic", 2).max = 12;
			_attackCommands.GetAction<Wait>("Orb Summon", 2).time = 0.1f;
			_attackCommands.GetAction<Wait>("Orb Pause", 0).time = 0.1f;
			_attackChoices.GetAction<Wait>("Orb Recover", 0).time = 0.5f;
			_attackCommands.GetAction<Wait>("Orb Antic", 0).time.Value = 0.01f;
			_attackCommands2.GetAction<SetIntValue>("Orb Antic", 1).intValue = 10;
			_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).min = 8;
			_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).max = 12;
			_attackCommands2.GetAction<Wait>("Orb Summon", 2).time = 0.1f;
			_attackCommands2.GetAction<Wait>("Orb Pause", 0).time = 0.1f;
			_attackChoices2.GetAction<Wait>("Orb Recover", 0).time = 0.5f;
			_attackCommands2.GetAction<Wait>("Orb Antic", 0).time.Value = 0.01f;
			Log("Modifying Nail Fan");
			_attackCommands.GetAction<SetIntValue>("Nail Fan", 4).intValue.Value = 24;
			_attackCommands.GetAction<Wait>("Nail Fan", 2).time.Value = 0.01f;
			_attackCommands.GetAction<SetIntValue>("CW Restart", 0).intValue.Value = 24;
			_attackCommands.GetAction<SetIntValue>("CCW Restart", 0).intValue.Value = 24;
			_attackCommands.GetAction<Wait>("CW Repeat", 0).time = 0.001f;
			_attackCommands.GetAction<Wait>("CCW Repeat", 0).time = 0.001f;
			_attackCommands.GetAction<FloatAdd>("CW Restart", 2).add.Value = -7.5f;
			_attackCommands.GetAction<FloatAdd>("CCW Restart", 2).add.Value = 7.5f;
			_attackCommands.RemoveAction("CW Restart", 1);
			_attackCommands.RemoveAction("CCW Restart", 1);
			_attackCommands.RemoveAction("CW Repeat", 0);
			_attackCommands.RemoveAction("CCW Repeat", 0);
			_attackCommands.GetAction<FloatAdd>("CW Spawn", 2).add.Value = -15f;
			_attackCommands.GetAction<FloatAdd>("CCW Spawn", 2).add.Value = 15f;
			_attackCommands2.GetAction<SetIntValue>("Nail Fan", 4).intValue.Value = 24;
			_attackCommands2.GetAction<Wait>("Nail Fan", 2).time.Value = 0.01f;
			_attackCommands2.GetAction<SetIntValue>("CW Restart", 0).intValue.Value = 24;
			_attackCommands2.GetAction<SetIntValue>("CCW Restart", 0).intValue.Value = 24;
			_attackCommands2.GetAction<Wait>("CW Repeat", 0).time = 0.001f;
			_attackCommands2.GetAction<Wait>("CCW Repeat", 0).time = 0.001f;
			_attackCommands2.GetAction<FloatAdd>("CW Restart", 2).add.Value = -7.5f;
			_attackCommands2.GetAction<FloatAdd>("CCW Restart", 2).add.Value = 7.5f;
			_attackCommands2.RemoveAction("CW Restart", 1);
			_attackCommands2.RemoveAction("CCW Restart", 1);
			_attackCommands2.RemoveAction("CW Repeat", 0);
			_attackCommands2.RemoveAction("CCW Repeat", 0);
			_attackCommands2.GetAction<FloatAdd>("CW Spawn", 2).add.Value = -15f;
			_attackCommands2.GetAction<FloatAdd>("CCW Spawn", 2).add.Value = 15f;
			Log("Fixing nail fan pool sharing between bosses");
			GameObject nailPrefab = _attackCommands.GetAction<SpawnObjectFromGlobalPool>("CW Spawn", 0).gameObject.Value;
			GameObject nailPrefabBoss1 = UnityEngine.Object.Instantiate(nailPrefab);
			nailPrefabBoss1.name = "Radiant Nail Boss1";
			nailPrefabBoss1.SetActive(false);
			ObjectPool.CreatePool(nailPrefabBoss1, 500);
			_attackCommands.GetAction<SpawnObjectFromGlobalPool>("CW Spawn", 0).gameObject.Value = nailPrefabBoss1;
			_attackCommands.GetAction<SpawnObjectFromGlobalPool>("CCW Spawn", 0).gameObject.Value = nailPrefabBoss1;
			GameObject nailPrefabBoss2 = UnityEngine.Object.Instantiate(nailPrefab);
			nailPrefabBoss2.name = "Radiant Nail Boss2";
			nailPrefabBoss2.SetActive(false);
			ReplaceFsmEvent(nailPrefabBoss2, "FAN ATTACK CW", "FAN ATTACK CW 2");
			ReplaceFsmEvent(nailPrefabBoss2, "FAN ATTACK CCW", "FAN ATTACK CCW 2");
			ObjectPool.CreatePool(nailPrefabBoss2, 500);
			_attackCommands2.GetAction<SpawnObjectFromGlobalPool>("CW Spawn", 0).gameObject.Value = nailPrefabBoss2;
			_attackCommands2.GetAction<SpawnObjectFromGlobalPool>("CCW Spawn", 0).gameObject.Value = nailPrefabBoss2;
			_attackCommands2.GetAction<SendEventByName>("CW Fire", 0).sendEvent = "FAN ATTACK CW 2";
			_attackCommands2.GetAction<SendEventByName>("CCW Fire", 0).sendEvent = "FAN ATTACK CCW 2";
			Log("Modifying Beam Sweep");
			FsmEventTarget bs1target = new FsmEventTarget();
			bs1target.target = FsmEventTarget.EventTarget.GameObject;
			bs1target.excludeSelf = false;
			bs1target.gameObject = new FsmOwnerDefault();
			bs1target.gameObject.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
			bs1target.gameObject.GameObject.Value = _beamsweeper;
			bs1target.sendToChildren = true;
			FsmEventTarget bs2target = new FsmEventTarget();
			bs2target.target = FsmEventTarget.EventTarget.GameObject;
			bs2target.excludeSelf = false;
			bs2target.gameObject = new FsmOwnerDefault();
			bs2target.gameObject.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
			bs2target.gameObject.GameObject.Value = _beamsweeper2;
			bs2target.sendToChildren = true;
			FsmEventTarget bs3target = new FsmEventTarget();
			bs3target.target = FsmEventTarget.EventTarget.GameObject;
			bs3target.excludeSelf = false;
			bs3target.gameObject = new FsmOwnerDefault();
			bs3target.gameObject.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
			bs3target.gameObject.GameObject.Value = _beamsweeper3;
			bs3target.sendToChildren = true;
			FsmEventTarget bs4target = new FsmEventTarget();
			bs4target.target = FsmEventTarget.EventTarget.GameObject;
			bs4target.excludeSelf = false;
			bs4target.gameObject = new FsmOwnerDefault();
			bs4target.gameObject.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
			bs4target.gameObject.GameObject.Value = _beamsweeper4;
			bs4target.sendToChildren = true;
			_attackChoices.RemoveAction("Beam Sweep L", 1);
			_attackChoices.RemoveAction("Beam Sweep R", 1);
			_attackChoices.RemoveAction("Beam Sweep L 2", 1);
			_attackChoices.RemoveAction("Beam Sweep R 2", 1);
			_attackChoices.AddAction("Beam Sweep L", new SendEventByName{
				eventTarget = bs1target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep L", new SendEventByName{
				eventTarget = bs2target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep R", new SendEventByName{
				eventTarget = bs1target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep R", new SendEventByName{
				eventTarget = bs2target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep L 2", new SendEventByName{
				eventTarget = bs1target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep L 2", new SendEventByName{
				eventTarget = bs2target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep R 2", new SendEventByName{
				eventTarget = bs1target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.AddAction("Beam Sweep R 2", new SendEventByName{
				eventTarget = bs2target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices.GetAction<Wait>("Beam Sweep L", 0).time.Value = 0.01f;
			_attackChoices.GetAction<Wait>("Beam Sweep R", 0).time.Value = 0.01f;
			_attackChoices.GetAction<Wait>("Beam Sweep L 2", 0).time.Value = 5.05f;
			_attackChoices.GetAction<Wait>("Beam Sweep R 2", 0).time.Value = 5.05f;
			_attackChoices2.RemoveAction("Beam Sweep L", 1);
			_attackChoices2.RemoveAction("Beam Sweep R", 1);
			_attackChoices2.RemoveAction("Beam Sweep L 2", 1);
			_attackChoices2.RemoveAction("Beam Sweep R 2", 1);
			_attackChoices2.AddAction("Beam Sweep L", new SendEventByName{
				eventTarget = bs3target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep L", new SendEventByName{
				eventTarget = bs4target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep R", new SendEventByName{
				eventTarget = bs3target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep R", new SendEventByName{
				eventTarget = bs4target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep L 2", new SendEventByName{
				eventTarget = bs3target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep L 2", new SendEventByName{
				eventTarget = bs4target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep R 2", new SendEventByName{
				eventTarget = bs3target,
				sendEvent = "BEAM SWEEP R",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.AddAction("Beam Sweep R 2", new SendEventByName{
				eventTarget = bs4target,
				sendEvent = "BEAM SWEEP L",
				everyFrame = false,
				delay = 0
			});
			_attackChoices2.GetAction<Wait>("Beam Sweep L", 0).time.Value = 0.01f;
			_attackChoices2.GetAction<Wait>("Beam Sweep R", 0).time.Value = 0.01f;
			_attackChoices2.GetAction<Wait>("Beam Sweep L 2", 0).time.Value = 5.05f;
			_attackChoices2.GetAction<Wait>("Beam Sweep R 2", 0).time.Value = 5.05f;
			Log("Modifying Radial Beam");
			_attackCommands.GetAction<SendEventByName>("EB 1", 9).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 1", 10).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 2", 9).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 2", 10).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 3", 9).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 3", 10).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 4", 4).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 4", 5).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 5", 5).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 5", 6).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 6", 5).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 6", 6).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 7", 8).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 7", 9).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 8", 8).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 8", 9).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("EB 9", 8).delay.Value = 0.3f;
			_attackCommands.GetAction<Wait>("EB 9", 9).time.Value = 0.5f;
			_attackCommands.GetAction<SendEventByName>("Aim", 10).delay.Value = 1f;
			_attackCommands.GetAction<Wait>("Aim", 11).time.Value = 0.5f;
			_attackCommands.GetAction<Wait>("Eb Extra Wait", 0).time.Value = 0.01f;
			_attackCommands.GetAction<Wait>("EB Glow End", 1).time.Value = 0.01f;
			_attackCommands.GetAction<Wait>("EB Glow End 2", 1).time.Value = 0.01f;
			_attackCommands2.GetAction<SendEventByName>("EB 1", 9).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 1", 10).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 2", 9).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 2", 10).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 3", 9).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 3", 10).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 4", 4).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 4", 5).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 5", 5).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 5", 6).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 6", 5).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 6", 6).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 7", 8).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 7", 9).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 8", 8).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 8", 9).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("EB 9", 8).delay.Value = 0.3f;
			_attackCommands2.GetAction<Wait>("EB 9", 9).time.Value = 0.5f;
			_attackCommands2.GetAction<SendEventByName>("Aim", 10).delay.Value = 1f;
			_attackCommands2.GetAction<Wait>("Aim", 11).time.Value = 0.5f;
			_attackCommands2.GetAction<Wait>("Eb Extra Wait", 0).time.Value = 0.01f;
			_attackCommands2.GetAction<Wait>("EB Glow End", 1).time.Value = 0.01f;
			_attackCommands2.GetAction<Wait>("EB Glow End 2", 1).time.Value = 0.01f;
			Log("Modifying Vertical Nail Comb");
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep", 1).delay.Value = 0.25f;
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep", 2).delay.Value = 0.5f;
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep", 3).delay.Value = 0.75f;
			_attackChoices.GetAction<Wait>("Nail Top Sweep", 4).time.Value = 1f;
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep 2", 1).delay.Value = 1.25f;
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep 2", 2).delay.Value = 1.5f;
			_attackChoices.GetAction<SendEventByName>("Nail Top Sweep 2", 3).delay.Value = 1.75f;
			_attackChoices.GetAction<Wait>("Nail Top Sweep 2", 4).time.Value = 1f;
			_control.GetAction<Wait>("Rage Comb", 0).time.Value = 0.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep", 1).delay.Value = 0.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep", 2).delay.Value = 0.5f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep", 3).delay.Value = 0.75f;
			_attackChoices2.GetAction<Wait>("Nail Top Sweep", 4).time.Value = 1f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep 2", 1).delay.Value = 1.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep 2", 2).delay.Value = 1.5f;
			_attackChoices2.GetAction<SendEventByName>("Nail Top Sweep 2", 3).delay.Value = 1.75f;
			_attackChoices2.GetAction<Wait>("Nail Top Sweep 2", 4).time.Value = 1f;
			_control2.GetAction<Wait>("Rage Comb", 0).time.Value = 0.25f;
			Log("Modifying Horizontal Nail Comb");
			_attackChoices.GetAction<SendEventByName>("Nail L Sweep", 1).delay = 0.25f;
			_attackChoices.GetAction<SendEventByName>("Nail L Sweep", 1).delay = 1.25f;
			_attackChoices.GetAction<SendEventByName>("Nail L Sweep", 2).delay = 2.25f;
			_attackChoices.GetAction<Wait>("Nail L Sweep", 3).time = 3.5f;
			_attackChoices.GetAction<SendEventByName>("Nail R Sweep", 1).delay = 0.25f;
			_attackChoices.GetAction<SendEventByName>("Nail R Sweep", 1).delay = 1.25f;
			_attackChoices.GetAction<SendEventByName>("Nail R Sweep", 2).delay = 2.25f;
			_attackChoices.GetAction<Wait>("Nail R Sweep", 3).time = 3.5f;
			_attackChoices2.GetAction<SendEventByName>("Nail L Sweep", 1).delay = 0.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail L Sweep", 1).delay = 1.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail L Sweep", 2).delay = 2.25f;
			_attackChoices2.GetAction<Wait>("Nail L Sweep", 3).time = 3.5f;
			_attackChoices2.GetAction<SendEventByName>("Nail R Sweep", 1).delay = 0.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail R Sweep", 1).delay = 1.25f;
			_attackChoices2.GetAction<SendEventByName>("Nail R Sweep", 2).delay = 2.25f;
			_attackChoices2.GetAction<Wait>("Nail R Sweep", 3).time = 3.5f;
			AddNailWall("Nail L Sweep", "COMB R", 1f, 1);
			AddNailWall("Nail R Sweep", "COMB L", 1f, 1);
			AddNailWall("Nail L Sweep", "COMB R", 2f, 1);
			AddNailWall("Nail R Sweep", "COMB L", 2f, 1);
			AddNailWall("Nail L Sweep 2", "COMB R2", 1f, 1);
			AddNailWall("Nail R Sweep 2", "COMB L2", 1f, 1);
			AddNailWall2("Nail L Sweep", "COMB R", 1f, 1);
			AddNailWall2("Nail R Sweep", "COMB L", 1f, 1);
			AddNailWall2("Nail L Sweep", "COMB R", 2f, 1);
			AddNailWall2("Nail R Sweep", "COMB L", 2f, 1);
			AddNailWall2("Nail L Sweep 2", "COMB R2", 1f, 1);
			AddNailWall2("Nail R Sweep 2", "COMB L2", 1f, 1);

			On.HealthManager.TakeDamage += KnightHit;
			StartCoroutine(Init());

			Log("fin.");
			Log("You are going to lose. Unless you have a large amount of lifeblood.");
		}

		private void KnightHit(On.HealthManager.orig_TakeDamage orig, HealthManager self, HitInstance hitInstance) {
			orig(self, hitInstance);
			damageDealt += hitInstance.DamageDealt;
		}

		private IEnumerator Init() {
			yield return new WaitForSeconds(2f);
			
			abs.GetComponent<HealthManager>().hp = 999999;
			abs2.GetComponent<HealthManager>().hp = 999999;

			flagP2 = false;
			flagP3 = false;
			flagP4 = false;
			flagP5 = false;
			flagDie = false;
			flag2 = false;
			endFlag = false;
		}

		private void Update()
		{
			if (_attackCommands.FsmVariables.GetFsmBool("Repeated").Value)
			{
				switch (CWRepeats)
				{
				case 0:
					CWRepeats = 1;
					_attackCommands.FsmVariables.GetFsmBool("Repeated").Value = false;
					break;
				case 1:
					CWRepeats = 2;
					_attackCommands.FsmVariables.GetFsmBool("Repeated").Value = false;
					break;
				case 2:
					_attackCommands.FsmVariables.GetFsmBool("Repeated").Value = false;
					CWRepeats = 3;
					break;
				case 3:
					CWRepeats = 4;
					break;
				}
			}
			else if (CWRepeats == 4)
			{
				CWRepeats = 0;
			}
			if (_attackCommands2.FsmVariables.GetFsmBool("Repeated").Value)
			{
				switch (CWRepeats2)
				{
				case 0:
					CWRepeats2 = 1;
					_attackCommands2.FsmVariables.GetFsmBool("Repeated").Value = false;
					break;
				case 1:
					CWRepeats2 = 2;
					_attackCommands2.FsmVariables.GetFsmBool("Repeated").Value = false;
					break;
				case 2:
					_attackCommands2.FsmVariables.GetFsmBool("Repeated").Value = false;
					CWRepeats2 = 3;
					break;
				case 3:
					CWRepeats2 = 4;
					break;
				}
			}
			else if (CWRepeats2 == 4)
			{
				CWRepeats2 = 0;
			}
			_spikeClone.LocateMyFSM("Control").SendEvent("UP");
			_spikeClone2.LocateMyFSM("Control").SendEvent("UP");
			_spikeClone3.LocateMyFSM("Control").SendEvent("UP");
			_spikeClone4.LocateMyFSM("Control").SendEvent("UP");
			_spikeClone5.LocateMyFSM("Control").SendEvent("UP");
			if (_beamsweepercontrol.ActiveStateName == _beamsweeper2control.ActiveStateName){
				string activeStateName = _beamsweepercontrol.ActiveStateName;
				string text = activeStateName;
				if (text != null)
				{
					if (!(text == "Beam Sweep L"))
					{
						if (text == "Beam Sweep R")
						{
							_beamsweeper2control.SendEvent("BEAM SWEEP L");
						}
					}
					else
					{
						_beamsweeper2control.SendEvent("BEAM SWEEP R");
					}
				}
			}
			if (_beamsweeper3control.ActiveStateName == _beamsweeper4control.ActiveStateName){
				string activeStateName = _beamsweeper3control.ActiveStateName;
				string text = activeStateName;
				if (text != null)
				{
					if (!(text == "Beam Sweep L"))
					{
						if (text == "Beam Sweep R")
						{
							_beamsweeper4control.SendEvent("BEAM SWEEP L");
						}
					}
					else
					{
						_beamsweeper4control.SendEvent("BEAM SWEEP R");
					}
				}
			}
			if (damageDealt >= 800 && damageDealt < 2700) {
				if (!flagP2) {
					_phaseControl.SetState("Set Phase 2");
					_phaseControl2.SetState("Set Phase 2");
					flagP2 = true;
				}
			} else if (damageDealt >= 2700 && damageDealt < 4300) {
				if (!flagP3) {
					_phaseControl.SetState("Set Phase 3");
					_phaseControl2.SetState("Set Phase 3");
					flagP3 = true;
				}
			} else if (damageDealt >= 4300 && damageDealt < 7800) {
				if (!flagP4) {
					_phaseControl.SetState("Stun 1");
					_phaseControl2.SetState("Stun 1");
					flagP4 = true;
				}
			} else if (damageDealt >= 7800 && damageDealt < 10360) {
				if (!flagP5) {
					_phaseControl.SetState("Set Ascend");
					_phaseControl2.SetState("Set Ascend");
					flagP5 = true;
				}
			} else if (damageDealt >= 10360) {
				if (!flagDie) {
					_control.Fsm.Variables.GetFsmInt("Death HP").Value = 9999999;
					_control2.Fsm.Variables.GetFsmInt("Death HP").Value = 9999999;
					flagDie = true;
				}
			}
			if (_control.ActiveStateName == "Arena 2 Start" || _control2.ActiveStateName == "Arena 2 Start") {
				if (!flag2) {
					_control.SetState("Arena 2 Start");
					_attackChoices.SetState("A1 End");
					_control2.SetState("Arena 2 Start");
					_attackChoices2.SetState("A1 End");
					flag2 = true;
				}
			}
			if (_control.ActiveStateName == "Final Impact" || _control2.ActiveStateName == "Final Impact") {
				if (!endFlag) {
					_control.SetState("Final Impact");
					_control2.SetState("Final Impact");
					endFlag = true;
				}
			}
			if (!fullSpikesSet)
			{
				fullSpikesSet = true;
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Left", 0).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Left", 1).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Left", 2).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Left", 3).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Left", 4).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Right", 0).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Right", 1).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Right", 2).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Right", 3).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Spikes Right", 4).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave L", 2).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave L", 3).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave L", 4).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave L", 5).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave L", 6).sendEvent = "UP";
				_spikeMasterControl.GetAction<WaitRandom>("Wave L", 7).timeMin = 0.1f;
				_spikeMasterControl.GetAction<WaitRandom>("Wave L", 7).timeMax = 0.1f;
				_spikeMasterControl.GetAction<SendEventByName>("Wave R", 2).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave R", 3).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave R", 4).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave R", 5).sendEvent = "UP";
				_spikeMasterControl.GetAction<SendEventByName>("Wave R", 6).sendEvent = "UP";
				_spikeMasterControl.GetAction<WaitRandom>("Wave R", 7).timeMin = 0.1f;
				_spikeMasterControl.GetAction<WaitRandom>("Wave R", 7).timeMax = 0.1f;
				_spikeMasterControl.SetState("Spike Waves");
				_attackCommands.GetAction<Wait>("Orb Summon", 2).time.Value = 0.25f;
				_attackCommands.GetAction<SetIntValue>("Orb Antic", 1).intValue.Value = 10;
				_attackCommands.GetAction<RandomInt>("Orb Antic", 2).min.Value = 8;
				_attackCommands.GetAction<RandomInt>("Orb Antic", 2).max.Value = 12;
				_attackCommands2.GetAction<Wait>("Orb Summon", 2).time.Value = 0.25f;
				_attackCommands2.GetAction<SetIntValue>("Orb Antic", 1).intValue.Value = 10;
				_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).min.Value = 8;
				_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).max.Value = 12;
			}
			if (_attackChoices.FsmVariables.GetFsmInt("Arena").Value == 2)
			{
				if (!arena2Set)
				{
					Log("Starting Arena 2");
					arena2Set = true;
					_attackCommands.GetAction<SetIntValue>("Orb Antic", 1).intValue = 10;
					_attackCommands.GetAction<RandomInt>("Orb Antic", 2).min = 8;
					_attackCommands.GetAction<RandomInt>("Orb Antic", 2).max = 12;
					_attackCommands.GetAction<Wait>("Orb Summon", 2).time = 0.25f;
					_attackCommands2.GetAction<SetIntValue>("Orb Antic", 1).intValue = 10;
					_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).min = 8;
					_attackCommands2.GetAction<RandomInt>("Orb Antic", 2).max = 12;
					_attackCommands2.GetAction<Wait>("Orb Summon", 2).time = 0.25f;
					Log("Modifying Beam Sweeper Area");
					_beamsweepercontrol.GetAction<SetPosition>("Beam Sweep L", 3).x = 89f;
					_beamsweepercontrol.GetAction<iTweenMoveBy>("Beam Sweep L", 5).vector = new Vector3(-75f, 0f, 0f);
					_beamsweepercontrol.GetAction<iTweenMoveBy>("Beam Sweep L", 5).time = 3f;
					_beamsweepercontrol.GetAction<SetPosition>("Beam Sweep R", 4).x = 32.6f;
					_beamsweepercontrol.GetAction<iTweenMoveBy>("Beam Sweep R", 6).vector = new Vector3(75f, 0f, 0f);
					_beamsweepercontrol.GetAction<iTweenMoveBy>("Beam Sweep R", 6).time = 3f;
					_beamsweeper2control.GetAction<SetPosition>("Beam Sweep L", 2).x = 89f;
					_beamsweeper2control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).vector = new Vector3(-75f, 0f, 0f);
					_beamsweeper2control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).time = 3f;
					_beamsweeper2control.GetAction<SetPosition>("Beam Sweep R", 3).x = 32.6f;
					_beamsweeper2control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).vector = new Vector3(75f, 0f, 0f);
					_beamsweeper2control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).time = 3f;
					_beamsweeper3control.GetAction<SetPosition>("Beam Sweep L", 2).x = 89f;
					_beamsweeper3control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).vector = new Vector3(-75f, 0f, 0f);
					_beamsweeper3control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).time = 3f;
					_beamsweeper3control.GetAction<SetPosition>("Beam Sweep R", 3).x = 32.6f;
					_beamsweeper3control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).vector = new Vector3(75f, 0f, 0f);
					_beamsweeper3control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).time = 3f;
					_beamsweeper4control.GetAction<SetPosition>("Beam Sweep L", 2).x = 89f;
					_beamsweeper4control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).vector = new Vector3(-75f, 0f, 0f);
					_beamsweeper4control.GetAction<iTweenMoveBy>("Beam Sweep L", 4).time = 3f;
					_beamsweeper4control.GetAction<SetPosition>("Beam Sweep R", 3).x = 32.6f;
					_beamsweeper4control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).vector = new Vector3(75f, 0f, 0f);
					_beamsweeper4control.GetAction<iTweenMoveBy>("Beam Sweep R", 5).time = 3f;
				}
				foreach (GameObject item in _spikeGroup0)
				{
					item.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item2 in _spikeGroup1)
				{
					item2.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item3 in _spikeGroup2)
				{
					item3.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item4 in _spikeGroup3)
				{
					item4.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item5 in _spikeGroup4)
				{
					item5.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item6 in _spikeGroup5)
				{
					item6.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item7 in _spikeGroup6)
				{
					item7.LocateMyFSM("Control").SendEvent("UP");
				}
				foreach (GameObject item8 in _spikeGroup7)
				{
					item8.LocateMyFSM("Control").SendEvent("UP");
				}
			}
			if (!(abs.transform.position.y >= 150f) && !(abs2.transform.position.y >= 150f))
			{
				return;
			}
			if (damageDealt >= 7800)
			{
				foreach (GameObject item9 in _spikeGroup8)
				{
					if (item9.name == "Radiant Spike(Clone)")
					{
						item9.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item10 in _spikeGroup9)
				{
					if (item10.name == "Radiant Spike(Clone)")
					{
						item10.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item11 in _spikeGroup10)
				{
					if (item11.name == "Radiant Spike(Clone)")
					{
						item11.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item12 in _spikeGroup11)
				{
					if (item12.name == "Radiant Spike(Clone)")
					{
						item12.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item13 in _spikeGroup12)
				{
					if (item13.name == "Radiant Spike(Clone)")
					{
						item13.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item14 in _spikeGroup13)
				{
					if (item14.name == "Radiant Spike(Clone)")
					{
						item14.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item15 in _spikeGroup14)
				{
					if (item15.name == "Radiant Spike(Clone)")
					{
						item15.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item16 in _spikeGroup15)
				{
					if (item16.name == "Radiant Spike(Clone)")
					{
						item16.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item17 in _spikeGroup16)
				{
					if (item17.name == "Radiant Spike(Clone)")
					{
						item17.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item18 in _spikeGroup17)
				{
					if (item18.name == "Radiant Spike(Clone)")
					{
						item18.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item19 in _spikeGroup18)
				{
					if (item19.name == "Radiant Spike(Clone)")
					{
						item19.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item20 in _spikeGroup19)
				{
					if (item20.name == "Radiant Spike(Clone)")
					{
						item20.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item21 in _spikeGroup20)
				{
					if (item21.name == "Radiant Spike(Clone)")
					{
						item21.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item22 in _spikeGroup21)
				{
					if (item22.name == "Radiant Spike(Clone)")
					{
						item22.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item23 in _spikeGroup22)
				{
					if (item23.name == "Radiant Spike(Clone)")
					{
						item23.LocateMyFSM("Control").SendEvent("UP");
					}
				}
				foreach (GameObject item24 in _spikeGroup23)
				{
					if (item24.name == "Radiant Spike(Clone)")
					{
						item24.LocateMyFSM("Control").SendEvent("UP");
					}
				}
			}
			if (damageDealt >= 7800)
			{
				GameObject.Find("Radiant Plat Small (10)").LocateMyFSM("radiant_plat").ChangeState(GetFsmEventByName(GameObject.Find("Radiant Plat Small (10)").LocateMyFSM("radiant_plat"), "SLOW VANISH"));
				if (!onePlatSet)
				{
					onePlatSet = true;
					Log("Removing upper right platform");
					_attackCommands.GetAction<Wait>("Orb Antic", 0).time.Value = 0.01f;
					_attackCommands.GetAction<Wait>("FinalOrb Pause", 0).time.Value = 0.25f;
					_attackChoices.GetAction<Wait>("Orb Recover", 0).time.Value = 0.01f;
					_attackCommands2.GetAction<Wait>("Orb Antic", 0).time.Value = 0.01f;
					_attackCommands2.GetAction<Wait>("FinalOrb Pause", 0).time.Value = 0.25f;
					_attackChoices2.GetAction<Wait>("Orb Recover", 0).time.Value = 0.01f;
				}
			}
		}

		private void AddNailWall(string stateName, string eventName, float delay, int index)
		{
			_attackChoices.InsertAction(stateName, new SendEventByName
			{
				eventTarget = _attackChoices.GetAction<SendEventByName>("Nail L Sweep", 0).eventTarget,
				sendEvent = eventName,
				delay = delay,
				everyFrame = false
			}, index);
		}

		private void AddNailWall2(string stateName, string eventName, float delay, int index)
		{
			_attackChoices2.InsertAction(stateName, new SendEventByName
			{
				eventTarget = _attackChoices2.GetAction<SendEventByName>("Nail L Sweep", 0).eventTarget,
				sendEvent = eventName,
				delay = delay,
				everyFrame = false
			}, index);
		}

		private static void ReplaceFsmEvent(GameObject obj, string oldEventName, string newEventName) {
			FsmEvent newEvent = FsmEvent.GetFsmEvent(newEventName);
			foreach (PlayMakerFSM fsm in obj.GetComponents<PlayMakerFSM>()) {
				foreach (FsmState state in fsm.FsmStates) {
					foreach (FsmTransition t in state.Transitions) {
						if (t.EventName == oldEventName) {
							t.FsmEvent = newEvent;
						}
					}
				}
				foreach (FsmTransition t in fsm.Fsm.GlobalTransitions) {
					if (t.EventName == oldEventName) {
						t.FsmEvent = newEvent;
					}
				}
			}
		}

		private static FsmEvent GetFsmEventByName(PlayMakerFSM fsm, string eventName)
		{
			FsmEvent[] fsmEvents = fsm.FsmEvents;
			foreach (FsmEvent fsmEvent in fsmEvents)
			{
				if (fsmEvent.Name == eventName)
				{
					return fsmEvent;
				}
			}
			return null;
		}

		private static void Log(object obj)
		{
			Modding.Logger.Log("[Any Radiance]: " + obj);
		}

		private void OnDestroy() {
			On.HealthManager.TakeDamage -= KnightHit;
			damageDealt = 0;
			flagP2 = false;
			flagP3 = false;
			flagP4 = false;
			flagP5 = false;
			flagDie = false;
			flag2 = false;
			endFlag = false;
		}
	}
}