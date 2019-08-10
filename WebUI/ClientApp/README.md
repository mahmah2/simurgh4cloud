# AngularSpa

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.7.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).


##Server build command (Self contained dotnet core app)

C:\Projects\Simurgh\Site\Ver2\Simurgh\WebUI>
dotnet publish -c release -r win10-x64


##client build command (Server build will build this as well. So not really necessary)
C:\Projects\Simurgh\Site\Ver2\Simurgh\WebUI\ClientApp\src\app>
ng build --prod="true"


##How to add external Javascript file
https://stackoverflow.com/questions/50842115/how-to-use-external-js-files-in-angular-6


##How to create an EF migration and update DB accordingly
dotnet ef migrations add [MigrationName]

dotnet ef database update

##Or open Package Manager Console - Set default project to Simurgh.DAL - Run:
##observation : these commands are applied to the database in WebAPI folder
Add-Migration ChangeComment -verbose

Update-Database

##create service in module
ng g s "client-service/Project" --module="./admin-module/admin-module"
