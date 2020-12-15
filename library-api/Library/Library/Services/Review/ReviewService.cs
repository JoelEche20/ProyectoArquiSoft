using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Services.Review
{
    public class ReviewService
    {
        public HttpClient Reviews { get; }
        public ReviewService(HttpClient reviews)
        {
            reviews.BaseAddress = new Uri("http://localhost:56115/");
            Reviews = reviews;
        }

        public async Task<List<Commentary>> GetReviews(int id)
        {
            var response = await Reviews.GetAsync($"api/Review/{id}");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStringAsync();
            var commentaries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Commentary>>(responseStream);

            return commentaries;
        }
    }
}
