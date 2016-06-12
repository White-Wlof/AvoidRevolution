using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AvoidRevolution.Utility;

namespace AvoidRevolution.Utility.Game.Manager
{
	/// <summary>
	/// スキル設定の構造体
	/// </summary>
	[Serializable]
	public struct SKILL_SETTING
	{
		// 検索・設定用のスキルID
		public int skillId;

		// 表示用のスキル名
		public string name;

		// 表示用のスキル説明
		public string explanationText;

		// スキルオブジェクト
		public GameObject SkillObject;
	}

	enum SKILL_ID_NAME
	{
		TRANSPARENT = 0
	}

	/// <summary>
	/// スキルを管理するクラス
	/// </summary>
	public class SkillManager : SingletonMonoBehaviour<SkillManager> 
	{
		#region フィールド/プロパティ

		/// <summary>
		/// スキルのリスト
		/// </summary>
		[SerializeField]
		private List<SKILL_SETTING> SkillList = new List<SKILL_SETTING>();

		#endregion

		#region アクセスメソッド

		public void ExecuteSkillEvent(int skillId)
		{
			switch (skillId)
			{
			case (int)SKILL_ID_NAME.TRANSPARENT:
				// 透明化

				break;
			default:
				// 設定なし
				break;
			}
		}

		#endregion

		#region スキルメソッド

		#endregion
	}
}
