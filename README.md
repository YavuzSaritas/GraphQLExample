# GraphQLExample
```bash
The use POST request example after the run GraphQL API. 
{ 
 "query":"query{allcategory{id name}}"
}
{ 
 "query":"query{allproduct{id name}}"
}
{ 
 "query":"query{category(id:1){id name}}"
}
{ 
 "query":"query{category(id:1){id name products{id name}}}"
}
```
