/// <summary>
/// Een generische klasse om een resultaat van een factory te weer te geven. 
/// Deze klasse laat toe om een error terug te geven wanneer een creatie niet lukt.
/// Bv. als we een coordinaat willen maken, maar er wordt een negatieve x of y als parameter geven, dan kunnen we een error message terug geven in plaats van een resultaat.
/// </summary>
/// <typeparam name="T">Het type waarvoor we dit resultaat willen gebruiken. Als we de CoordinaatFactory gebruiken, dan zal het type 'Coordinaat' zijn</typeparam>
public class FactoryResult<T>
{
    /// <summary>
    /// Bevat het resultaat van de factory. 
    /// bv. als we dit gebruiken om een coordinaat te maken, dan zal Result een Coordinaat bevatten.
    /// </summary>
    public T? Result { get; init; }

    /// <summary>
    /// Bevat een fout boodschap als de creatie niet gelukt is.
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// Een property waarmee we gemakkelijk kunnen controleren of de creatie gelukt is of niet. 
    /// Deze bevat zelf geen waarde maar zal een 'berekening' uitvoeren op de 'ErrorMessage' waarde. Indien deze 'null' is, dan is de creati egelukt
    /// </summary>    
    public bool IsSuccess 
        => ErrorMessage == null;

    public FactoryResult(T result)
    {
        Result = result;
    }

    public FactoryResult(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}

