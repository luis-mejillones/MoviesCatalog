# Movies Catalog

It's a simple Movies Catalog demo project to demostrate a basic implementation of API Rest service under ASP.NET core 6 platform.

## Features

- Feature 1 **Movies** CRUD
  Add, Update and Delete operation for Movies. Only Admin user can execute these operations.
  Create movie can be done calling this endpoint `POST https://localhost:32768/api/Movie`
  Payload:

  ```
  {
  "name": "Movie 01 edited",
  "releaseYear": 2001,
  "synopsis": "EDITED Just a test about Movie 01",
  "movieCategory": 2
  }
  ```

  For Update or Delete just add the movieId at the end of url. Similar to previous payload for Update.

- Feature 2 **Movies** Searchin/Filtering/Sorting/Paginating
  Return movies by search, filter, paginated or sorted movies. to execute these task just add query string values and payload por search like: `POST https://localhost:32768/api/movie/search`
  Payload:

  ```
  {
   "name": "The Lion King",
   "synopsis": ""
  }
  ```

  The result will be something similar to:

```
{
    "pageNumber": 1,
    "pageSize": 10,
    "totalRecords": 1,
    "totalPages": 1,
    "data": [
        {
            "id": 51,
            "name": "The Lion King",
            "releaseYear": 1994,
            "synopsis": "A young lion prince is exiled from his pride after his father is murdered by his treacherous uncle, but he finds the courage to return and take his rightful place as king...",
            "urlPoster": null,
            "movieCategory": 18,
            "dateCreated": "2024-04-10T15:14:23.6391213",
            "user": {
                "id": 1,
                "name": "Administrator",
                "email": "admin@gmail.com",
                "password": "12345",
                "role": 0
            }
        }
    ]
}
```

For personalized paginated result the url can be like: `POST https://localhost:32768/api/movie/search?category=1&sort_by=name.desc&page_number=1&page_size=5 `
and Payload:

```
 {
  "name": "",
  "synopsis": ""
 }
```

The parameters for url query can be:

**category** Values in range of 0 to 20 which represnt values like 'Drama', 'Comedy' and so on.

**release** It's the releas year like 1994

**sort_by** Field name and suffix the order type like: 'name.asc', 'name.desc', 'year.asc', 'year.desc', 'date_created.asc', 'date_created.desc'
**page_number**
**page_size**

- Feature 3 **Authentication**
  The users to call this API should be authenticaded calling this endpoint: `POST https://localhost:32768/api/Login/authenticate`
  And the payload should be:

```
{
  "email": "user@gmail.com",
  "password": "67890"
}
```

**Note** For simplicity reason the password is not encrypted in database.

The users registered in database are:
| Email | Password | Role
| ----------- | ----------- |----------- |
| user@gmail.com | 67890 | User |
| admin@gmail.com | 12345 | Admin |

After login process, the API will return the JWT token key and it should be added to other endpoints as **Bearer Token** authentication method.

- Feature 4 **Ratings**
  Each user can rate the movi calling the next endpoint: `POST https://localhost:32768/api/rating_movie`
  Payload:

```
{
  "movieId": 4,
  "rate": 1
}
```

The rate values can be a number which represent the number of start for a given movie, the next describes the rate.
★☆☆☆☆ (1 star) - Poor: The movie is of very low quality and not enjoyable.
★★☆☆☆ (2 stars) - Fair: The movie has some redeeming qualities but falls short in many aspects.
★★★☆☆ (3 stars) - Good: The movie is enjoyable and entertaining, but may have some flaws.
★★★★☆ (4 stars) - Very Good: The movie is of high quality, well-made, and highly enjoyable.
★★★★★ (5 stars) - Excellent: The movie is exceptional, with outstanding performances, writing, direction, and overall impact.

- Feature 5 **Docker**
  The aplication is being deployed into a Docker instance and it's reachable from any browser or tools like postman to call the API.

**Note**
As part of the project files a postman collection has been aded (File: `MovieCatalog.postman_collection.json`) in the root of the project which has all postman command to call the API.

## Technologies Used

- ASP.NET Core 6
- Entity Framework Core
- SQLite
- Docker

## Getting Started

To get a local copy up and running follow these simple steps.

- Checkout the next repo: `https://github.com/luis-mejillones/MoviesCatalog.git`
- Open the project named `MoviesCatalog.sln` into Visual Studio
- Run it.
  **Note** Into `Data` folder is the file `database.db` which is the SQLite database.

### Prerequisites

- .NET 6 SDK
- Visual Studio 2022 or Visual Studio Code
- SQLite

## Contact

Leonardo Mejillones - leonardo.mejillones@gmail.com

Project Link: [ https://github.com/luis-mejillones/MoviesCatalog.git](https://github.com/luis-mejillones/MoviesCatalog.git)
