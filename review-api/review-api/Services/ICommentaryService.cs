using review_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Services
{
    public interface ICommentaryService
    {
        Task<IEnumerable<Commentary>> GetAllComments(int bookId);
        Task<Commentary> GetCommentary(int id, int bookId);
        Task<Commentary> UpdateCommentary(int id, int bookId, Commentary commentary);
        Task<Commentary> CreateCommentary(int bookId, Commentary commentary);
        Task<bool> DeleteCommentary(int id);



    }
}
