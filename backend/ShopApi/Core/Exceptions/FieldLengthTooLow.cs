namespace Core.Exceptions;

public class FieldLengthTooLow : Exception
{
    public FieldLengthTooLow(string fieldName, int requiredSize) : base($"The value for field {fieldName} needs to be higher than {requiredSize}")
    {
            
    }
}