using UnityEngine;

namespace FATEC.CubeWars.Behaviours {
				/// <summary>
				/// Base behaviour.
				/// </summary>
				public abstract class BaseBehaviour : MonoBehaviour {
								/// <summary>Reference to the Transform component.</summary>
								protected new Transform transform;

								protected virtual void Awake() {
												this.transform=this.GetComponent<Transform>();
								}
				}
}