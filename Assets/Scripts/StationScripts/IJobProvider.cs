using UnityEngine;

namespace StationScripts
{
    public interface IJobProvider
    {
        bool TryGetNextJob(out Vector3 target, out JobType jobType);
    }
}