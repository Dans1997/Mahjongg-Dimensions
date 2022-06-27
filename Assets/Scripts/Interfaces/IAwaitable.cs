using System.Collections;

namespace Interfaces
{
    /// <summary>
    /// Interface for behaviours that need to be waited for.
    /// For example, showing a tutorial UI before starting a game.
    /// </summary>
    public interface IAwaitable
    {
        /// <summary>
        /// Coroutine to wait for the behaviour to finish.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitUntilDone();
    }
}