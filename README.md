# Hahn.ApplicationProcess

#### Summary
Applicaiton is an implementation of the repository pattern followed by the SOLID principles and used EFCore In memory for data handling.


##### Development Enviroment
 - .NET Core 3.1
 - Visual studio 2019

##### Setting up Solution in Development Enviroment

- Clone the project
- Build Domain Project
- Build Data Project
- Set Start-up Project "Hahn.ApplicatonProcess.May2020.Web"
- Run Application

##### Solution Design and Structure

- Domain Project is dealing with Entities which will be mapped to database tabels. 
- Data Project is dealing with repositoryies and services
- Web Project is dealing with exposing api endpoints 
