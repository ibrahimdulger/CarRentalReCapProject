using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string DailyPriceInvalid = "Günlük fiyat geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Ürünler Listelendi";
        public static string BrandNameInvalid = "Marka ismi 2 karakterden fazla olmalıdır";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string ColorNameInvalid = "Renk en az 3 harfli olmalıdır";
        public static string ColorAdded = "Yeni renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ModelNameInvalid = "Model ismi en az 2 harfli olmalıdır";
        public static string ModelAdded = "Yeni model eklendi";
        public static string ModelUpdated = "Model güncellendi";
        public static string Added = "Ekleme işlemi başarılı";
        public static string ReturnDateCheck = "Aracı geri getirme tarihi alış tarihinden sonra olmaladıdır";
        public static string CarNotAvaliableAtGivenDate = "Araç müsait değil";
    }
}
