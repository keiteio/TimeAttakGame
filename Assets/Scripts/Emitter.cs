using UnityEngine;
using System.Collections;

/// <summary>
/// GameObjectを一定間隔で射出するエミッタ
/// </summary>
public class Emitter : MonoBehaviour {
	
	/// <summary>
	/// 放出するゲームオブジェクト
	/// </summary>
	public GameObject Emittee;
	
	/// <summary>
	/// 放出間隔(秒)
	/// </summary>
	public float Interval;
	
	private float lastEmissionTime;
	
	/// <summary>
	/// 一回の放出量
	/// </summary>
	public int Amount;
	
	/// <summary>
	/// 放出方向
	/// </summary>
	public float Direction;
	
	/// <summary>
	/// 放出方向拡散量
	/// </summary>
	public float DirectionDiffusion;
	
	/// <summary>
	/// 初速度
	/// </summary>
	public float InitialSpeed;
	
	/// <summary>
	/// 初速度拡散量
	/// </summary>
	public float InitialSpeedDiffusion;
	
	/// <summary>
	/// 放出形状タイプ
	/// </summary>
	public EmissionType Type;
	
	/// <summary>
	/// エミッター一位置のゲームオブジェクト位置からのオフセット
	/// </summary>
	public Vector3 PositionOffset;

    /// <summary>
    /// 放出量の制限。0以下で制限なし。
    /// </summary>
    public int Limitage = 0;
	
	private IEmission emission;
    private int count = 0;
	
	public bool Activation;

    private ObjectInitiator initiator = null;

	// Use this for initialization
	public virtual void Start () {
		switch(Type){
		case EmissionType.Directional :
			emission = new DirectionalEmission();
			break;
		}
		lastEmissionTime = Time.time - Interval;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(Activation){
			Emit();
		}
	}
	
	public void Emit(){
		if( Time.time - lastEmissionTime > Interval ){
            // 放出量の計算
            int amount = Amount;
            if (Limitage > 0)
            {
                if (count + Amount > Limitage)
                {
                    // 放出量制限を超える場合、超えない範囲で抄出料を設定
                    amount = Limitage - count;
                }
                count += amount;
            }
			for(int i = 0; i < Amount; i++){
                emission.InstantiateParticle(this, Emittee, initiator);
			}
			lastEmissionTime = Time.time;
		}
	}
	
	public void Activate(){
		Activation = true;
		lastEmissionTime = Time.time - Interval;
	}
	
	public void Deactivate(){
		Activation = false;
	}
}
