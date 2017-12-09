# GZipStreamCompression
Measurements of simple json compressions using GZipStream

### Input
Given JSON as:
```JSON
[{
  "FirstName": "Anakin",
  "LastName": "Skywalker",
  "Age": 25,
  "Company": {
    "Name": "The Empire",
    "Address": {
      "StreetAddress": "601 Death Star",
      "Country": "Somewhere dark side",
      "City": "Something dark side"
    }
  }
}]
```
### Result
| List entries | JSON size | Compressed size |
| :------------- | :------------- | :------------- |
| 1 | 204 bytes | 241 bytes |
| 10 | 2 KB | 1.1 KB |
| 100 | 19.1 KB | 7.8 KB |
| 1000 | 190.3 KB | 63,3 KB |
| 10000 | 1.9 MB | 628,8 KB |
| 100000 | 18.6 MB | 6.1 MB |
