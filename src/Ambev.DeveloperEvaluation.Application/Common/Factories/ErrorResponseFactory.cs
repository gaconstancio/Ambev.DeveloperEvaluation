namespace Ambev.DeveloperEvaluation.Application.Common.Factories;

/// <summary>
/// Factory for creating standardized error responses.
/// </summary>
public static class ErrorResponseFactory
{
    /// <summary>
    /// Creates a standardized error response.
    /// </summary>
    /// <param name="type">The type of the error.</param>
    /// <param name="error">A short description of the error.</param>
    /// <param name="detail">Detailed information about the error.</param>
    /// <returns>An object representing the error response.</returns>
    public static object Create(string type, string error, string detail)
    {
        return new
        {
            type,
            error,
            detail
        };
    }
}
