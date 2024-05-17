using UnityEngine;
using UnityEngine.UI;

namespace BaseScripts
{
    public class StationScoreView : MonoBehaviour
    {
        [SerializeField] private Station _station;
        [SerializeField] private Text _text;

        private void Update() => UpdateView();

        private void UpdateView() => _text.text = _station.GetStationScore().ToString();
    }
}