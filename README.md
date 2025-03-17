# KitapLook RestFull API

## Table of Contents
- [Proje Mimarisi ve Dosyaları](#proje-mimarisi-ve-dosyaları)
- [API Özellikleri](#api-özellikleri)
- [API Endpointleri](#api-endpointleri)

---

# Proje Mimarisi ve Dosyaları

## Katmanlı Mimari

- **/Entities**
  - Models
  - Data Transfer Objects
  - Exceptions
  - Request Features
  
- **/KitapLookApi (Configure Projesi)**
  - Utilities
  - Extensions
  
- **/Presentation**
  - Controllers

- **/Repository**
  - Utilities
  - Contracts
  - Ef Core
  - Migrations

- **/Services**
  - Contracts
  - Managers

---

# API Özellikleri

- **NLog:**
    - Nlog ile kapsamlı loglama.
  
- **Global Hata Yönetimi:**
    - Exceptions ile tüm API hataları merkezi bir yerde yakalanır ve uygun yanıtlar döndürülür.
  
- **İçerik Pazarlığı:**
    - API, istemciden gelen `Accept` başlıklarına göre veri formatını (JSON veya XML) pazarlığa sokar ve buna göre yanıtlar döndürür.

- **Asenkron Kod:**
    - API, performans ve ölçeklenebilirlik için asenkron kod kullanır.

- **Sayfalama ve MetaData:**
    - Veritabanı sorgularında büyük veri setlerinin daha verimli bir şekilde döndürülmesi için sayfalama uygulanır.
    - Kullanıcıdan `PageSize` ve `PageNumber` değerleri alınır:
  
    `https://localhost:3000/api/Book/GetAll?PageNumber=1&PageSize=10`
  
    **Response Header** içinde meta veri döndürülür:
    ```json
    x-pagination: {"CurrentPage":1,"TotalPage":1,"PageSize":10,"TotalCount":2,"HasPrevious":false,"HasNext":false}
    ```

- **Sıralama:**
    - Verilerin sıralanmasını destekler. Kullanıcılar, verileri belirli kriterlere göre sıralayabilirler.
    - Örnek:
    ```text
    https://localhost:7195/api/Book/GetAll?OrderBy=bookTitle%20desc%2C%20publishedYear%20asc
    ```

- **Arama:**
    - Kullanıcıların verilerde arama yapabilmelerine olanak tanır.
    - Örnek:
    ```text
    https://localhost:7195/api/Book/GetAll?SearchTerm=K%C3%BCrk%20Mantolu%20Madonna
    ```

- **Veri Şekillendirme:**
    - Kullanıcıların yalnızca ihtiyaç duydukları verileri almasını sağlar.
    - Örnek:
    ```text
    https://localhost:7195/api/Book/GetAll?Fields=bookTitle%2CauthorName
    ```

- **HEAD-OPTIONS:**
    - HEAD ve OPTIONS HTTP metodlarını destekler, bu da istemcilere meta-veri sorgulama ve veri hakkında bilgi edinme imkanı tanır.

- **JWT, Identity ve Refresh Token:**
    - API, kullanıcı kimlik doğrulaması için JWT (JSON Web Token) kullanır. Kullanıcı giriş yaptıktan sonra, bir erişim token'ı (access token) alır. Bu token, API'ye yapılan sonraki taleplerde kimlik doğrulaması için kullanılır. Ayrıca, kullanıcı token'ını yenilemek için bir refresh token da sağlanır.
  
    **Login Endpoint:**
    ```bash
    POST https://localhost:7195/api/Auth/Login
    ```

    **Response:**
    ```json
    {
        "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
        "refreshToken": "dGhpc0lzYVJlZnJlc2hUb2tlbg=="
    }
    ```

    **Token Yenileme Endpoint:**
    ```bash
    POST https://localhost:7195/api/Auth/RefreshToken
    ```

    **Request:**
    ```json
    {
        "refreshToken": "dGhpc0lzYVJlZnJlc2hUb2tlbg=="
    }
    ```

    **Response:**
    ```json
    {
        "accessToken": "newAccessTokenHere"
    }
    ```

---

# API Endpointleri

