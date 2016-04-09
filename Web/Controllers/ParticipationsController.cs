﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Web.Controllers
{
    public class ParticipationsController : Controller
    {
        private readonly IUOW _uow;

        public ParticipationsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Participations
        public ActionResult Index()
        {
            var vm = _uow.Participations.All;
            //var participations = db.Participations.Include(p => p.Competition).Include(p => p.Person);
            return View(vm);
        }

        // GET: Participations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _uow.Participations.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // GET: Participations/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionID = new SelectList(_uow.Competitions.All, "CompetitionID", "CompetitionName");
            ViewBag.PersonID = new SelectList(_uow.Persons.All, "PersonID", "FirstName");
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipationID,PersonID,CompetitionID,Score")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _uow.Participations.Add(participation);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionID = new SelectList(_uow.Competitions.All, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(_uow.Persons.All, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // GET: Participations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _uow.Participations.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionID = new SelectList(_uow.Competitions.All, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(_uow.Persons.All, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipationID,PersonID,CompetitionID,Score")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _uow.Participations.Update(participation);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionID = new SelectList(_uow.Competitions.All, "CompetitionID", "CompetitionName", participation.CompetitionID);
            ViewBag.PersonID = new SelectList(_uow.Persons.All, "PersonID", "FirstName", participation.PersonID);
            return View(participation);
        }

        // GET: Participations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participation participation = _uow.Participations.GetById(id);
            if (participation == null)
            {
                return HttpNotFound();
            }
            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Participations.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Participations.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
