namespace MouseTracker.Data.Engine;

public sealed class DbConnectionOptions
{
    public const string OptionsKey = "ConnectionStrings";

    public string? MouseTracker { get; set; }

    public string RequiredConnectionString => MouseTracker 
                                              ?? throw new ArgumentNullException(EmptyConnectionStringMessage);

    private const string EmptyConnectionStringMessage = $"Конфигурационное значение «{nameof(MouseTracker)}» не задано";
}