namespace Ibanity.Apis.Client.Utils
{
    /// <inheritdoc />
    public class Identified<T> : IIdentified<T> where T : struct
    {
        /// <inheritdoc />
        public T Id { get; set; }
    }

    /// <summary>
    /// Resource identified by some unique value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdentified<T> where T : struct
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        T Id { get; set; }
    }
}
