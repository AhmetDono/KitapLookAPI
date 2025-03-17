# KitapLook RestFull API

## Table of Contents
- [Proje Mimarisi ve Dosyaları](#proje-mimarisi-ve-dosyaları)
- [API Özellikleri](#api-özellikleri)
- [API Endpointleri](#api-endpointleri)

# Proje Mimarisi ve Dosyaları
## Katmanlı Mimari
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

# API Özellikleri

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
── <b>Sayfalama ve MetaData:</b>
<div style="margin-left: 30px;">
    Veritabanı sorgularında büyük veri setlerinin daha verimli bir şekilde döndürülmesi için sayfalama uygulanır.
<br>
<br>
Kullanicidan pageSize ve pageNumber degerleri alinir:
<br>
<br>

    `https://localhost:3000/api/Book/GetAll?PageNumber=1&PageSize=10`

<Br>
Response Header icinde meta data dondurulur.
<br>
<br>

    x-pagination: {"CurrentPage":1,"TotalPage":1,"PageSize":10,"TotalCount":2,"HasPrevious":false,"HasNext":false}

</div>
<br>
── <b>Siralama:</b>
<div style="margin-left: 30px;">
     Verilerin sıralanmasını destekler. Kullanıcılar, verileri belirli kriterlere göre sıralayabilirler.

<br>

?Orderby 'name' asc/desc
<br>

    https://localhost:7195/api/Book/GetAll?OrderBy=bookTitle%20desc%2C%20publishedYear%20asc

</div>
<br>
── <b>Arama:</b>
<div style="margin-left: 30px;">
     Kullanıcının verilerde arama yapabilmesine olanak tanır, böylece kullanıcılar ihtiyaç duydukları verilere hızlıca ulaşabilirler.

<br>

?SearchTerm 'name'
<br>

     https://localhost:7195/api/Book/GetAll?SearchTerm=K%C3%BCrk%20Mantolu%20Madonna

</div>
<br>
── <b>Veri Sekillendirme:</b>
<div style="margin-left: 30px;">
     Kullanıcıların yalnızca ihtiyaç duydukları verileri almasını sağlar. Bu sayede API performansı artırılır.

<br>

?Fields 'name1,name2'
<br>

    https://localhost:7195/api/Book/GetAll?Fields=bookTitle%2CauthorName

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


# API Endpointleri
