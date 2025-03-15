using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DoubleAnyRad2 {
    internal class RadianceFinder : MonoBehaviour {
        private void Start() {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += FindAbsScene;
        }

        private void FindAbsScene(UnityEngine.SceneManagement.Scene _, UnityEngine.SceneManagement.Scene to) {
            if (to.name=="GG_Radiance") {
                StartCoroutine(FindAbs());
            }
        }

        private IEnumerator FindAbs() {
            yield return new WaitWhile(() => GameObject.Find("Absolute Radiance") == null);
            GameObject absControl = new();
            absControl.AddComponent<DoubleAnyRadControl>();
        }

        private void OnDestroy() {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged -= FindAbsScene;
        }
    }
}
