namespace gisp.gov.ru_parser.Parser.Loader;

public interface IHtmlLoader
{
    public Task<string> LoadPageByLink(string url, CancellationToken cancellationToken);
    public Task<string> LoadPageByHttpReqMessage(HttpRequestMessage httpRequest);
}
