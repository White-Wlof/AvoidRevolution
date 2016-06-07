using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AvoidRevolution.Utility.Game.Character
{
	/// <summary>
	/// キャラ設定の構造体
	/// </summary>
	[Serializable]
	public struct CHARACTER_SETTINGS
	{
		// キャラクタを特定するID
		public int charId;

		// キャラクタ名
		public string charName;

		// キャラクタの画像(変更するかも)
		public string charImagePath;

		// キャラクタのHP
		public float charHp;

		// キャラクタのMP
		public float charMp;

		// キャラクタの攻撃力
		public float charAttack;

		// キャラクタの移動速度
		public float charSpeed;

		// キャラクタの防御力
		public float charDefense;

		// 検索・設定用のスキルID(英字)
		public string idName;
	}

	/// <summary>
	/// スキルを管理するクラス
	/// </summary>
	public class CharacterSettings : SingletonMonoBehaviour<CharacterSettings> 
	{
		#region プロパティ/フィールド

		/// <summary>
		/// キャラクタのリスト
		/// </summary>
		[SerializeField]
		private List<CHARACTER_SETTINGS> characterList = new List<CHARACTER_SETTINGS>();

		#endregion

		#region メソッド

		#endregion
	}
}