using System.Runtime.CompilerServices;

namespace System.Runtime.Remoting
{
    /// <summary>
    /// Provides several methods for using and publishing remoted objects and proxies. This class cannot be inherited.
    /// </summary>
    public static class RemotingServices
    {
        /// <summary>
        /// Returns a Boolean value that indicates whether the given object is a transparent proxy or a real object.
        /// </summary>
        /// <param name="proxy">The reference to the object to check.</param>
        /// <returns>A Boolean value that indicates whether the object specified in the proxy parameter is a transparent proxy or a real object.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsTransparentProxy(Object proxy);
    }
}
