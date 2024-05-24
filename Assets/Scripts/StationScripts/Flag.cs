using UnityEngine;

namespace StationScripts
{
    public class Flag : MonoBehaviour
    {
        private bool _isFixed;
        
        public bool IsFixed => _isFixed;
        public Vector3 Position { get; private set; }

        public void SetPosition(Vector3 position)
        {
            if (_isFixed)
                return;
            
            Position = position;
            transform.position = position;
        }

        public void FixPosition() => _isFixed = true;
    }
}