namespace AnkaraLab_BackEnd.WebAPI.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
            // WTF?
        }
    }
}
