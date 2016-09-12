using UnityEngine;
using System.Collections;
using AvoidRevolution.Utility.Game.Manager;

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
        /// 矢印オブジェクト
        /// </summary>
        private GameObject arowObject;

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

        /// <summary>
        /// 移動時間
        /// </summary>
        [SerializeField]
        private float moveTime;

        /// <summary>
        /// Forceの制限
        /// </summary>
        [SerializeField]
        private int limitForce;

        /// <summary>
        /// ユニークID
        /// </summary>
        private int uniqueId;

        /// <summary>
        /// 減速判断
        /// </summary>
        private bool isDeceleration;

        /// <summary>
        /// 移動制御タイマー
        /// </summary>
        private float fluctuationMoveTime;

        /// <summary>
        /// ユニークIDのアクセサ
        /// </summary>
        /// <value>ユニークID</value>
        public int UniqueId
        {
            set
            {
                uniqueId = value;
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 一番最初に呼ばれる
        /// </summary>
        void Awake()
        {
            SetupPlayerController();
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {
            move();
            if (!isControl || !IsSelectPlayer())
                return;
            //操作
            Control();
        }

        /// <summary>
        /// 自分自身が操作キャラクタとして選択されているかどうか
        /// </summary>
        /// <returns>操作キャラクタかどうか</returns>
        private bool IsSelectPlayer()
        {
            if (uniqueId == GameManager.Instance.selectCharData.playerId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// プレイヤーコントローラー
        /// </summary>
        private void SetupPlayerController()
        {
            // プレイヤーのRigidbody2Dを設定
            playerRig2D = this.GetComponent<Rigidbody2D>();
            isControl = true;
            isDeceleration = true;
            // TODO AvoidRevolution 矢印オブジェクトの初期化
        }

        private void moveTimer()
        {
            if (!isDeceleration)
            {
                fluctuationMoveTime -= Time.deltaTime;
                if (fluctuationMoveTime <= 0)
                {
                    isDeceleration = true;
                }
            }
        }

        /// <summary>
        /// 位置の固定
        /// </summary>
        private void FreezePosition()
        {
            playerRig2D.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        /// <summary>
        /// 位置の固定を解除
        /// </summary>
        private void CancellationFreezePosition()
        {
            playerRig2D.constraints = RigidbodyConstraints2D.None;
        }

        /// <summary>
        /// キャラクタの動作を制御する
        /// </summary>
        private void move()
        {
            if (playerRig2D.velocity.magnitude < 1)
            {
                isControl = true;
            }
            else
            {
                isControl = false;
            }
            moveTimer();
            if (isDeceleration)
            {
                // 減速
                playerRig2D.velocity *= 0.98f;
                if (playerRig2D.velocity.magnitude < 1)
                {
                    playerRig2D.velocity = Vector2.zero;
                    FreezePosition();
                }
            }
        }

        /// <summary>
        /// キャラクタの操作を行う
        /// </summary>
        private void Control()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // TODO AvoidRevolution 操作メソッドに変更
                startPos = GetInputMousePosition();
            }
            if (Input.GetMouseButton(0))
            {
                // TODO AvoidRevolution 操作メソッドの変更
                nowPos = GetInputMousePosition();
                forceVec = new Vector2(startPos.x - nowPos.x, startPos.y - nowPos.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                // TODO AvoidRevolution 操作メソッドに変更
                endPos = GetInputMousePosition();
                forceVec = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
                if (IsAddForce(forceVec))
                {
                    CancellationFreezePosition();
                    playerRig2D.AddForce(forceVec * baseForceValue * Time.deltaTime);
                }
                isDeceleration = false;
                fluctuationMoveTime = moveTime;
            }
            // TODO AvoidRevolution 矢印描画メソッドの読み込み
            DrawingArrow(forceVec);
        }

        /// <summary>
        /// タップした位置の取得
        /// </summary>
        /// <returns>タップした位置</returns>
        private Vector2 GetInputMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        /// <summary>
        /// AddForce制限の判定
        /// </summary>
        /// <returns>AddForce有効か</returns>
        /// <param name="force">加えるForce</param>
        private bool IsAddForce(Vector2 force)
        {
            if (Mathf.Pow(limitForce, 2) > Mathf.Pow(force.x, 2) + Mathf.Pow(force.y, 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 方向矢印の描画
        /// </summary>
        private void DrawingArrow(Vector2 force)
        {
            if (!IsAddForce(force))
                return;
            // 矢印の描画

        }

        #endregion
    }
}