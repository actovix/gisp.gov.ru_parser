namespace gisp.gov.ru_parser.Exceptions;

public class HtmlParserException : Exception
{

    public HtmlParserException()
    {
    }

    public HtmlParserException(string message)
        : base(message)
    {
    }

    public HtmlParserException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
