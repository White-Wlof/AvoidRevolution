using UnityEngine;
using System.Collections;

namespace AvoidRevolution.Utility.Game.Manager
{
	/// <summary>
	/// ゲームを管理するメインのクラス
	/// </summary>
	public class GameManager : SingletonMonoBehaviour<GameManager> {

		#region フィールド/プロパティ

		/// <summary>
		/// プレイヤ
		/// </summary>
		[SerializeField]
		private GameObject playerObj;

		/// <summary>
		/// プレイヤのID(Test:1111)
		/// </summary>
		[SerializeField]
		private int playerId;

		/// <summary>
		/// スコア
		/// </summary>
		private int score;

		int Score{
			set
			{
				score = value;
			}

			get
			{
				return score;
			}
		}

		#endregion

		#region メソッド

		/// <summary>
		/// コンストラクタ
		/// </summary>
		private GameManager()
		{
			
		}

		/// <summary>
		/// 一番最初に処理する
		/// </summary>
		void Awake()
		{
			// プレイヤの設定
			SetPlayerObjects ();
		}

		/// <summary>
		/// プレイヤの設定
		/// </summary>
		private void SetPlayerObjects()
		{
			// オフラインの場合
			GameObject obj = Instantiate(playerObj);
			obj.name = "Player_" + playerId.ToString();
		}

		#endregion
	}
}