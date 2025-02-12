using System.Collections;

namespace BProject.Core
{
    public interface IRoutineRunner
    {
        void StartRoutine(IEnumerator routine);
    }
}