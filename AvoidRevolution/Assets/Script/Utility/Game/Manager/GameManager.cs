using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AvoidRevolution.Utility.Game.PlayerSystem;

namespace AvoidRevolution.Utility.Game.Manager
{
    // キャラクタのベースとなる構造体
    [Serializable]
    public struct CHARACTER_BASE
    {
        // プレイヤID
        public int playerId;
    }

    /// <summary>
    /// ゲームを管理するメインのクラス
    /// </summary>
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        #region フィールド/プロパティ

        /// <summary>
        /// 選択されたキャラクタのベースデータ
        /// </summary>
        public CHARACTER_BASE selectCharData;

        /// <summary>
        /// プレイヤのオブジェクト
        /// </summary>
        [SerializeField]
        private GameObject playerObj;

        /// <summary>
        /// プレイヤのデータ
        /// </summary>
        [SerializeField]
        private List<CHARACTER_BASE> charDataList = new List<CHARACTER_BASE>();

        /// <summary>
        /// 初期位置の設定
        /// </summary>
        [SerializeField]
        private List<Vector2> startPosList = new List<Vector2>();

        /// <summary>
        /// カラーリスト
        /// 後で削除
        /// </summary>
        private List<Color> colorList = new List<Color>(){ Color.red, Color.blue, Color.green, Color.yellow };

        /// <summary>
        /// スコア
        /// </summary>
        private int score;

        /// <summary>
        /// スコアのアクセサ
        /// </summary>
        /// <value>スコア</value>
        int Score
        {
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

        void Awake()
        {
            // プレイヤの設定
            SetPlayerObjects();
        }

        /// <summary>
        /// 毎フレームごと呼ぶ
        /// 後で削除
        /// </summary>
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // player1
                SelectPlayer(charDataList[0].playerId);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                // player2
                SelectPlayer(charDataList[1].playerId);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                // player3
                SelectPlayer(charDataList[2].playerId);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                // player4
                SelectPlayer(charDataList[3].playerId);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SelectPlayer();
            }
        }

        /// <summary>
        /// 操作キャラを選択する
        /// </summary>
        /// <param name="uniqueId">ユニークID(-1:何もない状態)</param>
        public void SelectPlayer(int uniqueId = -1)
        {
            foreach (CHARACTER_BASE data in charDataList)
            {
                if (uniqueId == data.playerId)
                {
                    selectCharData = data;
                    return;
                }
            }
            selectCharData = new CHARACTER_BASE();
        }

        /// <summary>
        /// プレイヤの設定
        /// </summary>
        private void SetPlayerObjects()
        {
            // オフラインの場合
            foreach (CHARACTER_BASE data in charDataList)
            {
                GameObject obj = Instantiate(playerObj);
                obj.transform.position = startPosList[charDataList.IndexOf(data)];
                obj.name = "Player_" + data.playerId;
                obj.GetComponent<PlayerController>().UniqueId = data.playerId;
                obj.GetComponent<SpriteRenderer>().color = colorList[charDataList.IndexOf(data)];
            }
            SelectPlayer(charDataList[0].playerId);
        }

        #endregion
    }
}