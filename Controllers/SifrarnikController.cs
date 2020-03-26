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
    public class SifrarnikController : ControllerBase
    {
        private readonly MojContext _context;


        public SifrarnikController(MojContext context)
        {
            _context = context;
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/sifrarnik/GetAll")]
        public List<Sifrarnik> GetSifrarnik()
        {
            return _context.Sifrarnik.ToList();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        [Route("api/sifrarnik/GetSifrarnik/{id}")]
        public ActionResult GetSifrarnik(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sifrarnik sifrarnik = _context.Sifrarnik.Where(x => x.SifrarnikId == id).FirstOrDefault();

            if (sifrarnik == null)
            {
                return NotFound();
            }

            return Ok(sifrarnik);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut]
        [Route("api/sifrarnik/update/{id}")]
        public ActionResult Update(int id, Sifrarnik sifrarnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sifrarnik.SifrarnikId)
            {
                return BadRequest();
            }

            Sifrarnik newSifrarnik = _context.Sifrarnik.Where(x => x.SifrarnikId == id).FirstOrDefault();
            newSifrarnik.DatumKreiranja = sifrarnik.DatumKreiranja;
            newSifrarnik.Kesiranje = sifrarnik.Kesiranje;
            newSifrarnik.Naziv = sifrarnik.Naziv;
            newSifrarnik.Opis = sifrarnik.Opis;
            newSifrarnik.Oznaka = sifrarnik.Oznaka;
            newSifrarnik.Programerski = sifrarnik.Programerski;

            _context.Sifrarnik.Update(newSifrarnik);
            _context.SaveChanges();

            return Ok(newSifrarnik);

        }

        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("api/sifrarnik/add")]
        public ActionResult Post(Sifrarnik sifrarnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sifrarnik newSifrarnik = new Sifrarnik();
            newSifrarnik = new Sifrarnik()
            {
                DatumKreiranja = DateTime.Now,
                Naziv = sifrarnik.Naziv,
                Opis = sifrarnik.Opis,
                Oznaka = sifrarnik.Oznaka,
                Programerski = sifrarnik.Programerski,
                Kesiranje = sifrarnik.Kesiranje

            };

            _context.Sifrarnik.Add(newSifrarnik);
            _context.SaveChanges();

            return Ok(newSifrarnik);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        [Route("api/sifrarnik/izbrisi/{sifrarnikId}")]
        public void Delete(int sifrarnikId)
        {
            Sifrarnik sifrarnik = _context.Sifrarnik.Where(x => x.SifrarnikId == sifrarnikId).FirstOrDefault();

            List<StavkaSifrarnika> stavkeList = _context.StavkaSifrarnika.Where(x => x.SifrarnikId == sifrarnikId).ToList();
            List<PodstavkaSifrarnika> podstavkeList = new List<PodstavkaSifrarnika>();


            foreach (var s in stavkeList)
            {
                podstavkeList = _context.PodstavkaSifrarnika.Where(p => p.StavkaSifrarnikaId == s.StavkaSifrarnikaId).ToList();
                _context.RemoveRange(podstavkeList);
            }

            _context.StavkaSifrarnika.RemoveRange(stavkeList);
            _context.Sifrarnik.Remove(sifrarnik);

            _context.SaveChanges();
        }

    }
}