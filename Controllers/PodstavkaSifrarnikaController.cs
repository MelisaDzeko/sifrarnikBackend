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
    public class PodstavkaSifrarnikaController : ControllerBase
    {
        private readonly MojContext _context;

        public PodstavkaSifrarnikaController(MojContext context)
        {
            _context = context;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/podstavkaSifrarnika/GetAllPodstavkaSifrarnika")]
        public List<PodstavkaSifrarnika> GetAllPodstavkaSifrarnika()
        {
            List<PodstavkaSifrarnika> podstavkaList = _context.PodstavkaSifrarnika.ToList();

            return podstavkaList;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/podstavkaSifrarnika/GetPodstavkaById/{id}")]
        public PodstavkaSifrarnika GetPodstavkaById(int id)
        {
            PodstavkaSifrarnika podstavkaSifrarnika = _context.PodstavkaSifrarnika.Find(id);

            return podstavkaSifrarnika;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/podstavkaSifrarnika/PodstavkaByStavkaId/{id}")]
        public ActionResult PodstavkaByStavkaId(int id)
        {
            List<PodstavkaSifrarnika> podrstavkeList = _context.PodstavkaSifrarnika.Where(x => x.StavkaSifrarnikaId == id).ToList(); ;

            return Ok(podrstavkeList);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        [Route("api/podstavkaSifrarnika/update/{id}")]
        public IActionResult PutPodstavkaSifrarnika(int id, PodstavkaSifrarnika podstavkaSifrarnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PodstavkaSifrarnika newPodstavkaSifrarnika = _context.PodstavkaSifrarnika.Where(x => x.PodstavkaSifrarnikaId == id).FirstOrDefault();
            newPodstavkaSifrarnika.StavkaSifrarnikaId = podstavkaSifrarnika.StavkaSifrarnikaId;
            newPodstavkaSifrarnika.DatumKreiranja = DateTime.Now;
            newPodstavkaSifrarnika.Naziv = podstavkaSifrarnika.Naziv;
            newPodstavkaSifrarnika.Oznaka = podstavkaSifrarnika.Oznaka;
            newPodstavkaSifrarnika.Preduzece = podstavkaSifrarnika.Preduzece;
            newPodstavkaSifrarnika.RedniBroj = podstavkaSifrarnika.RedniBroj;

            _context.PodstavkaSifrarnika.Update(newPodstavkaSifrarnika);
            _context.SaveChanges();

            return Ok(newPodstavkaSifrarnika);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("api/podstavkaSifrarnika/add")]
        public IActionResult PostPodstavkaSifrarnika(PodstavkaSifrarnika podstavkaSifrarnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PodstavkaSifrarnika newPodstavkaSifrarnika = new PodstavkaSifrarnika()
            {
                StavkaSifrarnikaId = podstavkaSifrarnika.StavkaSifrarnikaId,
                DatumKreiranja = podstavkaSifrarnika.DatumKreiranja,
                Naziv = podstavkaSifrarnika.Naziv,
                Oznaka = podstavkaSifrarnika.Oznaka,
                Preduzece = podstavkaSifrarnika.Preduzece,
                RedniBroj = podstavkaSifrarnika.RedniBroj
            };

            _context.PodstavkaSifrarnika.Add(newPodstavkaSifrarnika);
            _context.SaveChanges();

            return Ok(newPodstavkaSifrarnika);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        [Route("api/podstavkaSifrarnika/delete/{id}")]
        public void DeletePodstavkaSifrarnika(int id)
        {
            PodstavkaSifrarnika podstavkaSifrarnika = _context.PodstavkaSifrarnika.Where(x => x.PodstavkaSifrarnikaId == id).FirstOrDefault();

            _context.PodstavkaSifrarnika.Remove(podstavkaSifrarnika);
            _context.SaveChanges();
        }
    }
}