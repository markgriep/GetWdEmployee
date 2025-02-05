### Demo on how to get data from workday

Doesn't use any DI or anything fancy, just a simple console app 
to show how to get the data from Workday. Also deserializes it.


__Prerequisites:__

- You need to have a local UserSecrets file

1. Right click on the project > Manage User Secrets
2. Add info like this
```json
{
  "wdusername": "user123",
  "wdpassword": "pass456",
  "proxyUri": "http://someProxy.contoso.com:888",
  "peopleuri": "https://somehost.workday.com/customreport/MY_ISU/Employees",
  "test": "Shhhh, don't tell!"
}
```




