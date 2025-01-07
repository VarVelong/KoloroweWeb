using KoloroweWeb.Data.Entities;
using KoloroweWeb.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KoloroweWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IRepository<Offer> offerRepository;

        public OffersController(IRepository<Offer> offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Offer>>> GetOffers()
        {
            var offers = await offerRepository.GetAllAsync();
            return Ok(offers);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            await offerRepository.AddAsync(offer);
            return offer;
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> DeleteOffer(int Id)
        {
            Offer entity = new Offer()
            {
                Id = Id
            };

            await offerRepository.RemoveAsync(entity);
            return HttpStatusCode.OK;
        }
    }
}
