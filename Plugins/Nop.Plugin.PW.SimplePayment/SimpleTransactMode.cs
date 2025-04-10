
namespace Nop.Plugin.PW.SimplePayment;

/// <summary>
/// Represents manual payment processor transaction mode
/// </summary>
public enum SimpleTransactMode
{
    /// <summary>
    /// Pending
    /// </summary>
    Pending = 0,

    /// <summary>
    /// Authorize
    /// </summary>
    Authorize = 1,

    /// <summary>
    /// Authorize and capture
    /// </summary>
    AuthorizeAndCapture = 2
}