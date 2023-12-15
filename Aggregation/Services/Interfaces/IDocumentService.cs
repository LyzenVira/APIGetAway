using Aggregation.Models;

namespace Aggregation.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<ResponseEntity<Document>> GetDocumentByEmail(string email);
    }
}
