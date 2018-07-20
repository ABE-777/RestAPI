using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    interface IDataSeed
    {
        Paste GetPaste(string Identifier);

        void ChangePasteAccessDate(int pasteId);

        void AddPaste(Paste paste);

        bool DeletePaste(string identifier);
    }
}
