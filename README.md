## For The First Time-> Fork & Clone the Repo

https://github.com/Razan-Alahmadi/Monthly_Project_1

## create branch
git checkout -b AR-feature/Edit-Readme-File
## save it
git add .
git commit -m "[numberOfPush] nameOfFeature - Short Description"

## push your feature
git push origin feature/<feature-name>

## up to date your main:
git checkout main
git pull origin main
git checkout feature/user-login
git merge main

## After the PR is merged into the main repository, sync your fork 

## Required Dependencies:

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0

dotnet add package MySql.EntityFrameworkCore --version 8.0.33
