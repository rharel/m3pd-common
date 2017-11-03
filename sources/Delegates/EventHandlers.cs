namespace rharel.M3PD.Common.Delegates
{
    /// <summary>
    /// Handles non-parametric events.
    /// </summary>
    /// <typeparam name="TSender">The type of the event's sender.</typeparam>
    /// <param name="sender">The event's sender.</param>
    public delegate void EventHandler<TSender>(TSender sender);
    /// <summary>
    /// Handles parametric events.
    /// </summary>
    /// <typeparam name="TSender">The type of the event's sender.</typeparam>
    /// <typeparam name="TData">The type of the event's data.</typeparam>
    /// <param name="sender">The event's sender.</param>
    /// <param name="data">The event's data.</param>
    public delegate void EventHandler<TSender, TData>(
        TSender sender, TData data
    );
}
