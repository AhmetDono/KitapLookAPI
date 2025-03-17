# KitapLook RestFull API

## İçerik Tablosu
- [Proje Mimarisi ve Dosyaları](#proje-mimarisi-ve-dosyaları)
- [API Özellikleri](#api-özellikleri)
- [API Endpointleri](#api-endpointleri)
  - [Author Endpointerli](#author-endpointleri)
  - [Book Endpointleri](#book-endpointleri)
  - [Genre Endpointleri](#genre-endpointleri)

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
  
    `/api/Book/GetAll?PageNumber=1&PageSize=10`
  
    **Response Header** içinde meta veri döndürülür:
    ```json
    x-pagination: {"CurrentPage":1,"TotalPage":1,"PageSize":10,"TotalCount":2,"HasPrevious":false,"HasNext":false}
    ```

- **Sıralama:**
    - Verilerin sıralanmasını destekler. Kullanıcılar, verileri belirli kriterlere göre sıralayabilirler.
    - Örnek:
    ```text
    /api/Book/GetAll?OrderBy=bookTitle%20desc%2C%20publishedYear%20asc
    ```

- **Arama:**
    - Kullanıcıların verilerde arama yapabilmelerine olanak tanır.
    - Örnek:
    ```text
    /api/Book/GetAll?SearchTerm=K%C3%BCrk%20Mantolu%20Madonna
    ```

- **Veri Şekillendirme:**
    - Kullanıcıların yalnızca ihtiyaç duydukları verileri almasını sağlar.
    - Örnek:
    ```text
    /api/Book/GetAll?Fields=bookTitle%2CauthorName
    ```

- **HEAD-OPTIONS:**
    - HEAD ve OPTIONS HTTP metodlarını destekler, bu da istemcilere meta-veri sorgulama ve veri hakkında bilgi edinme imkanı tanır.

- **JWT, Identity ve Refresh Token:**
    - API, kullanıcı kimlik doğrulaması için JWT (JSON Web Token) kullanır. Kullanıcı giriş yaptıktan sonra, bir erişim token'ı (access token) alır. Bu token, API'ye yapılan sonraki taleplerde kimlik doğrulaması için kullanılır. Ayrıca, kullanıcı token'ını yenilemek için bir refresh token da sağlanır.


# API Endpointleri

## Author Endpointleri
- **CREATE AUTHOR:**
    - Endpoint:
    ```text
    api/Author/Create
    ```

    - Request Body:
    ```
    {
      "authorName": "string",
      "bornDeatYear": "string",
      "bio": "string",
      "image": "string"
    }
    ```
- **DELETE AUTHOR:**
    - Endpoint:
    ```text
    api/Author/Delete/{id}
    ```

- **UPDATE AUTHOR:**
  - Endpoint:
    ```text
    api/Author/Update/{id}
    ```

  - Request Body:
    ```text
    {
      "authorName": "string",
      "bornDeatYear": "string",
      "bio": "string",
      "image": "string",
      "id": 0
    }
    ```

- **GETALL AUTHOR:**
    - Endpoint:
    ```text
    api/Author/GetAll
    ```
    - Parametereler:
    ```text
    PageSize,PageNumber,SearchTerm,OrdeyBy,Fields
    ```


- **GETBYID AUTHOR:**
    - Endpoint:
    ```text
    api/Author/GetById/{id}
    ```

## Book Endpointleri
- **CREATE BOOK:**
    - Endpoint:
    ```text
    api/Book/Create
    ```

    - Request Body:
    ```
    {
      "bookTitle": "string",
      "bookDescription": "string",
      "authorID": 0,
      "isbn": "string",
      "publishedYear": 0,
      "publisher": "string",
      "coverImage": "string",
      "bookGenre": [
        {
          "genreId": 0
        }
      ]
    }
    ```
- **DELETE BOOK:**
    - Endpoint:
    ```text
    api/Book/Delete/{id}
    ```

- **UPDATE BOOK:**
  - Endpoint:
    ```text
    api/Book/Update/{id}
    ```

  - Request Body:
    ```text
    {
      "id":0,
      "bookTitle": "string",
      "bookDescription": "string",
      "authorID": 0,
      "isbn": "string",
      "publishedYear": 0,
      "publisher": "string",
      "coverImage": "string",
      "bookGenre": [
        {
          "genreId": 0
        }
      ]
    }
    ```

- **GETALL BOOK:**
    - Endpoint:
    ```text
    api/Genre/GetAll
    ```
    - Parametereler:
    ```text
    PageSize,PageNumber,SearchTerm,OrdeyBy,Fields
    ```


- **GETBYID BOOK:**
    - Endpoint:
    ```text
    api/Genre/GetById/{id}
    ```

## Genre Endpointleri
- **CREATE GENRE:**
    - Endpoint:
    ```text
    api/Genre/Create
    ```

    - Request Body:
    ```
    {
      "name": "string"
    }
    ```
- **DELETE GENRE:**
    - Endpoint:
    ```text
    api/Genre/Delete/{id}
    ```

- **UPDATE GENRE:**
  - Endpoint:
    ```text
    api/Genre/Update/{id}
    ```

  - Request Body:
    ```text
    {
      "name": "string",
      "id": 0
    }
    ```

- **GETALL GENRE:**
    - Endpoint:
    ```text
    api/Genre/GetAll
    ```
    - Parametereler:
    ```text
    PageSize,PageNumber,SearchTerm,OrdeyBy,Fields
    ```


- **GETBYID GENRE:**
    - Endpoint:
    ```text
    api/Genre/GetById/{id}
    ```
