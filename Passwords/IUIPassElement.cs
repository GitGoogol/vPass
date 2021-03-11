using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassElements
{
    public interface IUIPassElement
    {
        bool setImgPath(string imagePath);
        string getRandomImgPath();
    }
}
