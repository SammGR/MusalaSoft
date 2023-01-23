
# Managing Gateways
This  project is about managing gateways.A master device that can control multiple peripheral devices.  


## Installation
To install the project you should load  in Visual Studio the solution given in the Installation folder,and the SQL scripts to import test data to SQL-Server 

```bash
The project was done using Visual Estudio 2019 .Net Framework 4.7.2 and MS SQL Server 2016
and NUnit with Mosking Framework (Moq) for execute meaningful Unit tests
```




    
## Software Properties:
 - Programming languages: C# 
 - Framework: ASP.NET
 - Database: MS SQL2016
 - UI: HTML,CSS,JavaScript ( bootbox, jquery )


## Intallation Folder
- Project Gateways --> Main Project
- Project Gateways.UnitTests
- Database Folder--> ( Scripts,Gateway.mdf and Gateway.backup) 
- Readme file 
## API Reference

#### Get all gateways 

```http
  GET /api/gateways
```
#### Get single gateway 

```http
  GET /api/gateways/${id}
  ```
#### Edit a gateway 

```http
  Put /api/gateways/${id}
```
#### Create a gateway 

```http
  Post /api/gateways/${id}
```
#### Edit a gateway 

```http
  Delete /api/gateways/${id}
```


