
using System.Collections.Generic;
using System.IO;
using JohnnyDiaryWeb.Models;
using Newtonsoft.Json;

namespace JohnnyDiaryWeb.Services
{
    public class NoteService
    {
        private readonly string _filePath = "storage.json";

        public List<NoteEntry> GetNotes()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }

            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<NoteEntry>>(json) ?? new List<NoteEntry>();
        }

        public void SaveNotes(List<NoteEntry> notes)
        {
            string json = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
