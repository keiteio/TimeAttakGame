using UnityEngine;
using System.Collections;

public interface IEmission{

    void InstantiateParticle(Emitter e, GameObject original, ObjectInitiator initiator);
}

public enum EmissionType{
	Directional
}

public delegate GameObject ObjectInitiator(GameObject original);