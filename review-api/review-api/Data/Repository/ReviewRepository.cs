using Microsoft.EntityFrameworkCore;
using review_api.Data.Entities;
using review_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Commentary> Commnets = new List<Commentary>();
        private ReviewDbContext reviewDbContext;

        public ReviewRepository(ReviewDbContext reviewDBContext)
        {
            this.reviewDbContext = reviewDBContext;

        }
        public void CreateCommentary(CommentaryEntity commentary)
        {
            reviewDbContext.Comments.Add(commentary);
        }

        public async Task DeleteCommentaryAsync(int id)
        {
            var commentary = await reviewDbContext.Comments.SingleAsync(a => a.Id == id);
            reviewDbContext.Comments.Remove(commentary);
        }

        public void DetachEntity<T>(T entity) where T : class
        {
            reviewDbContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<CommentaryEntity> GetCommentaryAsync(int id)
        {
            IQueryable<CommentaryEntity> query = reviewDbContext.Comments;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<CommentaryEntity>> GetCommentsAsync(int bookId)
        {
            IQueryable<CommentaryEntity> query = reviewDbContext.Comments.Where(x => x.BookId == bookId);
            query = query.AsNoTracking().Where(x => x.BookId == bookId);
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await reviewDbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateCommentaryAsync(CommentaryEntity commentary)
        {
            reviewDbContext.Comments.Update(commentary);
        }
    }
}
