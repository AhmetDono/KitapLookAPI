# KitapLook RestFull API


# Proje Mimarisi ve Dosyalari
### Katmanlı Mimari
<br>
├── /Entities
<br>
    <div style="margin-left: 30px;">
    └── Models
    <br>
    └── Data Transfer Objects
    <br>
    └── Exceptions
    <br>
    └── Request Features
    </div>
<br>
├── /KitapLookApi(Configure Projesi)
    <div style="margin-left: 30px;">
    └── Utilities
    <br>
    └── Extensions
    </div>
<br>
├── /Presentation
    <div style="margin-left: 30px;">
    └── Controllers
    </div>
<br>
├── /Repository
    <div style="margin-left: 30px;">
    └── Utilities
    <br>
    └── Conracts
    <br>
    └── Ef Core
    <br>
    └── Migrations
    </div>
<br>
├── /Services
    <div style="margin-left: 30px;">
    └── Contracts
    <br>
    └── Managers
    </div>
<br>

# API ozellikleri

<br>
── <b>NLog:</b>
    <div style="margin-left: 30px;">
     Nlog ile kapsamli loglama.
    </div>
<br>
── <b>Global Hata Yonetimi:</b>
    <div style="margin-left: 30px;">
     Exceptions ile tüm API hataları merkezi bir yerde yakalanır ve uygun yanıtlar döndürülür.
    </div>
<br>
── <b>İçerik Pazarlığı:</b>
    <div style="margin-left: 30px;">
     API, istemciden gelen `Accept` başlıklarına göre veri formatını (JSON veya XML) pazarlığa sokar ve buna göre yanıtlar döndürür.
    </div>
<br>
── <b>Asenkron Kod:</b>
    <div style="margin-left: 30px;">
     API, performans ve ölçeklenebilirlik için asenkron kod kullanır.
    </div>
<br>
── <b>Sayfalama:</b>
    <div style="margin-left: 30px;">
     Veritabanı sorgularında büyük veri setlerinin daha verimli bir şekilde döndürülmesi için sayfalama uygulanır.
    </div>
<br>
── <b>Siralama:</b>
    <div style="margin-left: 30px;">
     Verilerin sıralanmasını destekler. Kullanıcılar, verileri belirli kriterlere göre sıralayabilirler.
    </div>
<br>
── <b>Arama:</b>
    <div style="margin-left: 30px;">
     Kullanıcının verilerde arama yapabilmesine olanak tanır, böylece kullanıcılar ihtiyaç duydukları verilere hızlıca ulaşabilirler.
    </div>
<br>
── <b>Veri Sekillendirme:</b>
    <div style="margin-left: 30px;">
     Kullanıcıların yalnızca ihtiyaç duydukları verileri almasını sağlar. Bu sayede API performansı artırılır.
    </div>
<br>
── <b>Head-Options:</b>
    <div style="margin-left: 30px;">
     HEAD ve OPTIONS HTTP metodlarını destekler, bu da istemcilere meta-veri sorgulama ve veri hakkında bilgi edinme imkanı tanır.
    </div>
<br>
── <b>JWT, Identity ve Refresh Token:</b>
    <div style="margin-left: 30px;">
     Json Web Token (JWT), kimlik doğrulama (Identity) ve refresh token desteği sunarak güvenli bir kullanıcı doğrulama işlemi sağlar.
    </div>
<br>
