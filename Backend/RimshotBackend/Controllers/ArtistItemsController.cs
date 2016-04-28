using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RimshotBackend.Models;
using Echonest;
using RimshotBackend.Context;

namespace RimshotBackend.Controllers
{
    public class ArtistItemsController : ApiController
    {
        private RimshotBackendContext db = new RimshotBackendContext();

        private IEchonestClient client = EchonestClientFactory.CreateEchonestClient("8ODSXTN9KZEOQEUWG");

        // GET: api/ArtistItems
        public IQueryable<ArtistItem> GetArtistItems()
        {
            return db.ArtistItems;
        }

        // GET: api/ArtistItems/5
        [ResponseType(typeof(ArtistItem))]
        public async Task<IHttpActionResult> GetArtistItem(string id)
        {
            ArtistItem artistItem = null;

            try
            {
                artistItem = await db.ArtistItems.SingleOrDefaultAsync(item => item.Songkick.Equals(id));
                if (artistItem == null)
                {
                    //return NotFound();
                    var profile = await client.GetProfile(id);
                    if (profile.response.status.code == 0)
                    {
                        var artist = profile.response.artist;
                        artistItem = new ArtistItem() { Songkick = id, DisplayName = artist.name };

                        if (artist.foreign_ids != null)
                        {
                            foreach (var foreign in artist.foreign_ids)
                            {
                                if (foreign.catalog.Equals("spotify")) artistItem.Spotify = foreign.foreign_id.Split(':').Last();
                                if (foreign.catalog.Equals("xboxmusic-ZZ")) artistItem.Groove = foreign.foreign_id.Split(':').Last();
                            }
                        }

                        db.ArtistItems.Add(artistItem);
                        await db.SaveChangesAsync();

                        return CreatedAtRoute("DefaultApi", new { id = artistItem.Id }, artistItem);
                    }

                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok(artistItem);
        }

        // PUT: api/ArtistItems/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutArtistItem(int id, ArtistItem artistItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != artistItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(artistItem).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ArtistItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/ArtistItems
        [ResponseType(typeof(ArtistItem))]
        //public async Task<IHttpActionResult> PostArtistItem(ArtistItem artistItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ArtistItems.Add(artistItem);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = artistItem.Id }, artistItem);
        //}

        // DELETE: api/ArtistItems/5
        //[ResponseType(typeof(ArtistItem))]
        //public async Task<IHttpActionResult> DeleteArtistItem(int id)
        //{
        //    ArtistItem artistItem = await db.ArtistItems.FindAsync(id);
        //    if (artistItem == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ArtistItems.Remove(artistItem);
        //    await db.SaveChangesAsync();

        //    return Ok(artistItem);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool ArtistItemExists(int id)
        //{
        //    return db.ArtistItems.Count(e => e.Id == id) > 0;
        //}
    }
}