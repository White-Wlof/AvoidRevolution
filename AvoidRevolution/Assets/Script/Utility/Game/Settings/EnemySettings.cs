using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AvoidRevolution.Utility.Game.Settings
{
	/// <summary>
	/// エネミー設定の構造体
	/// </summary>
	[Serializable]
	public struct ENEMY_SETTINGS
	{
		// エネミーを特定するID
		public int enemyId;

		// エネミー名
		public string enemyName;

		// エネミーの画像(変更するかも)
		public string enemyImagePath;

		// エネミーのHP
		public float enemyHp;

		// エネミーのMP
		public float enemyMp;

		// エネミーの攻撃力
		public float enemyAttack;

		// エネミーの移動速度
		public float enemySpeed;

		// エネミーの防御力
		public float enemyDefense;
	}

	/// <summary>
	/// スキルを管理するクラス
	/// </summary>
	public class EnemySettings : SingletonMonoBehaviour<EnemySettings>
	{
		#region プロパティ/フィールド

		/// <summary>
		/// キャラクタのリスト
		/// </summary>
		[SerializeField]
		private List<ENEMY_SETTINGS> characterList = new List<ENEMY_SETTINGS>();

		#endregion

		#region メソッド

		#endregion
	}
}