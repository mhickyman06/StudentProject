using StudentProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentProject.ViewModels
{
    public class ListSpellersViewModel
    {
        public IEnumerable<SpellersTab> Spellers { get; set; }

        public IEnumerable<SpellersVideos> SpellersVideos { get; set; }

        public IEnumerable<SpellersImg> SpellersImgs { get; set; }

    }
}