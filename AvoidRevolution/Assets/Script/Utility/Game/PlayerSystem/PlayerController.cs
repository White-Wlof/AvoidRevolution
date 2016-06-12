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

		/// <summary>
		/// 操作可能か
		/// </summary>
		private bool isControl;

		/// <summary>
		/// 画面を触った時の位置
		/// </summary>
		private Vector2 startPos;

		/// <summary>
		/// 現在の位置
		/// </summary>
		private Vector2 nowPos;

		/// <summary>
		/// 画面を離れた時の位置
		/// </summary>
		private Vector2 endPos;

		/// <summary>
		/// addForceで力を加える基礎力
		/// </summary>
		private Vector2 forceVec;

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
		/// 毎フレーム呼ばれる
		/// </summary>
		void Update()
		{
			if (!isControl)
				return;
			//操作
			Control ();
		}

		/// <summary>
		/// プレイヤーコントローラー
		/// </summary>
		private void SetupPlayerController()
		{
			// プレイヤーのRigidbody2Dを設定
			playerRig2D = this.GetComponent<Rigidbody2D> ();
			isControl = true;
		}

		/// <summary>
		/// キャラクタの操作を行う
		/// </summary>
		private void Control()
		{
			if (Input.GetMouseButtonDown (0)) {
				// TODO AvoidRevolution 操作メソッドに変更
				startPos = GetInputMousePosition();
			}
			if (Input.GetMouseButton (0)) {
				// TODO AvoidRevolution 操作メソッドの変更
				nowPos = GetInputMousePosition();
				forceVec = new Vector2 (startPos.x - nowPos.x, startPos.y - nowPos.y);
			}
			if (Input.GetMouseButtonUp (0)) {
				// TODO AvoidRevolution 操作メソッドに変更
				endPos = GetInputMousePosition();
				forceVec = new Vector2 (startPos.x - endPos.x, startPos.y - endPos.y);
				playerRig2D.AddForce (forceVec * baseForceValue * Time.deltaTime);
			}
			// TODO AvoidRevolution 描画メソッドの読み込み

			// 減速
			playerRig2D.velocity *= 0.99f;
		}

		/// <summary>
		/// タップした位置の取得
		/// </summary>
		/// <returns>タップした位置</returns>
		private Vector2 GetInputMousePosition()
		{
			return Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		#endregion
	}
}