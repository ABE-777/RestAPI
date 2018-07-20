using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DataSeed : IDataSeed
    {
        /// <summary>
        /// Gets Paste object by its identifier
        /// </summary>
        /// <param name="Identifier">Should be paste identifier</param>
        /// <returns>Returns Paste object if found by paste identifier or null if not found</returns>
        public Paste GetPaste(string Identifier)
        {
            using (var db = new PasteDBContext())
            {
                return db.Pastes.FirstOrDefault(p => p.Identifier == Identifier);
            }
        }

        /// <summary>
        /// Modifies access date of paste
        /// </summary>
        /// <param name="pasteId">Should be paste identifier</param>
        public void ChangePasteAccessDate(int pasteId)
        {
            using (var db = new PasteDBContext())
            {
                var paste =  db.Pastes.Find(pasteId);

                if (paste != null)
                {
                    paste.AccessDate = DateTime.Now;

                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds Paste object to DB
        /// </summary>
        /// <param name="paste">Should be paste object to insert to DB</param>
        public void AddPaste(Paste paste)
        {
            using (var db = new PasteDBContext())
            {
                //if paste not exists
                if (!db.Pastes.Any(p => p.Identifier == paste.Identifier))
                {
                    db.Pastes.Add(paste);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes Paste object from DB by identifier
        /// </summary>
        /// <param name="identifier">Should be paste identifier</param>
        public bool DeletePaste(string identifier)
        {
            using (var db = new PasteDBContext())
            {
                try
                {
                    var paste = db.Pastes.FirstOrDefault(p => p.Identifier == identifier);

                    if (paste != null)
                    {
                        db.Pastes.Remove(paste);
                        db.SaveChanges();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
