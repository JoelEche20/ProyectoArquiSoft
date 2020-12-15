using review_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Data.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<CommentaryEntity>> GetCommentsAsync(int bookId);
        Task<CommentaryEntity> GetCommentaryAsync(int id);
        void UpdateCommentaryAsync(CommentaryEntity guest);
        void CreateCommentary(CommentaryEntity guest);
        Task DeleteCommentaryAsync(int id);


        Task<bool> SaveChangesAsync();
        void DetachEntity<T>(T entity) where T : class;
    }
}
