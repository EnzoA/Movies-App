using System.Net.Http;
using System.Threading.Tasks;

namespace SAL.Interfaces
{
	public interface IHttpClient
	{
		Task<HttpResponseMessage> GetAsync(string requestUri);
	}
}
