namespace BuildingBlocks.Exception
{
    public class ConflictException : System.Exception
    {
        public virtual string Code { get; }
        public ConflictException(string message, string code = default!) : base(message)
        {
            Code = code;
        }
    }
}