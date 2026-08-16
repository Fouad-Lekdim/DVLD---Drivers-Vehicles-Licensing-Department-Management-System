using DVLD___Business_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System___Drivers_and_Vehicles_License_Department
{
    public static class clsImageHelper
    {
        public const string ManImagePath = "C:\\Users\\foufo\\Downloads\\man.png";
        public const string WomanImagePath = "C:\\Users\\foufo\\Downloads\\woman.png";
        public const string NullImagePath = "C:\\Users\\foufo\\Downloads\\null.png";
        public static Image LoadPersonImage(ref string imagePath)
        {
            switch (imagePath)
            {
                case clsPerson.DEFAULT_MALE_IMAGE:
                    return Properties.Resources.man;

                case clsPerson.DEFAULT_FEMALE_IMAGE:
                    return Properties.Resources.woman;

                case clsPerson.DEFAULT_NULL_IMAGE:
                    return Properties.Resources._null;

                default:
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        return Image.FromFile(imagePath);

                    imagePath = clsPerson.DEFAULT_NULL_IMAGE;
                    return Properties.Resources._null;
            }
        }

        public static bool Is_ImagePath_Valid(string imagePath)
        {
            return (imagePath == clsImageHelper.ManImagePath
                        || imagePath == clsImageHelper.WomanImagePath
                        || imagePath == clsImageHelper.NullImagePath
                        || (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath)));
        }

        public static bool Is_Image_Set(string imagePath)
        {
            return !(string.IsNullOrEmpty(imagePath)
                    || imagePath == clsImageHelper.ManImagePath
                    || imagePath == clsImageHelper.WomanImagePath
                    || imagePath == clsImageHelper.NullImagePath);
        }

        public static bool Is_Image_Exists(string imagePath)
        {
            return File.Exists(imagePath);
        }
    }
}
