using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
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
            this.kolorowewebContext = context;
        }

        //public UserPostController(KolorowewebContext kolorowewebContext)
        //{
        //    this.kolorowewebContext = kolorowewebContext;
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offers>>> GetOffers()
        {
            return await kolorowewebContext.Offers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Offers>> PostOffer(Offers offer)
        {
            kolorowewebContext.Offers.Add(offer);
            await kolorowewebContext.SaveChangesAsync();

            return offer;
        }

        [HttpDelete("{Id}")]
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
