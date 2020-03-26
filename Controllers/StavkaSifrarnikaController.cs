using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using optomŠifrarnik.Context;
using optomŠifrarnik.Models;

namespace optomŠifrarnik.Controllers
{
    [ApiController]
    public class StavkaSifrarnikaController : ControllerBase
    {
        private readonly MojContext _context;

        public StavkaSifrarnikaController(MojContext context)
        {
            _context = context;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/stavkaSifrarnika/GetAll")]
        public List<StavkaSifrarnika> GetStavkaSifrarnika()
        {
            return _context.StavkaSifrarnika.ToList();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/stavkaSifrarnika/GetStavkaSifrarnikaBySifrarnik/{sifrarnikId}")]
        public ActionResult GetStavkaSifrarnikaBySifrarnik(int sifrarnikId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<StavkaSifrarnika> stavkeList = _context.StavkaSifrarnika.Where(x => x.SifrarnikId == sifrarnikId).ToList();

            if (stavkeList == null)
            {
                return NotFound();
            }

            return Ok(stavkeList);
        }

        // GET: api/StavkaSifrarnika/5
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/stavkaSifrarnika/GetStavka/{id}")]
        public ActionResult GetStavkaSifrarnika(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StavkaSifrarnika stavkaSifrarnika = _context.StavkaSifrarnika.Where(x => x.StavkaSifrarnikaId == id).FirstOrDefault();

            if (stavkaSifrarnika == null)
            {
                return NotFound();
            }

            return Ok(stavkaSifrarnika);
        }

        // PUT: api/StavkaSifrarnika/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        [Route("api/stavkaSifrarnika/update/{id}")]
        public ActionResult PutStavkaSifrarnika(int id, StavkaSifrarnika stavkaSifrarnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavkaSifrarnika.StavkaSifrarnikaId)
            {
                return BadRequest();
            }

            StavkaSifrarnika newStavkaSifrarnika = _context.StavkaSifrarnika.Where(x => x.StavkaSifrarnikaId == stavkaSifrarnika.StavkaSifrarnikaId).FirstOrDefault();
            newStavkaSifrarnika.SifrarnikId = stavkaSifrarnika.SifrarnikId;
            newStavkaSifrarnika.DatumKreiranja = stavkaSifrarnika.DatumKreiranja;
            newStavkaSifrarnika.Naziv = stavkaSifrarnika.Naziv;
            newStavkaSifrarnika.Oznaka = stavkaSifrarnika.Oznaka;
            newStavkaSifrarnika.Preduzece = stavkaSifrarnika.Preduzece;
            newStavkaSifrarnika.RedniBroj = stavkaSifrarnika.RedniBroj;

            _context.StavkaSifrarnika.Update(newStavkaSifrarnika);
            _context.SaveChanges();

            return Ok(newStavkaSifrarnika);

        }

        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("api/stavkaSifrarnika/add")]
        public ActionResult PostStavkaSifrarnika(StavkaSifrarnika stavkaSifrarnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StavkaSifrarnika newStavkaSifrarnika = new StavkaSifrarnika()
            {
                SifrarnikId = stavkaSifrarnika.SifrarnikId,
                DatumKreiranja = DateTime.Now,
                Naziv = stavkaSifrarnika.Naziv,
                Oznaka = stavkaSifrarnika.Oznaka,
                Preduzece = stavkaSifrarnika.Preduzece,
                RedniBroj = stavkaSifrarnika.RedniBroj,
            };

            _context.StavkaSifrarnika.Add(newStavkaSifrarnika);
            _context.SaveChanges();

            return Ok(newStavkaSifrarnika);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        [Route("api/stavkaSifrarnika/delete/{id}")]
        public void DeleteStavkaSifrarnika(int id)
        {
            StavkaSifrarnika stavkaSifrarnika = _context.StavkaSifrarnika.Where(x => x.StavkaSifrarnikaId == id).FirstOrDefault();

            List<PodstavkaSifrarnika> podstavkaList = new List<PodstavkaSifrarnika>();
            foreach (var item in _context.PodstavkaSifrarnika.ToList())
            {
                if (item.StavkaSifrarnikaId == id)
                    podstavkaList.Add(item);
            }

            _context.PodstavkaSifrarnika.RemoveRange(podstavkaList);
            _context.StavkaSifrarnika.Remove(stavkaSifrarnika);

            _context.SaveChanges();
        }
    }
}