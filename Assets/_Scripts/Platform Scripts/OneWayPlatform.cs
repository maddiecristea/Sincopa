using TarodevController;
using UnityEngine;

namespace Tarodev {
    /// <summary>
    /// This seems hacky, but I just wanted to chuck it in quickly. Works perfectly fine. 
    /// </summary>
    public class OneWayPlatform : MonoBehaviour {
        private BoxCollider2D _col;
        private IPlayerController _controller;

        private void Awake() => _col = GetComponent<BoxCollider2D>();

        private void Update() {
            if (_controller == null) return;
            _col.enabled = _controller.RawMovement.y <= 0;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent(out IPlayerController controller)) _controller = controller;
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.TryGetComponent(out IPlayerController controller)) _controller = null;
        }
    }
}