using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseCritic.Models;
using MuseCritic.Repository;

namespace MuseCritic.Controllers
{
    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewRepository reviewRepository;

        public ReviewController(ReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository), "A non-null review Repository must be injected.");
        }

        [HttpGet]
        public async Task<List<Review>> Get()
        {
            return await this.reviewRepository.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Review>> Get(string id)
        {
            var review = await this.reviewRepository.GetAsync(id);

            if (review == null)
            {
                return new NotFoundResult();
            }

            return review;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            await this.reviewRepository.CreateAsync(review);

            return new CreatedAtActionResult(actionName: nameof(Get), controllerName: "review", routeValues: new { id = review.Id }, value: review);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Review updatedReview)
        {
            var currentReview = await this.reviewRepository.GetAsync(id);

            if (currentReview is null)
            {
                return NotFound();
            }

            updatedReview.Id = currentReview.Id;

            await this.reviewRepository.UpdateAsync(id, updatedReview);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var review = await this.reviewRepository.GetAsync(id);

            if (review is null)
            {
                return NotFound();
            }

            await this.reviewRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
