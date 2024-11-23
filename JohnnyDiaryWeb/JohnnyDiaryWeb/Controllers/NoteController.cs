
using Microsoft.AspNetCore.Mvc;
using JohnnyDiaryWeb.Models;
using JohnnyDiaryWeb.Services;
using System.Collections.Generic;

namespace JohnnyDiaryWeb.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteService _noteService;

        public NoteController()
        {
            _noteService = new NoteService();
        }

        public IActionResult Index()
        {
            var notes = _noteService.GetNotes();
            return View(notes); // Pass the notes to the view
        }

        [HttpPost]
        public IActionResult Add(NoteEntry note)
        {
            if (!string.IsNullOrEmpty(note.Title) && !string.IsNullOrEmpty(note.Message))
            {
                var notes = _noteService.GetNotes();
                notes.Add(note);
                _noteService.SaveNotes(notes);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string title)
        {
            var notes = _noteService.GetNotes();
            notes.RemoveAll(n => n.Title == title);
            _noteService.SaveNotes(notes);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Personal Project for Johnny, theres not much thats private.";
            return View();
        }

        // New Action for the "Home" endpoint
        public IActionResult Home()
        {
            return Redirect("https://johnnyhuang101.github.io");
        }
    }
}
