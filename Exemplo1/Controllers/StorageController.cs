using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Softplan.Common.Storage.AmazonS3;
using Softplan.Common.Storage.AmazonS3.Implementations.Object;

namespace Exemplo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : Controller
    {
        private readonly IAmazonS3StorageClient _amazonS3StorageClient;
        private readonly IConfiguration _configuration;

        public StorageController(IAmazonS3StorageClient amazonS3StorageClient, 
                                 IConfiguration configuration)
        {
            _amazonS3StorageClient = amazonS3StorageClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync()
        {
            var resp = await _amazonS3StorageClient.ListBucketsAsync();

            return Ok(resp.Buckets);
        }
        
        [HttpPost]
        public async Task<IActionResult> CriarAsync(string bucket)
        {
            await _amazonS3StorageClient.CreateOrExistBucketAsync(bucket);

            return Ok(_configuration["MENSAGEM_DE_SUCESSO"]);
        }
    }
}