using UnityEngine;
using System.Collections;

public class DirectionalEmission : IEmission {

	public void InstantiateParticle(Emitter e, GameObject original, ObjectInitiator initiator){
		Randomizer rand = Randomizer.Instance;
        GameObject p = (GameObject)GameObject.Instantiate(original);
        // イニシエータの実行
        if (initiator != null)
        {
            p = initiator(p);
        }
		Vector3 pos = p.transform.position;
		pos.x = e.transform.position.x + e.PositionOffset.x;
		pos.y = e.transform.position.y + e.PositionOffset.y;
		pos.z = e.transform.position.z + e.PositionOffset.z;
		p.transform.position = pos;
		
		Force f = p.GetComponent<Force>();
		float d = (e.Direction + 360) * e.DirectionDiffusion;
		f.Direction = (e.Direction - d / 2) + d * rand.NextFloat();
		float s = e.InitialSpeed * e.InitialSpeedDiffusion;
		f.Value = (e.InitialSpeed - s) + s * rand.NextFloat();
		f.Activate();
	}
}
