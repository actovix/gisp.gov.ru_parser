using System.Text;

namespace gisp.gov.ru_parser.Parser.Loader;

public class HtmlLoader : IHtmlLoader
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly Serilog.ILogger _logger;

    public HtmlLoader(IHttpClientFactory httpFactory, Serilog.ILogger logger)
    {
        _httpClientFactory = httpFactory;
        _logger = logger;
    }

    public async Task<string> LoadPageByLink(string url, CancellationToken cancellationToken)
    {
        string? html = "";
        using (var httpClient = _httpClientFactory.CreateClient(url))
        {
            try
            {
                var enc = Encoding.Default;
                
                var res = await httpClient.GetAsync(url, cancellationToken);

                if (res.Content.Headers.TryGetValues("Content-Type", out var headers))
                {
                    enc = headers.Any(x => x.Contains("windows-1251")) ? Encoding.GetEncoding("windows-1251") : enc;
                }

                if (res is not null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var sr = new StreamReader(
                            await res.Content.ReadAsStreamAsync(cancellationToken), enc))
                        html = await sr.ReadToEndAsync(cancellationToken);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return html;
    }

    public async Task<string> LoadPageByHttpReqMessage(HttpRequestMessage httpRequest)
    {
        string? html = "";
        using (var httpClient = _httpClientFactory.CreateClient())
        {

            try
            {
                var res = await httpClient.SendAsync(httpRequest);

                if (res is not null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var sr = new StreamReader(
                            await res.Content.ReadAsStreamAsync()/*, Encoding.GetEncoding("windows-1251")*/))
                        html = await sr.ReadToEndAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return html;
    }
}
