namespace Interfaces
{
    /// <summary>
    /// Interface for timers.
    /// </summary>
    public interface ITimer
    {
        public System.Action<float> OnTimerChanged{ get; set; }
        public System.Action OnTimerFinished { get; set; }
        public void StartTimer(float time);
        public void StopTimer();
        public void ResetTimer(float time);
        public void PauseTimer();
        public void UnpauseTimer();
    }
}