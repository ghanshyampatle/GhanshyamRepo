using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Threading.Tasks;

namespace UploadandDownloadFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public Task<IActionResult> UseChatGPT(string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;           

            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }

            return Task.FromResult<IActionResult>(Ok(OutPutResult));
        }
    }
}