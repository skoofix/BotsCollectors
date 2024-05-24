using UnityEngine;

namespace Items
{
    public class Apple : MonoBehaviour
    {
        [SerializeField] private int _price;
        [SerializeField] private float _reservationDuration = 25f;
        
        private float _elapsedReservationTime;
        public int Price => _price;
        public bool IsScanned { get; private set; }

        public void Scanned() => IsScanned = true;

        public void ResetParams()
        {
            IsScanned = false;
            _elapsedReservationTime = 0f;
        }

        private void Update()
        {
            if (IsScanned)
            {
                _elapsedReservationTime += Time.deltaTime;

                if (_elapsedReservationTime > _reservationDuration)
                {
                    ResetParams();
                }
            }
        }
    }
}