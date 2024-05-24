using UnityEngine;

namespace StationScripts
{
    public class FirstStationBoot : MonoBehaviour
    {
        [SerializeField] private Station initialStation;

        private void Start()
        {
            if (initialStation != null)
                initialStation.Initialize(true);
        }
    }
}