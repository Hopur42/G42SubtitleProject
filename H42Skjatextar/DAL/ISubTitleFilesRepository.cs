using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public interface ISubTitleFilesRepository
    {
        IEnumerable<SubTitleFiles> GetAllSubTitleFiles();
        SubTitleFiles GetSubTitleFile(string subTitleFiles);
        void AddSubTitleFile(SubTitleFiles subTitleFiles);
        void RemoveSubTitleFiles(SubTitleFiles subTitleFiles);
        void Save();
        SubTitleFiles FindSubTitleFileById(int? id);
        H42SkjatextarContext GetDbContext();
    }
}