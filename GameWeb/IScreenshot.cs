using GameWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWeb
{
    public interface IScreenshot
    {
        IEnumerable<GalleryScreenshot> GetAll();
        IEnumerable<GalleryScreenshot> GetByTagName(string tag);

        GalleryScreenshot GetById(int id);
    }
}
