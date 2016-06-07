using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AvoidRevolution.Utility.Game.Manager
{
	/// <summary>
	/// ステータス設定の構造体
	/// </summary>
	[Serializable]
	public struct STATUS_SETTINGS
	{
		// HP
		public float statusHp;

		// Attack
		public float statusAttack;
	}

	/// <summary>
	/// ステータスを管理するクラス
	/// </summary>
	public class StatusManager : SingletonMonoBehaviour<StatusManager> 
	{
	}
}