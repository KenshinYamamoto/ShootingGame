using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("敵を生成するスパン(何秒おきに生成するかどうか)")]
    public float span;

    [Header("ゲーム開始からボスが出てくるまでの時間")]
    public float encountBossTime;

    [Header("ゲーム開始から敵が出てくるまでの時間")]
    public float encountenemyTime;

    [Header("プレイヤーを操作する速度(デフォルト:15)")]
    public float playerSpeed;

    [Header("プレイヤーの弾の速度(デフォルト:10)")]
    public float playerBulletSpeed;

    [Header("敵が生成されてから何秒後に弾を打つか(デフォルト:1f)")]
    public float enemyBulletShot;

    [Header("何秒おきに敵が弾を発射するか(デフォルト:1f)")]
    public float enemyBulletTime;

    [Header("敵が打つ弾が落ちてくる速度(デフォルト:8f)")]
    public float enemyBulletSpeed;

    [Header("加算されるスコア(デフォルト:100)")]
    public int addScore;

    //MyScriptableObjectが保存してある場所のパス
    public const string PATH = "ParamsSO";

    //MyScriptableObjectの実体
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
