namespace Task.MyExceptions.Interfaces
{
    /// <summary>
    /// An interface for storing error message
    /// </summary>
    public interface IMyException
    {
        /// <summary>
        /// Error message with addition information
        /// </summary>
        string ErrorMessage { get; set; }
    }
}