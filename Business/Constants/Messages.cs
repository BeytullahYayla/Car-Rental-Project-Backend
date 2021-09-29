using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constraints
{
    public static class Messages
    {

        // Brand Manager Messages
        public static string BrandAdded = "Marka Başarı ile Eklendi";
        public static string BrandDeleted = "Marka Başarı ile Silindi";
        public static string BrandCantDeleted = "Marka Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string BrandsListed = "Markalar Başarı ile Listelendi";
        public static string BrandListed = "Marka Başarı ile Getirildi";
        public static string BrandUpdated ="Marka Başarı ile Güncellendi";
        public static string BrandCantUpdated = "Marka Güncellenemedi... Veritabaninda kayitli olmayabilir";
        public static string BrandCountOfError = "Bir markadan en fazla 10 tane olabilir...";
        public static string BrandNameAlreadyExist = "Bu marka zaten veritabanında kayıtlı...";
        public static string BrandLimitExceeded = "Marka limiti asildi....";
        public static string BrandIsNotExists = "Boyle bir marka veritabaninda kayitli degil...";
        // End of Brand Manager Messages
        // Color Manager Messages
        public static string ColorAdded = "Renk Başarı ile Eklendi";
        public static string ColorCantAdded = "Renk Eklenemedi";
        public static string ColorDeleted = "Renk Başarı ile Silindi";
        public static string ColorCantDeleted = "Renk Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string ColorsListed = "Renkler Başarı ile Listelendi";
        public static string ColorNotExists = "Renk Veritabaninda kayitli Degil.";
        public static string ColorListed = "Renk Başarı ile Getirildi";
        public static string ColorUpdated = "Renk Başarı ile Güncellendi";
        public static string ColorCantUpdated = "Renk Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        // End of Color Manager Messages
        // Car Manager Messages
        public static string CarAdded = "Araba Başarı ile Eklendi";
        public static string CarDescInvalidLetterLenght = "Araç Açıklaması 2 Karakterden Büyük Olmalıdır.\n ";
        public static string CarPriceInvalidCost = "Araç Günlük Fiyatı 0 liradan den Fazla Olmalıdır.";
        public static string CarDeleted = "Araba Başarı ile Silindi";
        public static string CarCantDeleted = "Araba Silinemedi...Veritabaninda kayitli olmayabilir.";
        public static string CarListed = "Araba Başarı ile Getirildi";
        public static string CarsListed = "Araba Başarı ile Listelendi";
        public static string CarListedByBrand = "Araba Başarı ile Listelendi";
        public static string CarListedByColor = "Araba Başarı ile Listelendi";
        public static string CarUpdated = "Araba Başarı ile Güncellendi";
        public static string CarCantUpdated = "Araba Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CarsListedDetailDto = "Arabalar Başarı ile Listelendi";
        // End of Car Manager Messages
        // User Manager Messages
        public static string UserAdded = "Kullanıcı Başarı ile Eklendi";
        public static string UserDeleted = "Kullanıcı Başarı ile Silindi";
        public static string UserCantDeledet =  "Kullanıcı Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string UserUpdated = "Kullanıcı Başarı ile Güncellendi";
        public static string UserCantUpdated = "Kullanıcı Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string UsersListed = "Kullanıcılar Başarı ile Listelendi";
        public static string UserListed = "Kullanıcı Başarı ile Getirildi";
        public static string UserCantFound = "Kullanici Bulunamadi";
       
        // End of User Manager Messages
        // Customer Manager Messages
        public static string CustomerAdded = "Müşteri Başarı ile Eklendi";
        public static string CustomerDeleted = "Müşteri Başarı ile Silindi";
        public static string CustomerCantDeledet = "Müşteri Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CustomerUpdated = "Müşteri Başarı ile Güncellendi";
        public static string CustomerCantUpdated = "Müşteri Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string CustomersListed = "Müşteriler Başarı ile Listelendi";
        public static string CustomerListed = "Müşteri Başarı ile Getirildi";
        public static string CustomerNotExists = "Musteri Veritabaninda Kayitli Degil";
        // End of Customer Manager Messages
        // Rental Manager Messages
        public static string RentalAdded = "Kiralama Başarı ile Eklendi";
        public static string RentalDeleted = "Kiralama Başarı ile Silindi";
        public static string RentalCantDeledet = "Kiralama Silinemedi... Böyle Birşey Artık Olmayabilir.";
        public static string RentalsListed = "Kiralamalar Başarı ile Listelendi";
        public static string RentalListed = "Kiralama Başarı ile Getirildi";
        public static string RentalUpdated = "Kiralama Başarı ile Güncellendi";
        public static string RentalCantUpdated = "Kiralama Güncellenemedi... Böyle Birşey Artık Olmayabilir.";
        public static string RentalProblem = "Araç Kiralanamadı... Araç yok";
        public static string RentalNotExists = "Kiralanma bilgisi veritabaninda kayitli degil...";
        public static string CarDeliveryError = "Arac henuz teslim edilmemistir...";


        // End of Rental Manager Messages

        //Authoraziation Manager Messages
        public static string AuthorizationDenied = "Yetkilendirme Basarisiz Oldu";

        public static string AccessTokenCreated = "Acces Token Basariyla Olusturuldu";

        public static string WrongPassword = "Yanlis Sifre!";
        public static string SuccessfullyLogin = "Basariyla Giris Yapildi";

        public static string SuccessfullyRegistered = "Kayit Basarili";

        public static string UserAlreadyExist = "Kullanici Zaten Kayitli";
        public  static string FilterSuccessfull="Arabaya Filtre Basariyla Uygulandi Ve Getirildi";
        public static string CarsImagesListed="Araba Resimleri Getirildi";
        public static string CarImageIdNotExist="Boyle bir car image id yok";
        public static string CarImageLimitExceeded="Resim sayisi limiti aştı";
        public static string CarImageDeleted="Araba resmi silindi";
        public static string ErrorDeletingImage="Resim Silinemedi";
        public static string CarImageUpdated="Araba resmi güncellendi";
        public static string ErrorUpdatingImage="Araba resmi güncellenirken bir hata oluştu";
        public static string CarImageUploaded="Araba resmi yüklendi";
        public static string CarImageListed="Araba resmi listelendi";
        public static string RentDateInvalid="Kiralama tarihi geçerli değil";
    }
}
