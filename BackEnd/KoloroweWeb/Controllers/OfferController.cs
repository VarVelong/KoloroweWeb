using KoloroweWeb.Data;
using KoloroweWeb.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace KoloroweWeb.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly KolorowewebContext kolorowewebContext;

        public OffersController(KolorowewebContext context)
        {
            kolorowewebContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offers>>> GetOffers()
        {
            return await kolorowewebContext.Offers.ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Offers>> PostOffer(Offers offer)
        {
            kolorowewebContext.Offers.Add(offer);
            await kolorowewebContext.SaveChangesAsync();

            return offer;
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> DeleteOffer(int Id)
        {
            var entity = new Offers()
            {
                Id = Id
            };

            kolorowewebContext.Offers.Attach(entity);
            kolorowewebContext.Offers.Remove(entity);
            await kolorowewebContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
