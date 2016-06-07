using UnityEngine;
using System.Collections;

namespace AvoidRevolution.Utility.Game.PlayerSystem
{
	/// <summary>
	/// プレイヤーのコントローラークラス
	/// </summary>
	public class PlayerController : MonoBehaviour
	{
		#region フィールド/プロパティ

		/// <summary>
		/// プレイヤーのRigidbody2D
		/// </summary>
		private Rigidbody2D playerRig2D;

		/// <summary>
		/// 基礎となる吹き飛ばし力
		/// </summary>
		[SerializeField]
		private float baseForceValue;

		#endregion

		#region メソッド

		/// <summary>
		/// 一番最初に呼ばれる
		/// </summary>
		void Awake()
		{
			SetupPlayerController ();
		}

		/// <summary>
		/// プレイヤーコントローラー
		/// </summary>
		private void SetupPlayerController()
		{
			// プレイヤーのRigidbody2Dを設定
			playerRig2D = this.GetComponent<Rigidbody2D> ();
		}

		#endregion
	}
}