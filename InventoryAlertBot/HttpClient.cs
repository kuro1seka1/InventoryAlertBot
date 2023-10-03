using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAlertBot
{
    internal class HttpClient
    {
            public async Task<string> Response(string url)
            {
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                var services = new ServiceCollection();
                services.AddHttpClient();
                var serviceProvider = services.BuildServiceProvider();

                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

                var httpClient = httpClientFactory?.CreateClient();

                var getresponse = await httpClient.GetAsync(url, cancelTokenSource.Token);

                string response = await getresponse.Content.ReadAsStringAsync();

                return response;
            }
        
    }
}
