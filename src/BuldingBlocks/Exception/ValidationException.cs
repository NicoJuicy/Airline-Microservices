using BuildingBlocks.Validation;

namespace BuildingBlocks.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationException(ValidationResultModel validationResultModel)
        {
            ValidationResultModel = validationResultModel;
        }

        public ValidationResultModel ValidationResultModel { get; }
    }
}