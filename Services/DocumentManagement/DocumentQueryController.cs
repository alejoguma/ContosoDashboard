using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoDashboard.Services.DocumentManagement;
using ContosoDashboard.Models.DocumentManagement;

namespace ContosoDashboard.Services.DocumentManagement
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentQueryController : ControllerBase
    {
        private readonly DocumentService _service;
        public DocumentQueryController(DocumentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetUserDocuments([FromQuery] int userId)
        {
            var docs = await _service.GetUserDocumentsAsync(userId);
            return Ok(docs);
        }
    }
}
