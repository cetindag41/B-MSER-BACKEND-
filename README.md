# B-MSER-BACKEND-
BİMSER BACKEND 
1) Ana adres girilip sayfa açıldığında, Home controler'dan index view'e gider. 
a) Index view'inde user-pass text alanları girilir. Giriş denendiğinde HomeControler'daki Login IActionResult'a gider. Doğrulama ve giriş bu fonksiyonla sağlanır.  Context olarak DbCtx isimli context kullanılır. Model olarak Personel isimli model kullanılır.
b) Kullanıcı hatalı giriş yaparsa yada eksik bilgi girerse TempData ile view'e taşınan uyarılar ekranda gösterilirerek kullanıcı uyarılır.
c) Bilgiler doğru girilirse kullanıcı  Yonlendir isimli IActionResult ile ana sayfaya yönlendirilir.

2) Login sayfasında action link ile yeni kullanıcı oluştur sayfasına yönlendirme yapar. PersonelCreate isimli kontroler 'daki aksiyonlar ile yeni kullanıcı oluşturulur. Gerekli validasyon yine bu endpointlerde gerçekleştirilir. Context olarak KullaniciRepo isimli context kullanılır. Model olarak Personel isimli model kullanılır.

3) AnaSayfa controller'da session ile kullanıcı adı ve soyadı taşınır. Index view'da kullanıcı adı ve soyadı gösterilir. Bununla birlikte YeniMesajGonder , KullaniciEngelle ve çıkış butonları yer alır.
a) Yeni mesaj gönder Action'ı MesajGonder isimli controler'a gider. Burda MesajKaydet ve Create aksiyonları yardımı ile yeni mesaj gönderilir. Kullanıcı engel durumu MesajKaydet isimli fonsiyonda doğrulanır. Session bilgisi bu foksiyondada yer alır. Tempdata ile uyarılar index'e gönderilir.  ID guid olarak atanır. Context olarak MesajlarRepo isimli repo kullanılır. Model olarak Personel ve Mesaj isimli modeller kullanılır.
b) KullaniciEngelle Action'ı KullaniciEngelle isimli controler'a gider. Burda EngelKaydet ve Create aksiyonları yardımı ile yeni engel oluşturur. Kullanıcı engel durumu EngelKaydet isimli fonsiyonda doğrulanır. Session bilgisi bu foksiyondada yer alır. Tempdata ile uyarılar index'e gönderilir.  ID guid olarak atanır. Context olarak EngelRepo isimli repo kullanılır. Model olarak Personel ve Engel isimli modeller kullanılır.
c)Ana sayfa view'de ayrıca Mesajlarım isimli aksiyon buton yer alır. Bu buton tetiklendiğinde MesajList isimli controler'a gider MesajListele isimli IActionResult yardımı ile yeni sayfa-view olarak kullanıcıya ait mailler gösterilir. Session bilgisi burda da taşınır.  Context olarak DbCtx isimli context kullanılır. Model olarak Mesajlar isimli model kullanılır.
d) Cıkıs aksiyonu kulanıcıyı Home\Index'e yönlendirir.



